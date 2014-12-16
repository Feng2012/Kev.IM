using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Kev.IM
{
    public class UDPSocketServer
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="ksModel"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool SendMessage<T>(Socket socket, KevSocketModel<T> ksModel, IPEndPoint ip)
        {
            if (socket == null)
                return false;

            if (ksModel == null)
                return false;

            string message = JsonHelper.GetJson(ksModel);

            //KevMessageBox.Enqueue(ksModel.MessageId, new KevMessageBoxModel { IP = ip, SocketModel = ksModel, TimeOut = DateTime.Now });

            return SendMessage(socket, message, ip);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="ksModel"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool SendMessage(Socket socket, KevSocketModel ksModel, IPEndPoint ip)
        {
            if (socket == null)
                return false;

            if (ksModel == null)
                return false;

            string message = JsonHelper.GetJson(ksModel);

            //KevMessageBox.Enqueue(ksModel.MessageId, new KevMessageBoxModel { SocketModel = ksModel, IP = ip, TimeOut = DateTime.Now });

            return SendMessage(socket, message, ip);
        }

        /// <summary>
        /// 发送文本类消息
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="message"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool SendMessage(Socket socket, string message, IPEndPoint ip)
        {
            if (socket == null)
                return false;

            if (string.IsNullOrEmpty(message))
                return false;

            byte[] datas = Encoding.UTF8.GetBytes(message);
            return socket.SendTo(datas, ip) > 0;
        }
    }
}
