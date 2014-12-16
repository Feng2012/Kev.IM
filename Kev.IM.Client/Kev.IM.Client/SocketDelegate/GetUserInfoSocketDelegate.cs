using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Kev.IM.Client
{
    public class GetUserInfoSocketDelegate : IUDPClientDelegate
    {
        public new int GetType()
        {
            return MessageType.GetUserInfo;
        }

        public int HandleRequestMessage(UDPModel uModel)
        {
            //我又不是服务器，你怎么能问我要资料呢
            return ResponseCode.NotFind;
        }

        public int HandleResponseMessage(UDPModel uModel)
        {
            KevSocketModel<UserInfoModel> userInfoModel = JsonHelper.ParseFromJson<KevSocketModel<UserInfoModel>>(uModel.Body, uModel.Length);
            if (userInfoModel == null)
                return ResponseCode.AnalyticalDataError;

            if (userInfoModel.ResponseCode != ResponseCode.Success)
            {
                KevRegister.Get<Dispatcher>(ClientItemsPrimaryKey.Dispatcher_MainThread).Invoke(() =>
                {
                    KevRegister.Get<HomeForm>(ClientItemsPrimaryKey.Form_Home).label_status.Text = ResponseCode.GetDescription(userInfoModel.ResponseCode);
                });
                return ResponseCode.NetworkHostError;
            }

            if (userInfoModel.Data == null)
                return ResponseCode.AnalyticalDataError;


            KevRegister.Get<Dispatcher>(ClientItemsPrimaryKey.Dispatcher_MainThread).Invoke(() =>
            {
                HomeForm homeForm = KevRegister.Get<HomeForm>(ClientItemsPrimaryKey.Form_Home);
                homeForm.label_nickName.Text = userInfoModel.Data.NickName;
                homeForm.label_signature.Text = userInfoModel.Data.Signature;
            });

            return ResponseCode.Success;
        }

        public void HandleTimeoutMessage(KevMessageBoxModel ksbModel)
        {
            if (ksbModel != null && ksbModel.SocketModel != null)
                KevRegister.Get<UDPClient>(ClientItemsPrimaryKey.Socket_UDPClient).SendMessage(ksbModel.SocketModel); ;
        }
    }
}
