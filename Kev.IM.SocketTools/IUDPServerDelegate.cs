using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Kev.IM
{
    public interface IUDPServerDelegate
    {
        /// <summary>
        /// 获取类型
        /// </summary>
        /// <returns></returns>
        int GetType();

        /// <summary>
        /// 处理网络消息
        /// </summary>
        /// <param name="uModel"></param>
        /// <returns></returns>
        int HandleRequestMessage(UDPModel uModel);

        /// <summary>
        /// 处理相应消息
        /// </summary>
        /// <param name="uModel"></param>
        /// <returns></returns>
        int HandleResponseMessage(UDPModel uModel);

        /// <summary>
        /// 处理超时消息
        /// </summary>
        /// <param name="uModel"></param>
        void HandleTimeOutMessage(UDPModel uModel);
    }
}
