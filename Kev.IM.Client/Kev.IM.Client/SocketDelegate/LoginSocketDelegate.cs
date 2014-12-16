using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Kev.IM.Client
{
    public class LoginSocketDelegate : IUDPClientDelegate
    {
        private delegate void CallBack();
        private delegate void CallBackWithObject(object obj);

        public MainForm MainForm { get; set; }

        public LoginSocketDelegate() { }

        public LoginSocketDelegate(MainForm mainForm)
        {
            this.MainForm = mainForm;
        }

        public new int GetType()
        {
            return MessageType.Login;
        }

        public int HandleRequestMessage(UDPModel uModel)
        {
            Console.WriteLine("LoginSocketDelegate::HandleRequestMessage  我居然接到这个请求，别闹了。" + DateTime.Now.ToString());
            return ResponseCode.NoResponse;
        }

        public int HandleResponseMessage(UDPModel uModel)
        {
            //判断数据
            KevSocketModel<long> ksModel = JsonHelper.ParseFromJson<KevSocketModel<long>>(uModel.Body, uModel.Length);
            if (ksModel == null)
                return ResponseCode.NotFindKevSocketModel;

            //处理相关的逻辑然后进行跳转
            Dispatcher dispatcher = KevRegister.Get<Dispatcher>(ClientItemsPrimaryKey.Dispatcher_MainThread);

            MainForm mainForm = KevRegister.Get<MainForm>(ClientItemsPrimaryKey.Form_Main);

            if (ksModel.ResponseCode == ResponseCode.Success)
            {
                dispatcher.Invoke(() =>
                {
                    if (mainForm != null)
                        mainForm.Hide();

                    //替换本机的Id
                    KevRegister.Add<long>(UDPPrimaryKey.Client_ThisDeviceId, ksModel.Data);

                    KevRegister.Get<HomeForm>(ClientItemsPrimaryKey.Form_Home, () =>
                    {
                        return new HomeForm();
                    }).Show();
                });

                //请求本机资料
                KevSocketModel ksModel_requestSelfUserInfo = new KevSocketModel
                {
                    DeviceId = KevRegister.Get<long>(UDPPrimaryKey.Client_ThisDeviceId, -1),
                    MessageId = IdGenerator.NextId(),
                    MessageType = MessageType.GetUserInfo,
                    NetworkType = NetworkType.Request
                };

                UDPClient udpClient = KevRegister.Get<UDPClient>(ClientItemsPrimaryKey.Socket_UDPClient);
                if (!udpClient.SendMessage(ksModel_requestSelfUserInfo))
                {
                    KevRegister.Get<HomeForm>(ClientItemsPrimaryKey.Form_Home).label_status.Text = "请求自己的资料失败";
                }

                //获取已经登录的人
                KevSocketModel ksModel_getFriendList = new KevSocketModel
                {
                    DeviceId = KevRegister.Get<long>(UDPPrimaryKey.Client_ThisDeviceId, -1),
                    MessageId = IdGenerator.NextId(),
                    MessageType = MessageType.GetUserFriendList,
                    NetworkType = NetworkType.Request
                };
                udpClient.SendMessage(ksModel_getFriendList);
            }
            else
            {
                dispatcher.Invoke(() =>
                {
                    mainForm.ShowAPrompt(ResponseCode.GetDescription(ksModel.ResponseCode));
                });
            }

            return ResponseCode.NoResponse;
        }


        public void HandleTimeoutMessage(KevMessageBoxModel ksbModel)
        {
            Dispatcher dispatcher = KevRegister.Get<Dispatcher>(ClientItemsPrimaryKey.Dispatcher_MainThread);
            dispatcher.Invoke(() =>
            {
                MainForm mainForm = KevRegister.Get<MainForm>(ClientItemsPrimaryKey.Form_Main);
                if (mainForm != null)
                    mainForm.ShowAPrompt("连接服务器超时了");
            });
        }
    }
}
