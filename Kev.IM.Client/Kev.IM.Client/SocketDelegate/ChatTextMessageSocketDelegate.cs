using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Kev.IM.Client
{
    public class ChatTextMessageSocketDelegate : IUDPClientDelegate
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

            //界面上展示消息
            KevRegister.Get<Dispatcher>(ClientItemsPrimaryKey.Dispatcher_MainThread).Invoke(() =>
            {
                HomeForm hForm = KevRegister.Get<HomeForm>(ClientItemsPrimaryKey.Form_Home);
                ChatMessageCache.HandleMessage(ksModel_ctmModel.Data);
                hForm.HandleMessage(ksModel_ctmModel.Data);
            });

            return ResponseCode.Success;
        }

        public int HandleResponseMessage(UDPModel uModel)
        {
            KevSocketModel ksModel = JsonHelper.ParseFromJson<KevSocketModel>(uModel);
            if (ksModel == null)
                return ResponseCode.AnalyticalDataError;

            if (ksModel.ResponseCode != ResponseCode.Success)
            {
                KevRegister.Get<Dispatcher>(ClientItemsPrimaryKey.Dispatcher_MainThread).Invoke(() =>
                {
                    KevRegister.Get<HomeForm>(ClientItemsPrimaryKey.Form_Home).label_status.Text = ResponseCode.GetDescription(ksModel.ResponseCode);
                });
            }

            return ResponseCode.Success;
        }

        public void HandleTimeoutMessage(KevMessageBoxModel ksbModel)
        {
            //记录发送超时的消息
        }
    }
}
