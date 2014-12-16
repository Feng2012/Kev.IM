using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Kev.IM.Client
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
            KevRegister.Add(ClientItemsPrimaryKey.Dispatcher_MainThread, dispatcher);

            MainForm mainForm = new MainForm();
            KevRegister.Add(ClientItemsPrimaryKey.Form_Main, mainForm);
            LoginSocketDelegate loginSocketDelegate = new LoginSocketDelegate();
            loginSocketDelegate.MainForm = mainForm;

            UDPClientRouteHelper.GetInstanse().SetDelegate(loginSocketDelegate);
            UDPClientRouteHelper.GetInstanse().SetDelegate(new GetUserInfoSocketDelegate());
            UDPClientRouteHelper.GetInstanse().SetDelegate(new NewUserLoginSocketDelegate());
            UDPClientRouteHelper.GetInstanse().SetDelegate(new GetUserFriendListSocketDelegate());
            UDPClientRouteHelper.GetInstanse().SetDelegate(new ChatTextMessageSocketDelegate());

            Application.Run(mainForm);
        }
    }
}
