namespace Kev.IM.Client
{
    partial class UserFriendsListViewUserControl
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
            this.panel_box = new System.Windows.Forms.Panel();
            this.vScrollBar_box = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // panel_box
            // 
            this.panel_box.Location = new System.Drawing.Point(0, 0);
            this.panel_box.Name = "panel_box";
            this.panel_box.Size = new System.Drawing.Size(250, 426);
            this.panel_box.TabIndex = 0;
            // 
            // vScrollBar_box
            // 
            this.vScrollBar_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar_box.Location = new System.Drawing.Point(250, 3);
            this.vScrollBar_box.Name = "vScrollBar_box";
            this.vScrollBar_box.Size = new System.Drawing.Size(10, 420);
            this.vScrollBar_box.TabIndex = 0;
            // 
            // UserFriendsListViewUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vScrollBar_box);
            this.Controls.Add(this.panel_box);
            this.Name = "UserFriendsListViewUserControl";
            this.Size = new System.Drawing.Size(260, 426);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_box;
        private System.Windows.Forms.VScrollBar vScrollBar_box;
    }
}
