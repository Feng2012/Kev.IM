using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kev.IM.Client
{
    public partial class UserFriendItemUserControl : UserControl
    {
        public UserFriendItemUserControl()
        {
            InitializeComponent();
        }

        public int Index { get; set; }

        private void label_NickName_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, null);
        }
    }
}
