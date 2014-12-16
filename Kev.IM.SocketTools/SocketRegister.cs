using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Net.Sockets;

namespace Kev.IM
{
    public static class SocketRegister
    {
        private static ConcurrentDictionary<string, Socket> socket_dic = new ConcurrentDictionary<string, Socket>();

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Socket Get(string key)
        {
            Socket _socket;

            if (socket_dic.TryGetValue(key, out _socket))
                return _socket;

            return null;
        }

        /// <summary>
        /// 注册数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="socket"></param>
        /// <returns></returns>
        public static bool Add(string key, Socket socket)
        {
            socket_dic.AddOrUpdate(key, socket, (k, _socket) => _socket);
            return true;
        }
    }
}
