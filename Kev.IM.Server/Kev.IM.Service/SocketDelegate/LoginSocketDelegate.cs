using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kev.IM.Service
{
    public class LoginSocketDelegate : IUDPServerDelegate
    {
        public new int GetType()
        {
            return MessageType.Login;
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="uModel"></param>
        /// <returns></returns>
        public int HandleRequestMessage(UDPModel uModel)
        {
            KevSocketModel<LoginSocketModel> loginModel = JsonHelper.ParseFromJson<KevSocketModel<LoginSocketModel>>(uModel.Body, uModel.Length);
            if (loginModel == null)
                return ResponseCode.NotFindKevSocketModel;

            if (loginModel.NetworkType == NetworkType.Response)
                return ResponseCode.NoResponse;

            UDPServer udpServer = KevRegister.Get<UDPServer>(UDPPrimaryKey.UDPServer);
            if (udpServer == null)
                return ResponseCode.NotFindUDPServer;

            //判断是否正常登陆

            long newLoginId = IdGenerator.NextId();

            KevSocketModel<UserInfoModel> ksModel_newUserLogin = new KevSocketModel<UserInfoModel>
            {
                Data = UserCache.GetUserInfo(newLoginId, () => new UserInfoModel { UserId = newLoginId,NickName = "匿名：" + newLoginId % 1000000, Signature = "你看不见我，看不见我" }),
                DeviceId = newLoginId,
                MessageId = IdGenerator.NextId(),
                NetworkType = NetworkType.Request,
                MessageType = MessageType.NewUserLogin
            };

            //广播给之前的所有用户
            foreach (long uId in UserCache.GetAllUserId())
            {
                ksModel_newUserLogin.ReceiveDeviceId = uId;
                IPEndPoint ip = UserCache.GetUserIP(uId);
                if (ip != null)
                    udpServer.SendMessage(ksModel_newUserLogin, ip);
            }

            //重写自己的回执
            KevSocketModel<long> ksModel = new KevSocketModel<long>
            {
                ResponseCode = ResponseCode.Success,
                MessageId = loginModel.MessageId,
                MessageType = MessageType.Login,
                NetworkType = NetworkType.Response,
                ReceiveDeviceId = -1,
                Data = newLoginId
            };
            udpServer.SendMessage(ksModel, uModel.IPPoint);

            UserCache.AddUser(newLoginId, uModel.IPPoint);

            Console.WriteLine("有人成功登陆");

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
