using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kev.IM.Client
{
    /// <summary>
    /// 内容项主键表
    /// </summary>
    public static class ClientItemsPrimaryKey
    {
        /// <summary>
        /// UDP客户端
        /// </summary>
        public const string Socket_UDPClient = UDPPrimaryKey.UDPClient;

        /// <summary>
        /// 窗体 Home
        /// </summary>
        public const string Form_Home = "FORM_HOME";

        /// <summary>
        /// 窗体 Main
        /// </summary>
        public const string Form_Main = "FORM_MAIN";

        /// <summary>
        /// 主线程
        /// </summary>
        public const string Dispatcher_MainThread = "DISPATCHER_MAIN_THREAD";
    }
}
