using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kev.IM.Service
{
    public class ChatTextMessageModel : ChatMessageModel
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }
}
