namespace Kev.IM.Client
{
    partial class UserFriendItemUserControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label_NickName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_NickName
            // 
            this.label_NickName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_NickName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_NickName.Location = new System.Drawing.Point(5, 5);
            this.label_NickName.Name = "label_NickName";
            this.label_NickName.Size = new System.Drawing.Size(160, 22);
            this.label_NickName.TabIndex = 0;
            this.label_NickName.Text = "Nick Name";
            this.label_NickName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_NickName.Click += new System.EventHandler(this.label_NickName_Click);
            // 
            // UserFriendItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_NickName);
            this.Name = "UserFriendItemUserControl";
            this.Size = new System.Drawing.Size(170, 32);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label_NickName;

    }
}
