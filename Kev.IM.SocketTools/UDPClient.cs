using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kev.IM
{
    /// <summary>
    /// UDP的客户端
    /// </summary>
    public class UDPClient
    {
        public const string Handshake1 = "HAND_SHAKE_1";
        public const string Handshake2 = "HAND_SHAKE_2";
        public const string Handshake3 = "HAND_SHAKE_3";
        public const string SocketClient = UDPPrimaryKey.UDPClientSocket;

        private bool isRuning;

        private int _timeOutSeconds = 8;

        /// <summary>
        /// 超时秒数
        /// </summary>
        public int TimeOutSeconds
        {
            get { return _timeOutSeconds; }
            set { _timeOutSeconds = value; }
        }

        /// <summary>
        /// 服务器地址
        /// </summary>
        public IPEndPoint ServerIPPoint { get; set; }

        /// <summary>
        /// 开始
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            isRuning = true;

            Socket socket_client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            if (this.ServerIPPoint == null)
                throw new Exception("IPPoint must be a valid value");

            socket_client.SendTo(Encoding.UTF8.GetBytes(Handshake1), ServerIPPoint);
            SocketRegister.Add(SocketClient, socket_client);

            Thread thread = new Thread(() =>
            {
                EndPoint remoteEP = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
                
                while (isRuning)
                {
                    int recv;
                    byte[] datas = new byte[8 * 1024];
                    try
                    {
                        recv = socket_client.ReceiveFrom(datas, ref remoteEP);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }

                    UDPModel udpModel = new UDPModel { Body = datas, IPPoint = (IPEndPoint)remoteEP, Length = recv };
                    ThreadPool.QueueUserWorkItem(new WaitCallback(HandleMessage), udpModel);
                }
            });
            thread.IsBackground = true;
            thread.Start();

            Thread thread_deepMessage = new Thread(() =>
            {
                while (isRuning)
                {
                    Thread.Sleep(100);
                    KevMessageBoxModel kmbModel = KevMessageBox.GetFirstMessage();
                    if (kmbModel == null)
                    {
                        continue;
                    }

                    if (kmbModel.TimeOut.Ticks <= DateTime.Now.Ticks)
                    {
                        //跳转到超时
                        ThreadPool.QueueUserWorkItem(new WaitCallback(HandleTimeOutMessage), kmbModel);
                    }
                    else
                    {
                        KevMessageBox.Enqueue(kmbModel.SocketModel.MessageId, kmbModel);
                    }
                }
            });
            thread_deepMessage.IsBackground = true;
            thread_deepMessage.Start();

            return true;
        }

        /// <summary>
        /// 结束
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            isRuning = false;

            return true;
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="state"></param>
        private void HandleMessage(object state)
        {
            UDPModel uModel = state as UDPModel;

            if (uModel == null)
                return;

            string message = Encoding.UTF8.GetString(uModel.Body, 0, uModel.Length);
            if (string.IsNullOrEmpty(message))
                return;

            Socket socket = SocketRegister.Get(SocketClient);
            if (socket == null)
                return;

            if (message == Handshake2)
                UDPSocketServer.SendMessage(socket, Handshake3, uModel.IPPoint);

            KevSocketModel ksModel = JsonHelper.ParseFromJson<KevSocketModel>(message);
            if (ksModel == null)
                return;

            Console.WriteLine("HandleMessage" + ksModel.MessageId + "::" + ksModel.MessageType);

            if (ksModel.NetworkType == NetworkType.Request)
            {
                long clientId = KevRegister.Get<long>(UDPPrimaryKey.Client_ThisDeviceId);

                //非指向本机请求一律抛弃
                if (ksModel.ReceiveDeviceId != clientId)
                    return;

                int responseCode = UDPClientRouteHelper.GetInstanse().HandleRequestMessage(ksModel, uModel);
                if (responseCode == ResponseCode.NoResponse)
                    return;

                ksModel.NetworkType = NetworkType.Response;
                ksModel.ResponseCode = responseCode;

                //做出相应

                UDPSocketServer.SendMessage(socket, ksModel, uModel.IPPoint);
            }

            if (ksModel.NetworkType == NetworkType.Response)
            {
                //从消息盒子中移除数据
                KevMessageBoxModel kmbModel = KevMessageBox.GetMessage(ksModel.MessageId);
                if (kmbModel != null)
                    UDPClientRouteHelper.GetInstanse().HandleResponseMessage(ksModel, uModel);
            }
        }

        /// <summary>
        /// 处理超时消息
        /// </summary>
        /// <param name="state"></param>
        private void HandleTimeOutMessage(object state)
        {
            KevMessageBoxModel ksbModel = state as KevMessageBoxModel;

            if (ksbModel == null)
                return;

            UDPClientRouteHelper.GetInstanse().HandleTimeOutMessage(ksbModel);
        }

        /// <summary>
        /// 发送消息给服务器
        /// </summary>
        /// <param name="ksModel"></param>
        /// <returns></returns>
        public bool SendMessage(KevSocketModel ksModel)
        {
            Socket socket = SocketRegister.Get(SocketClient);
            if (socket == null)
                return false;

            bool isSuccess = UDPSocketServer.SendMessage(socket, ksModel, this.ServerIPPoint);
            if (isSuccess)
            {
                Console.WriteLine("SendMessage" + ksModel.MessageId + "::" + ksModel.MessageType);

                KevMessageBox.Enqueue(ksModel.MessageId, new KevMessageBoxModel
                {
                    IP = ServerIPPoint,
                    SocketModel = ksModel,
                    TimeOut = DateTime.Now.AddSeconds(this.TimeOutSeconds)
                });
            }

            return isSuccess;
        }

        /// <summary>
        /// 发送消息给服务器
        /// </summary>
        /// <param name="ksModel"></param>
        /// <returns></returns>
        public bool SendMessage<T>(KevSocketModel<T> ksModel)
        {
            Socket socket = SocketRegister.Get(SocketClient);
            if (socket == null)
                return false;

            bool isSuccess = UDPSocketServer.SendMessage(socket, ksModel, this.ServerIPPoint);
            if (isSuccess)
            {
                Console.WriteLine("SendMessage" + ksModel.MessageId + "::" + ksModel.MessageType);

                KevMessageBox.Enqueue(ksModel.MessageId, new KevMessageBoxModel
                {
                    IP = ServerIPPoint,
                    SocketModel = ksModel,
                    TimeOut = DateTime.Now.AddSeconds(this.TimeOutSeconds)
                });
            }

            return isSuccess;
        }

        /// <summary>
        /// 发送消息给服务器
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool SendMessage(string message)
        {
            Socket socket = SocketRegister.Get(SocketClient);
            if (socket == null)
                return false;

            return UDPSocketServer.SendMessage(socket, message, this.ServerIPPoint);
        }
    }
}
