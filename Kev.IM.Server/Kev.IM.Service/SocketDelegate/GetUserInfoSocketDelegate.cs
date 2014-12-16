using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kev.IM.Service
{
    public class GetUserInfoSocketDelegate : IUDPServerDelegate
    {
        public new int GetType()
        {
            return MessageType.GetUserInfo;
        }

        public int HandleRequestMessage(UDPModel uModel)
        {
            KevSocketModel ksModel = JsonHelper.ParseFromJson<KevSocketModel>(uModel);
            if (ksModel == null)
                return ResponseCode.AnalyticalDataError;

            UDPServer udpServer = KevRegister.Get<UDPServer>(UDPPrimaryKey.UDPServer);

            //根据当前的请求返回相应数据
            KevSocketModel<UserInfoModel> ksModel_result = new KevSocketModel<UserInfoModel>
            {
                Data = UserCache.GetUserInfo(ksModel.DeviceId, () => { return new UserInfoModel { UserId = ksModel.DeviceId, NickName = "匿名：" + ksModel.DeviceId % 1000000, Signature = "你看不见我，看不见我" }; }),
                ResponseCode = ResponseCode.Success,
                MessageId = ksModel.MessageId,
                MessageType = GetType(),
                NetworkType = NetworkType.Request
            };

            ksModel_result.NetworkType = NetworkType.Response;
            ksModel_result.DeviceId = ksModel.DeviceId;
            udpServer.SendMessage(ksModel_result, uModel.IPPoint);

            return ResponseCode.NoResponse;
        }


        public int HandleResponseMessage(UDPModel uModel)
        {
            throw new NotImplementedException();
        }

        public void HandleTimeOutMessage(UDPModel uModel)
        {
            throw new NotImplementedException();
        }
    }
}
