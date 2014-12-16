using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kev.IM
{
    public static class MessageType
    {
        /// <summary>
        /// 登陆
        /// </summary>
        public const int Login = 1;

        /// <summary>
        /// 获取用户资料
        /// </summary>
        public const int GetUserInfo = 2;

        /// <summary>
        /// 新用户登陆
        /// </summary>
        public const int NewUserLogin = 3;

        /// <summary>
        /// 获取用户列表
        /// </summary>
        public const int GetUserFriendList = 4;

        /// <summary>
        /// 文字类聊天
        /// </summary>
        public const int ChatTextMessage = 5;
    }
}
