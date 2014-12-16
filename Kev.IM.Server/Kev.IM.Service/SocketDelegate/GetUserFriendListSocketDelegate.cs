using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kev.IM.Service
{
    public class GetUserFriendListSocketDelegate : IUDPServerDelegate
    {
        public new int GetType()
        {
            return MessageType.GetUserFriendList;
        }

        public int HandleRequestMessage(UDPModel uModel)
        {
            KevSocketModel ksModel = JsonHelper.ParseFromJson<KevSocketModel>(uModel);
            if (ksModel == null)
                return ResponseCode.AnalyticalDataError;

            IEnumerable<long> userIds = UserCache.GetAllUserId();
            if (userIds == null || userIds.Count() == 0)
                return ResponseCode.NotFind;

            List<UserInfoModel> uiModels = new List<UserInfoModel>();
            foreach (long id in userIds)
            {
                UserInfoModel uiModel = UserCache.GetUserInfo(id, () =>
                {
                    return new UserInfoModel
                    {
                        UserId = id,
                        NickName = "匿名：" + id % 10000,
                        Signature = "你看不见我，看不见我"
                    };
                });

                if (uiModel != null)
                    uiModels.Add(uiModel);
            }

            KevSocketModel<IEnumerable<UserInfoModel>> ksModel_userInfoModel = new KevSocketModel<IEnumerable<UserInfoModel>>
            {
                Data = uiModels,
                DeviceId = ksModel.DeviceId,
                MessageId = ksModel.MessageId,
                MessageType = GetType(),
                NetworkType = NetworkType.Response,
                ResponseCode = ResponseCode.Success
            };
            KevRegister.Get<UDPServer>(UDPPrimaryKey.UDPServer).SendMessage(ksModel_userInfoModel, uModel.IPPoint);

            return ResponseCode.NoResponse;
        }

        public int HandleResponseMessage(UDPModel uModel)
        {
            return ResponseCode.Error;
        }

        public void HandleTimeOutMessage(UDPModel uModel)
        {
        }
    }
}
