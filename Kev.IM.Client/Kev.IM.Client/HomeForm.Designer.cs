namespace Kev.IM.Client
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_nickName = new System.Windows.Forms.Label();
            this.label_signature = new System.Windows.Forms.Label();
            this.label_loginStatus = new System.Windows.Forms.Label();
            this.panel_userInfo = new System.Windows.Forms.Panel();
            this.panel_bottomBox = new System.Windows.Forms.Panel();
            this.label_status = new System.Windows.Forms.Label();
            this.panel_messageBox = new System.Windows.Forms.Panel();
            this.panel_chatBox = new System.Windows.Forms.Panel();
            this.panel_promptBox = new System.Windows.Forms.Panel();
            this.label_message = new System.Windows.Forms.Label();
            this.richTextBox_recordMessage = new System.Windows.Forms.RichTextBox();
            this.panel_chatBox_bottomControl = new System.Windows.Forms.Panel();
            this.button_chatBox_sendMessage = new System.Windows.Forms.Button();
            this.button_chatBox_cancelMessage = new System.Windows.Forms.Button();
            this.textBox_chatBox_userInput = new System.Windows.Forms.TextBox();
            this.userFriendsListViewUserControl_friendList = new Kev.IM.Client.UserFriendsListViewUserControl();
            this.panel_userInfo.SuspendLayout();
            this.panel_bottomBox.SuspendLayout();
            this.panel_messageBox.SuspendLayout();
            this.panel_chatBox.SuspendLayout();
            this.panel_promptBox.SuspendLayout();
            this.panel_chatBox_bottomControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_nickName
            // 
            this.label_nickName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_nickName.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_nickName.Location = new System.Drawing.Point(11, 13);
            this.label_nickName.Name = "label_nickName";
            this.label_nickName.Size = new System.Drawing.Size(498, 28);
            this.label_nickName.TabIndex = 0;
            this.label_nickName.Text = "Nick Name";
            // 
            // label_signature
            // 
            this.label_signature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_signature.Location = new System.Drawing.Point(14, 52);
            this.label_signature.Name = "label_signature";
            this.label_signature.Size = new System.Drawing.Size(554, 14);
            this.label_signature.TabIndex = 1;
            this.label_signature.Text = "Signature";
            // 
            // label_loginStatus
            // 
            this.label_loginStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_loginStatus.AutoSize = true;
            this.label_loginStatus.Location = new System.Drawing.Point(527, 25);
            this.label_loginStatus.Name = "label_loginStatus";
            this.label_loginStatus.Size = new System.Drawing.Size(41, 12);
            this.label_loginStatus.TabIndex = 2;
            this.label_loginStatus.Text = "OnLine";
            // 
            // panel_userInfo
            // 
            this.panel_userInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel_userInfo.Controls.Add(this.label_nickName);
            this.panel_userInfo.Controls.Add(this.label_loginStatus);
            this.panel_userInfo.Controls.Add(this.label_signature);
            this.panel_userInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_userInfo.Location = new System.Drawing.Point(0, 0);
            this.panel_userInfo.Name = "panel_userInfo";
            this.panel_userInfo.Size = new System.Drawing.Size(582, 81);
            this.panel_userInfo.TabIndex = 3;
            // 
            // panel_bottomBox
            // 
            this.panel_bottomBox.BackColor = System.Drawing.SystemColors.Control;
            this.panel_bottomBox.Controls.Add(this.label_status);
            this.panel_bottomBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottomBox.Location = new System.Drawing.Point(0, 537);
            this.panel_bottomBox.Name = "panel_bottomBox";
            this.panel_bottomBox.Size = new System.Drawing.Size(582, 25);
            this.panel_bottomBox.TabIndex = 4;
            // 
            // label_status
            // 
            this.label_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_status.Location = new System.Drawing.Point(14, 7);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(554, 12);
            this.label_status.TabIndex = 0;
            // 
            // panel_messageBox
            // 
            this.panel_messageBox.Controls.Add(this.panel_chatBox);
            this.panel_messageBox.Controls.Add(this.panel_promptBox);
            this.panel_messageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_messageBox.Location = new System.Drawing.Point(133, 81);
            this.panel_messageBox.Name = "panel_messageBox";
            this.panel_messageBox.Size = new System.Drawing.Size(449, 456);
            this.panel_messageBox.TabIndex = 6;
            // 
            // panel_chatBox
            // 
            this.panel_chatBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_chatBox.Controls.Add(this.textBox_chatBox_userInput);
            this.panel_chatBox.Controls.Add(this.panel_chatBox_bottomControl);
            this.panel_chatBox.Controls.Add(this.richTextBox_recordMessage);
            this.panel_chatBox.Location = new System.Drawing.Point(0, 0);
            this.panel_chatBox.Name = "panel_chatBox";
            this.panel_chatBox.Size = new System.Drawing.Size(449, 456);
            this.panel_chatBox.TabIndex = 2;
            this.panel_chatBox.Visible = false;
            // 
            // panel_promptBox
            // 
            this.panel_promptBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_promptBox.Controls.Add(this.label_message);
            this.panel_promptBox.Location = new System.Drawing.Point(0, 0);
            this.panel_promptBox.Name = "panel_promptBox";
            this.panel_promptBox.Size = new System.Drawing.Size(449, 456);
            this.panel_promptBox.TabIndex = 1;
            this.panel_promptBox.Visible = false;
            // 
            // label_message
            // 
            this.label_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_message.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_message.Location = new System.Drawing.Point(73, 107);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(331, 75);
            this.label_message.TabIndex = 0;
            this.label_message.Text = "选一个人开始聊天吧";
            this.label_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox_recordMessage
            // 
            this.richTextBox_recordMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_recordMessage.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_recordMessage.Name = "richTextBox_recordMessage";
            this.richTextBox_recordMessage.Size = new System.Drawing.Size(449, 456);
            this.richTextBox_recordMessage.TabIndex = 0;
            this.richTextBox_recordMessage.Text = "";
            // 
            // panel_chatBox_bottomControl
            // 
            this.panel_chatBox_bottomControl.Controls.Add(this.button_chatBox_cancelMessage);
            this.panel_chatBox_bottomControl.Controls.Add(this.button_chatBox_sendMessage);
            this.panel_chatBox_bottomControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_chatBox_bottomControl.Location = new System.Drawing.Point(0, 420);
            this.panel_chatBox_bottomControl.Name = "panel_chatBox_bottomControl";
            this.panel_chatBox_bottomControl.Size = new System.Drawing.Size(449, 36);
            this.panel_chatBox_bottomControl.TabIndex = 2;
            // 
            // button_chatBox_sendMessage
            // 
            this.button_chatBox_sendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_chatBox_sendMessage.Location = new System.Drawing.Point(362, 7);
            this.button_chatBox_sendMessage.Name = "button_chatBox_sendMessage";
            this.button_chatBox_sendMessage.Size = new System.Drawing.Size(75, 23);
            this.button_chatBox_sendMessage.TabIndex = 0;
            this.button_chatBox_sendMessage.Text = "Send";
            this.button_chatBox_sendMessage.UseVisualStyleBackColor = true;
            this.button_chatBox_sendMessage.Click += new System.EventHandler(this.button_chatBox_sendMessage_Click);
            // 
            // button_chatBox_cancelMessage
            // 
            this.button_chatBox_cancelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_chatBox_cancelMessage.Location = new System.Drawing.Point(281, 7);
            this.button_chatBox_cancelMessage.Name = "button_chatBox_cancelMessage";
            this.button_chatBox_cancelMessage.Size = new System.Drawing.Size(75, 23);
            this.button_chatBox_cancelMessage.TabIndex = 0;
            this.button_chatBox_cancelMessage.Text = "Cancel";
            this.button_chatBox_cancelMessage.UseVisualStyleBackColor = true;
            this.button_chatBox_cancelMessage.Click += new System.EventHandler(this.button_chatBox_cancelMessage_Click);
            // 
            // textBox_chatBox_userInput
            // 
            this.textBox_chatBox_userInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_chatBox_userInput.Location = new System.Drawing.Point(0, 354);
            this.textBox_chatBox_userInput.Multiline = true;
            this.textBox_chatBox_userInput.Name = "textBox_chatBox_userInput";
            this.textBox_chatBox_userInput.Size = new System.Drawing.Size(449, 66);
            this.textBox_chatBox_userInput.TabIndex = 3;
            // 
            // userFriendsListViewUserControl_friendList
            // 
            this.userFriendsListViewUserControl_friendList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.userFriendsListViewUserControl_friendList.ClickItemDelegate = null;
            this.userFriendsListViewUserControl_friendList.Dock = System.Windows.Forms.DockStyle.Left;
            this.userFriendsListViewUserControl_friendList.Location = new System.Drawing.Point(0, 81);
            this.userFriendsListViewUserControl_friendList.Name = "userFriendsListViewUserControl_friendList";
            this.userFriendsListViewUserControl_friendList.Size = new System.Drawing.Size(133, 456);
            this.userFriendsListViewUserControl_friendList.TabIndex = 5;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 562);
            this.Controls.Add(this.panel_messageBox);
            this.Controls.Add(this.userFriendsListViewUserControl_friendList);
            this.Controls.Add(this.panel_bottomBox);
            this.Controls.Add(this.panel_userInfo);
            this.MinimumSize = new System.Drawing.Size(300, 600);
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomeForm_FormClosed);
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.panel_userInfo.ResumeLayout(false);
            this.panel_userInfo.PerformLayout();
            this.panel_bottomBox.ResumeLayout(false);
            this.panel_messageBox.ResumeLayout(false);
            this.panel_chatBox.ResumeLayout(false);
            this.panel_chatBox.PerformLayout();
            this.panel_promptBox.ResumeLayout(false);
            this.panel_chatBox_bottomControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_userInfo;
        public System.Windows.Forms.Label label_nickName;
        public System.Windows.Forms.Label label_signature;
        public System.Windows.Forms.Label label_loginStatus;
        private System.Windows.Forms.Panel panel_bottomBox;
        public System.Windows.Forms.Label label_status;
        private UserFriendsListViewUserControl userFriendsListViewUserControl_friendList;
        private System.Windows.Forms.Panel panel_messageBox;
        private System.Windows.Forms.Panel panel_promptBox;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Panel panel_chatBox;
        private System.Windows.Forms.RichTextBox richTextBox_recordMessage;
        private System.Windows.Forms.Panel panel_chatBox_bottomControl;
        private System.Windows.Forms.Button button_chatBox_cancelMessage;
        private System.Windows.Forms.Button button_chatBox_sendMessage;
        private System.Windows.Forms.TextBox textBox_chatBox_userInput;
    }
}