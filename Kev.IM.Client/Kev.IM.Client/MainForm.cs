using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kev.IM.Client
{
    public partial class MainForm : Form
    {
        private delegate void MessageDelegate(object obj);

        public delegate void CallBackDelegate(string message);

        private LoginSocketDelegate textMessageSocketDelegate;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            UDPClient udpClient = KevRegister.Get<UDPClient>(ClientItemsPrimaryKey.Socket_UDPClient, () =>
            {
                udpClient = new UDPClient();
                udpClient.ServerIPPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7788);
                udpClient.Start();
                return udpClient;
            });

            KevSocketModel ksModel = new KevSocketModel()
            {
                DeviceId = KevRegister.Get(UDPPrimaryKey.Client_ThisDeviceId, -1),
                MessageId = IdGenerator.NextId(),
                MessageType = MessageType.Login,
                NetworkType = NetworkType.Request
            };
            if (!udpClient.SendMessage(ksModel))
            {
                MessageBox.Show("连接服务器失败，请稍后尝试");
            }
        }

        public void ShowAPrompt(object message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MessageDelegate(ShowAPrompt), new object[] { message });
            }
            else
            {
                MessageBox.Show((string)message);
            }
        }
    }
}
