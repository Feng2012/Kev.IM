namespace Kev.IM.Client
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.textBox_passWord = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            this.label_userName = new System.Windows.Forms.Label();
            this.label_passWord = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_userName
            // 
            this.textBox_userName.BackColor = System.Drawing.Color.White;
            this.textBox_userName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_userName.Location = new System.Drawing.Point(185, 192);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(164, 14);
            this.textBox_userName.TabIndex = 0;
            // 
            // textBox_passWord
            // 
            this.textBox_passWord.BackColor = System.Drawing.Color.White;
            this.textBox_passWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_passWord.Location = new System.Drawing.Point(185, 233);
            this.textBox_passWord.Name = "textBox_passWord";
            this.textBox_passWord.PasswordChar = '*';
            this.textBox_passWord.Size = new System.Drawing.Size(164, 14);
            this.textBox_passWord.TabIndex = 1;
            // 
            // button_login
            // 
            this.button_login.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_login.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button_login.Location = new System.Drawing.Point(132, 285);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(196, 35);
            this.button_login.TabIndex = 2;
            this.button_login.Text = "登  录";
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.Location = new System.Drawing.Point(89, 192);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(41, 12);
            this.label_userName.TabIndex = 3;
            this.label_userName.Text = "账  号";
            // 
            // label_passWord
            // 
            this.label_passWord.AutoSize = true;
            this.label_passWord.Location = new System.Drawing.Point(89, 233);
            this.label_passWord.Name = "label_passWord";
            this.label_passWord.Size = new System.Drawing.Size(41, 12);
            this.label_passWord.TabIndex = 3;
            this.label_passWord.Text = "密  码";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(430, 332);
            this.Controls.Add(this.label_passWord);
            this.Controls.Add(this.label_userName);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.textBox_passWord);
            this.Controls.Add(this.textBox_userName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.TextBox textBox_passWord;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.Label label_passWord;

    }
}

