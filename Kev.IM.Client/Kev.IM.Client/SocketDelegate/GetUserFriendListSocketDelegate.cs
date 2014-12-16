using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Kev.IM.Client
{
    public class GetUserFriendListSocketDelegate : IUDPClientDelegate
    {
        public new int GetType()
        {
            return MessageType.GetUserFriendList;
        }

        public int HandleRequestMessage(UDPModel uModel)
        {
            return ResponseCode.Error;
        }

        public int HandleResponseMessage(UDPModel uModel)
        {
            KevSocketModel<IEnumerable<UserInfoModel>> ksModel = JsonHelper.ParseFromJson<KevSocketModel<IEnumerable<UserInfoModel>>>(uModel);
            if (ksModel == null)
                return ResponseCode.AnalyticalDataError;

            if (ksModel.ResponseCode != ResponseCode.Success)
            {
                KevRegister.Get<Dispatcher>(ClientItemsPrimaryKey.Dispatcher_MainThread).Invoke(() =>
                {
                    KevRegister.Get<HomeForm>(ClientItemsPrimaryKey.Form_Home).label_status.Text = ResponseCode.GetDescription(ksModel.ResponseCode);
                });

                return ResponseCode.Error;
            }

            if (ksModel.Data == null)
                return ResponseCode.AnalyticalDataError;
            KevRegister.Get<Dispatcher>(ClientItemsPrimaryKey.Dispatcher_MainThread).Invoke(() =>
            {
                KevRegister.Get<HomeForm>(ClientItemsPrimaryKey.Form_Home).AddUserRange(ksModel.Data);
                foreach (UserInfoModel item in ksModel.Data)
                    UserCache.Updata(item);
            });

            return ResponseCode.Success;
        }

        public void HandleTimeoutMessage(KevMessageBoxModel ksbModel)
        {

        }
    }
}