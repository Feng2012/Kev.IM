using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Net;

namespace Kev.IM
{
    public static class KevMessageBox
    {
        private static ConcurrentQueue<long> messageId_queue = new ConcurrentQueue<long>();
        private static ConcurrentDictionary<long, KevMessageBoxModel> message_dic = new ConcurrentDictionary<long, KevMessageBoxModel>();

        /// <summary>
        /// 根据Id获取消息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static KevMessageBoxModel GetMessage(long id)
        {
            KevMessageBoxModel kmbModel = null;
            if (message_dic.ContainsKey(id))
            {
                message_dic.TryRemove(id,out kmbModel);
            }
            return kmbModel;
        }

        /// <summary>
        /// 获取第一个消息
        /// </summary>
        /// <returns></returns>
        public static KevMessageBoxModel GetFirstMessage()
        {
            long id;
            lock (messageId_queue)
            {
                while (messageId_queue.Count > 0 && messageId_queue.TryDequeue(out id))
                {
                    if (message_dic.ContainsKey(id))
                    {
                        return message_dic[id];
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 将Id添加到结尾
        /// </summary>
        /// <param name="message"></param>
        /// <param name="id"></param>
        public static void Enqueue(long id, KevMessageBoxModel message)
        {
            messageId_queue.Enqueue(id);
            message_dic.TryAdd(id, message);
        }
    }

    public class KevMessageBoxModel
    {
        /// <summary>
        /// 消息实体
        /// </summary>
        public KevSocketModel SocketModel { get; set; }

        /// <summary>
        /// 目标IP信息
        /// </summary>
        public IPEndPoint IP { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime TimeOut { get; set; }
    }
}
