using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kev.IM
{
    public static class ResponseCode
    {
        /// <summary>
        /// 调用成功
        /// </summary>
        public const int Success = 200;

        /// <summary>
        /// 请不要做出相应
        /// </summary>
        public const int NoResponse = 201;

        /// <summary>
        /// 未找到
        /// </summary>
        public const int NotFind = 400;

        /// <summary>
        /// 没有发现KevSocketModel
        /// </summary>
        public const int NotFindKevSocketModel = 401;

        /// <summary>
        /// 未注册的类型
        /// </summary>
        public const int NotRegisteredType = 402;

        /// <summary>
        /// 没有发现UDP服务器
        /// </summary>
        public const int NotFindUDPServer = 403;

        /// <summary>
        /// 找不到用户
        /// </summary>
        public const int NotFindUser = 404;

        /// <summary>
        /// 找不到用户的IP
        /// </summary>
        public const int NotFindUserIP = 405;

        /// <summary>
        /// 失败
        /// </summary>
        public const int Error = 600;

        /// <summary>
        /// 解析数据失败
        /// </summary>
        public const int AnalyticalDataError = 601;

        /// <summary>
        /// 网络错误
        /// </summary>
        public const int NetworkHostError = 602;

        /// <summary>
        /// 其他错误
        /// </summary>
        public const int OtherError = 609;


        /// <summary>
        /// 获取状态码的描述
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetDescription(int code)
        {
            return GetDescription(code, "Undefined type");
        }

        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="code"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static string GetDescription(int code, string def)
        {
            Dictionary<int, string> code2Description = new Dictionary<int, string>();
            code2Description.Add(200, "调用成功");
            code2Description.Add(201, "调用成功");
            code2Description.Add(400, "没有找到");
            code2Description.Add(401, "没有找到KevSocketModel");
            code2Description.Add(402, "未注册的逻辑");
            code2Description.Add(403, "没有发现UDP服务器");
            code2Description.Add(404, "找不到用户");
            code2Description.Add(405, "找不到用户的IP");
            code2Description.Add(600, "失败");
            code2Description.Add(601, "解析数据失败");
            code2Description.Add(602, "网络错误");
            code2Description.Add(609, "其他错误");

            if (!code2Description.ContainsKey(code))
                return def;

            return code2Description[code];
        }
    }
}
