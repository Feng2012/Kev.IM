using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kev.IM
{
    public class UDPClientRouteHelper
    {
        private static UDPClientRouteHelper _helper;

        private UDPClientRouteHelper() { }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static UDPClientRouteHelper GetInstanse()
        {
            if (_helper == null)
                _helper = new UDPClientRouteHelper();

            return _helper;
        }

        /// <summary>
        /// 处理请求消息
        /// </summary>
        /// <param name="ksModel"></param>
        /// <param name="uModel"></param>
        /// <returns></returns>
        public int HandleRequestMessage(KevSocketModel ksModel, UDPModel uModel)
        {
            int result_code = ResponseCode.Success;

            do
            {
                if (ksModel == null)
                {
                    result_code = ResponseCode.NotFindKevSocketModel;
                    break;
                }

                IUDPClientDelegate del = GetDelegate(ksModel.MessageType);
                if (del == null)
                {
                    result_code = ResponseCode.NotRegisteredType;
                    break;
                }

                result_code = del.HandleRequestMessage(uModel);
            } while (false);

            return result_code;
        }

        /// <summary>
        /// 处理响应消息
        /// </summary>
        /// <param name="ksModel"></param>
        /// <param name="uModel"></param>
        /// <returns></returns>
        public int HandleResponseMessage(KevSocketModel ksModel, UDPModel uModel)
        {
            int result_code = ResponseCode.Success;

            do
            {
                if (ksModel == null)
                {
                    result_code = ResponseCode.NotFindKevSocketModel;
                    break;
                }

                IUDPClientDelegate del = GetDelegate(ksModel.MessageType);
                if (del == null)
                {
                    result_code = ResponseCode.NotRegisteredType;
                    break;
                }

                result_code = del.HandleResponseMessage(uModel);
            } while (false);

            return result_code;
        }

        /// <summary>
        /// 处理超时消息
        /// </summary>
        /// <param name="ksbModel"></param>
        internal void HandleTimeOutMessage(KevMessageBoxModel ksbModel)
        {
            if (ksbModel == null || ksbModel.SocketModel == null || ksbModel.IP == null)
                return;

            IUDPClientDelegate del = GetDelegate(ksbModel.SocketModel.MessageType);
            if (del != null)
                del.HandleTimeoutMessage(ksbModel);
        }

        //代理
        private ConcurrentDictionary<int, IUDPClientDelegate> delegates = new ConcurrentDictionary<int, IUDPClientDelegate>();

        /// <summary>
        /// 获取服务器代理
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IUDPClientDelegate GetDelegate(int type)
        {
            IUDPClientDelegate del;
            if (delegates.TryGetValue(type, out del))
                return del;
            return null;
        }

        /// <summary>
        /// 设置代理
        /// </summary>
        /// <param name="del"></param>
        public void SetDelegate(IUDPClientDelegate del)
        {
            delegates.TryAdd(del.GetType(), del);
        }
    }
}
