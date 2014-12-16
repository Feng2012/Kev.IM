using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kev.IM.Client
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();

            userFriendsListViewUserControl_friendList.ClickItemDelegate = new UserFriendsListViewUserControl.ClickDelegate(ClickFriend);
        }

        private long _chatUserId = -1;

        public long ChatUserId { get { return _chatUserId; } }

        public List<UserInfoModel> uiModels = new List<UserInfoModel>();

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            panel_promptBox.Show();
            panel_chatBox.Hide();
        }

        private void ClickFriend(int index)
        {
            if (index >= uiModels.Count)
            {
                label_status.Text = "这个人神秘失踪了，我找不到他的资料";
                return;
            }

            UserInfoModel uiModel = uiModels[index];
            if (uiModel == null)
            {
                label_status.Text = "这个人神秘失踪了，我找不到他的资料";
                return;
            }

            _chatUserId = uiModel.UserId;

            panel_chatBox.Show();
            panel_promptBox.Hide();

            //MessageBox.Show(uiModel.UserId + "");
        }

        public void AddUser(UserInfoModel uiModel, bool isRedrawView = true)
        {
            long id = KevRegister.Get<long>(UDPPrimaryKey.Client_ThisDeviceId, -1);
            if (uiModel.UserId == id)
                return;

            uiModels.Add(uiModel);

            if (isRedrawView)
                RedrawViewByUserInfoModels(uiModels);
        }

        public void AddUserRange(IEnumerable<UserInfoModel> items)
        {
            if (items == null || items.Count() == 0)
                return;

            int count = 0;

            long id = KevRegister.Get<long>(UDPPrimaryKey.Client_ThisDeviceId, -1);

            foreach (UserInfoModel uiModel in items)
            {
                if (uiModel.UserId == id)
                    continue;

                uiModels.Add(uiModel);
                count++;
            }

            if (count > 0)
                RedrawViewByUserInfoModels(uiModels);
        }

        private void RedrawViewByUserInfoModels(IEnumerable<UserInfoModel> items)
        {
            this.userFriendsListViewUserControl_friendList.RemoveAll(false);

            foreach (UserInfoModel item in items)
            {
                UserFriendItemUserControl ufiuc = new UserFriendItemUserControl();
                ufiuc.label_NickName.Text = item.NickName;
                this.userFriendsListViewUserControl_friendList.Add(ufiuc, false);
            }

            this.userFriendsListViewUserControl_friendList.RedrawItemsView();
        }

        private void button_chatBox_sendMessage_Click(object sender, EventArgs e)
        {
            long selfUserId = KevRegister.Get<long>(UDPPrimaryKey.Client_ThisDeviceId, -1);

            KevSocketModel<ChatTextMessageModel> ksModel_ctmModel = new KevSocketModel<ChatTextMessageModel>()
            {
                Data = new ChatTextMessageModel
                {
                    Message = this.textBox_chatBox_userInput.Text
                },
                DeviceId = selfUserId,
                MessageId = IdGenerator.NextId(),
                MessageType = MessageType.ChatTextMessage,
                NetworkType = NetworkType.Request,
                ReceiveDeviceId = this.ChatUserId
            };

            AddMessageToView("我", this.textBox_chatBox_userInput.Text);

            if (KevRegister.Get<UDPClient>(UDPPrimaryKey.UDPClient).SendMessage(ksModel_ctmModel))
                this.textBox_chatBox_userInput.Text = string.Empty;
        }

        private void button_chatBox_cancelMessage_Click(object sender, EventArgs e)
        {
            this.textBox_chatBox_userInput.Text = string.Empty;
        }

        internal void HandleMessage(ChatMessageModel chatMessageModel)
        {
            UserInfoModel uiModel = UserCache.Get(chatMessageModel.SendUserId, () =>
            {
                return new UserInfoModel
                {
                    NickName = "神秘人",
                    Signature = "木有签名",
                    UserId = chatMessageModel.ReceiveUserId
                };
            });

            if (chatMessageModel is ChatTextMessageModel)
            {
                ChatTextMessageModel ctmModel = chatMessageModel as ChatTextMessageModel;
                AddMessageToView(uiModel.NickName, ctmModel.Message);
            }
        }

        private void AddMessageToView(string nickName, string message)
        {
            this.richTextBox_recordMessage.AppendText(string.Format("\r\n{0}说：\r\n  {1}", nickName, message));
        }
    }
}
