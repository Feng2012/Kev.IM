using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Kev.IM.Client
{
    public static class UserCache
    {
        private static ConcurrentDictionary<long, UserInfoModel> _uiModels = new ConcurrentDictionary<long, UserInfoModel>();

        public static void Updata(UserInfoModel uiModel)
        {
            if (uiModel == null || uiModel.UserId == -1)
                return;

            UserInfoModel tmpModel;

            if (_uiModels.ContainsKey(uiModel.UserId))
                _uiModels.TryRemove(uiModel.UserId, out tmpModel);

            _uiModels.TryAdd(uiModel.UserId, uiModel);
        }

        public static UserInfoModel Get(long id, Func<UserInfoModel> fun = null)
        {
            UserInfoModel uiModel;
            if (_uiModels.TryGetValue(id, out uiModel))
                return uiModel;

            if (fun == null)
                return null;

            uiModel = fun();
            if (uiModel != null)
                _uiModels.TryAdd(id, uiModel);

            return uiModel;
        }
    }
}
