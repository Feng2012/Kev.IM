using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Kev.IM
{
    public interface IUDPClientDelegate
    {
        /// <summary>
        /// 获取类型
        /// </summary>
        /// <returns></returns>
        int GetType();

        /// <summary>
        /// 处理请求消息
        /// </summary>
        /// <param name="uModel"></param>
        /// <returns></returns>
        int HandleRequestMessage(UDPModel uModel);

        /// <summary>
        /// 处理响应消息
        /// </summary>
        /// <param name="uModel"></param>
        /// <returns></returns>
        int HandleResponseMessage(UDPModel uModel);

        /// <summary>
        /// 处理超时的消息
        /// </summary>
        /// <param name="ksbModel"></param>
        void HandleTimeoutMessage(KevMessageBoxModel ksbModel);
    }
}
