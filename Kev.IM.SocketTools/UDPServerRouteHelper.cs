using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;

namespace Kev.IM
{
    /// <summary>
    /// UDP服务器路由助手
    /// </summary>
    public class UDPServerRouteHelper
    {
        private static UDPServerRouteHelper _helper;

        private UDPServerRouteHelper() { }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static UDPServerRouteHelper GetInstanse()
        {
            if (_helper == null)
                _helper = new UDPServerRouteHelper();

            return _helper;
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="ksModel"></param>
        /// <param name="uModel"></param>
        /// <returns></returns>
        internal int HandleMessage(KevSocketModel ksModel, UDPModel uModel)
        {
            int result_code = 200;

            do
            {
                if (ksModel == null)
                {
                    result_code = 401;
                    break;
                }

                IUDPServerDelegate del = GetDelegate(ksModel.MessageType);
                if (del == null)
                {
                    result_code = 402;
                    break;
                }

                result_code = del.HandleRequestMessage(uModel);
            } while (false);

            return result_code;
        }


        /// <summary>
        /// 处理消息盒子中的过期消息
        /// </summary>
        /// <param name="ksbModel"></param>
        internal void HandleTimeOutMessage(KevMessageBoxModel ksbModel)
        {

        }

        //代理
        private ConcurrentDictionary<int, IUDPServerDelegate> delegates = new ConcurrentDictionary<int, IUDPServerDelegate>();

        /// <summary>
        /// 获取服务器代理
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IUDPServerDelegate GetDelegate(int type)
        {
            IUDPServerDelegate del;
            if (delegates.TryGetValue(type, out del))
                return del;
            return null;
        }

        /// <summary>
        /// 设置代理
        /// </summary>
        /// <param name="del"></param>
        public void SetDelegate(IUDPServerDelegate del)
        {
            delegates.TryAdd(del.GetType(), del);
        }

    }
}
