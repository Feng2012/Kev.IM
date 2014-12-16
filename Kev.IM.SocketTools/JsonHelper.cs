using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Kev.IM
{
    public class JsonHelper
    {
        /// <summary>
        /// 获取Json数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 获取Json的Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="szJson"></param>
        /// <returns></returns>
        public static T ParseFromJson<T>(string szJson)
        {
            T t = default(T);
            try
            {
                t = JsonConvert.DeserializeObject<T>(szJson);
            }
            catch (Exception ex)
            {
            }

            return t;
        }

        /// <summary>
        /// 将数组转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T ParseFromJson<T>(byte[] bytes, int length)
        {
            if (bytes == null || bytes.Length == 0)
                return default(T);

            if (length == 0)
                length = bytes.Length;

            return ParseFromJson<T>(Encoding.UTF8.GetString(bytes, 0, length));
        }

        public static T ParseFromJson<T>(UDPModel uModel)
        {
            return ParseFromJson<T>(uModel.Body, uModel.Length);
        }
    }
}