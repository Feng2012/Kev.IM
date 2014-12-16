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
    public class UDPServer
    {
        public const string Handshake1 = "HAND_SHAKE_1";
        public const string Handshake2 = "HAND_SHAKE_2";
        public const string Handshake3 = "HAND_SHAKE_3";

        //代理帮助函数
        private Thread thread;
        private bool isRuning;

        /// <summary>
        /// 监控端口
        /// </summary>
        public IPEndPoint BindIPPoint { get; set; }

        /// <summary>
        /// 开始
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            isRuning = true;
            thread = new Thread(() =>
            {
                Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                if (this.BindIPPoint == null)
                    throw new Exception("IPPoint must be a valid value");

                socketServer.Bind(this.BindIPPoint);

                SocketRegister.Add(UDPPrimaryKey.UDPServerSocket, socketServer);

                while (isRuning)
                {
                    byte[] data = new byte[8 * 1024];
                    IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                    EndPoint Remote = (EndPoint)(sender);
                    int recv;
                    try
                    {
                        recv = socketServer.ReceiveFrom(data, ref Remote);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }

                    UDPModel udpModel = new UDPModel { Body = data, IPPoint = (IPEndPoint)Remote, Length = recv };
                    ThreadPool.QueueUserWorkItem(new WaitCallback(HandleMessage), udpModel);
                }
            });

            thread.IsBackground = true;
            thread.Start();

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

            do
            {
                string message = Encoding.UTF8.GetString(uModel.Body, 0, uModel.Length);

                Socket socket = SocketRegister.Get(UDPPrimaryKey.UDPServerSocket);
                if (socket == null)
                    break;

                if (string.IsNullOrEmpty(message))
                    break;

                //三次握手

                if (message == Handshake1)
                {
                    UDPSocketServer.SendMessage(socket, Handshake2, uModel.IPPoint);
                    break;
                }

                if (message == Handshake3)
                    break;

                KevSocketModel ksModel = JsonHelper.ParseFromJson<KevSocketModel>(message);
                if (ksModel == null)
                    break;

                int responseCode = UDPServerRouteHelper.GetInstanse().HandleMessage(ksModel, uModel);
                if (ksModel.NetworkType == NetworkType.Request && responseCode != ResponseCode.NoResponse)
                {
                    ksModel.NetworkType = NetworkType.Response;
                    ksModel.ResponseCode = responseCode;

                    //做出响应
                    UDPSocketServer.SendMessage(socket, ksModel, uModel.IPPoint);
                }
            } while (false);
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            isRuning = false;
            thread = null;
            return true;
        }

        /// <summary>
        /// 发送消息给服务器
        /// </summary>
        /// <param name="ksModel"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool SendMessage(KevSocketModel ksModel, IPEndPoint ip)
        {
            Socket socket = SocketRegister.Get(UDPPrimaryKey.UDPServerSocket);
            if (socket == null)
                return false;

            return UDPSocketServer.SendMessage(socket, ksModel, ip);
        }

        /// <summary>
        /// 发送消息给服务器
        /// </summary>
        /// <param name="ksModel"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool SendMessage<T>(KevSocketModel<T> ksModel, IPEndPoint ip)
        {
            Socket socket = SocketRegister.Get(UDPPrimaryKey.UDPServerSocket);
            if (socket == null)
                return false;

            return UDPSocketServer.SendMessage(socket, ksModel, ip);
        }

        /// <summary>
        /// 发送消息给服务器
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool SendMessage(string message, IPEndPoint ip)
        {
            Socket socket = SocketRegister.Get(UDPPrimaryKey.UDPServerSocket);
            if (socket == null)
                return false;

            return UDPSocketServer.SendMessage(socket, message, ip);
        }
    }

    /// <summary>
    /// Udp数据转换时使用的Model
    /// </summary>
    public class UDPModel
    {
        /// <summary>
        /// 数据
        /// </summary>
        public byte[] Body { get; set; }

        /// <summary>
        /// 数据的长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public IPEndPoint IPPoint { get; set; }
    }
}
