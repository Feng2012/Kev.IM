using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kev.IM.Service
{
    public class ChatTextMessageSocketDelegate : IUDPServerDelegate
    {
        public new int GetType()
        {
            return MessageType.ChatTextMessage;
        }

        public int HandleRequestMessage(UDPModel uModel)
        {
            KevSocketModel<ChatTextMessageModel> ksModel_ctmModel = JsonHelper.ParseFromJson<KevSocketModel<ChatTextMessageModel>>(uModel);
            if (ksModel_ctmModel == null || ksModel_ctmModel.Data == null)
                return ResponseCode.AnalyticalDataError;

            ChatTextMessageModel ctmModel = ksModel_ctmModel.Data;
            ctmModel.SendUserId = ksModel_ctmModel.DeviceId;
            ctmModel.ReceiveUserId = ksModel_ctmModel.ReceiveDeviceId;

            IPEndPoint ip = UserCache.GetUserIP(ctmModel.ReceiveUserId);
            if (ip == null)
                return ResponseCode.NotFindUserIP;

            //转发消息
            KevRegister.Get<UDPServer>(UDPPrimaryKey.UDPServer).SendMessage(ksModel_ctmModel, ip);

            return ResponseCode.Success;
        }

        public int HandleResponseMessage(UDPModel uModel)
        {
            return ResponseCode.Success;
        }

        public void HandleTimeOutMessage(UDPModel uModel)
        {
            //记录发送超时的消息
        }
    }
}
