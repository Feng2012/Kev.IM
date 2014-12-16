using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kev.IM.Service
{
    public class ChatMessageModel
    {
        /// <summary>
        /// 发送者UserId
        /// </summary>
        public long SendUserId { get; set; }

        /// <summary>
        /// 接收者UserId
        /// </summary>
        public long ReceiveUserId { get; set; }
    }
}
