using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Kev.IM
{
    public static class KevRegister
    {
        private static ConcurrentDictionary<string, object> _register = new ConcurrentDictionary<string, object>();

        public delegate Ti GetT<Ti>();

        /// <summary>
        /// 注入内容
        /// </summary>
        /// <typeparam name="Ti"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        public static void Add<Ti>(string key, Ti t)
        {
            _register.AddOrUpdate(key, t, (k, obj) => obj);
        }

        /// <summary>
        /// 获取内容
        /// </summary>
        /// <typeparam name="Ti"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Ti Get<Ti>(string key)
        {
            return Get<Ti>(key, null);
        }

        /// <summary>
        /// 获取内容
        /// </summary>
        /// <typeparam name="Ti"></typeparam>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static Ti Get<Ti>(string key, Ti def)
        {
            object obj;
            if (_register.TryGetValue(key, out obj))
            {
                if (obj is Ti)
                    return (Ti)obj;
            }

            return def;
        }

        /// <summary>
        /// 获取内容
        /// </summary>
        /// <typeparam name="Ti"></typeparam>
        /// <param name="key"></param>
        /// <param name="fun"></param>
        /// <returns></returns>
        public static Ti Get<Ti>(string key, GetT<Ti> fun)
        {
            object obj;
            if (_register.TryGetValue(key, out obj))
            {
                if (obj is Ti)
                    return (Ti)obj;
            }

            if (fun == null)
                return default(Ti);

            Ti t = fun();
            Add(key, t);

            return t;
        }
    }
}
