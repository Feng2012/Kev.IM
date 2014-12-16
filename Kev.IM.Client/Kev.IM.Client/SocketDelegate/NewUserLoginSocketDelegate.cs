using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Kev.IM.Client
{
    public class NewUserLoginSocketDelegate : IUDPClientDelegate
    {
        public new int GetType()
        {
            return MessageType.NewUserLogin;
        }

        public int HandleRequestMessage(UDPModel uModel)
        {
            //哎呀有人上线了，怎么办呢。
            KevSocketModel<UserInfoModel> ksModel_userInfo = JsonHelper.ParseFromJson<KevSocketModel<UserInfoModel>>(uModel);
            if (ksModel_userInfo == null || ksModel_userInfo.Data == null)
                return ResponseCode.AnalyticalDataError;

            UserCache.Updata(ksModel_userInfo.Data);

            KevRegister.Get<Dispatcher>(ClientItemsPrimaryKey.Dispatcher_MainThread).Invoke(() =>
            {
                KevRegister.Get<HomeForm>(ClientItemsPrimaryKey.Form_Home).AddUser(ksModel_userInfo.Data);
            });

            return ResponseCode.Success;
        }

        public int HandleResponseMessage(UDPModel uModel)
        {
            return ResponseCode.Error;
        }

        public void HandleTimeoutMessage(KevMessageBoxModel ksbModel)
        {

        }
    }
}
