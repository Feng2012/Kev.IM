using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kev.IM
{
    public enum NetworkType
    {
        /// <summary>
        /// 请求
        /// </summary>
        Request,

        /// <summary>
        /// 响应
        /// </summary>
        Response
    }

    public class KevSocketModel
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        public long MessageId { get; set; }

        /// <summary>
        /// 设备Id
        /// </summary>
        public long DeviceId { get; set; }

        /// <summary>
        /// 接受者设备Id
        /// </summary>
        public long ReceiveDeviceId { get; set; }

        /// <summary>
        /// 网络状态
        /// </summary>
        public NetworkType NetworkType { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public int MessageType { get; set; }

        /// <summary>
        /// 附带消息（网络状态码为OtherError时使用）
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 响应码
        /// </summary>
        public int ResponseCode { get; set; }
    }

    /// <summary>
    /// 消息传递的基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KevSocketModel<T> : KevSocketModel
    {
        /// <summary>
        /// 附带数据
        /// </summary>
        public T Data { get; set; }
    }
}
