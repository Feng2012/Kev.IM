using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Net;

namespace Kev.IM.Service
{
    public static class UserCache
    {
        private static ConcurrentDictionary<long, UserInfoModel> _userInfo = new ConcurrentDictionary<long, UserInfoModel>();
        private static ConcurrentDictionary<long, IPEndPoint> _userIP = new ConcurrentDictionary<long, IPEndPoint>();
        private static List<long> _userId = new List<long>();

        /// <summary>
        /// 尝试获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fun"></param>
        /// <returns></returns>
        public static UserInfoModel GetUserInfo(long id, Func<UserInfoModel> fun = null)
        {
            UserInfoModel uiModel;
            if (_userInfo.TryGetValue(id, out uiModel))
                return uiModel;

            if (fun == null)
                return null;

            uiModel = fun();
            _userInfo.TryAdd(id, uiModel);

            return uiModel;
        }

        public static IPEndPoint GetUserIP(long id)
        {
            IPEndPoint ip;

            if (_userIP.TryGetValue(id, out ip))
                return ip;

            return null;
        }

        public static IEnumerable<long> GetAllUserId()
        {
            long[] ids;

            lock (_userId)
            {
                ids = _userId.ToArray();
            }

            return ids;
        }

        public static void AddUser(long id, IPEndPoint ip, UserInfoModel uiModel = null)
        {
            lock (_userId)
            {
                _userId.Add(id);
            }

            if (ip != null)
                _userIP.TryAdd(id, ip);

            if (uiModel != null)
                _userInfo.TryAdd(id, uiModel);
        }
    }
}
