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
    public partial class UserFriendsListViewUserControl : UserControl
    {
        private List<UserFriendItemUserControl> ufiUserControls = new List<UserFriendItemUserControl>();
        private bool dataIsChange = true;
        private const int itemHeight = 32;

        public delegate void ClickDelegate(int index);

        /// <summary>
        /// 内容项点击事件
        /// </summary>
        public ClickDelegate ClickItemDelegate { get; set; }

        public UserFriendsListViewUserControl()
        {
            InitializeComponent();

            this.RedrawItemsView();
            this.vScrollBar_box.ValueChanged += vScrollBar_box_ValueChanged;
        }

        void vScrollBar_box_ValueChanged(object sender, EventArgs e)
        {
            ScrollBar scrollBar = sender as ScrollBar;
            if (scrollBar == null)
                return;

            panel_box.Location = new Point(0, scrollBar.Value * -5);

            KevRegister.Get<HomeForm>(ClientItemsPrimaryKey.Form_Home).label_loginStatus.Text = scrollBar.Value.ToString();
        }

        /// <summary>
        /// 添加内容项
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isRedrawView">是否立即刷新界面</param>
        public void Add(UserFriendItemUserControl item, bool isRedrawView = true)
        {
            ufiUserControls.Add(item);
            dataIsChange = true;

            item.Click += item_Click;

            if (isRedrawView)
                this.RedrawItemsView();
        }

        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="isRedrawView"></param>
        public void RemoveAt(int index, bool isRedrawView = true)
        {
            if (ufiUserControls.Count > index)
                ufiUserControls.RemoveAt(index);

            if (isRedrawView)
                RedrawItemsView();
        }

        /// <summary>
        /// 移除所有元素
        /// </summary>
        /// <param name="isRedrawView"></param>
        public void RemoveAll(bool isRedrawView = true)
        {
            ufiUserControls.Clear();

            if (isRedrawView)
                RedrawItemsView();
        }

        void item_Click(object sender, EventArgs e)
        {
            if (this.ClickItemDelegate != null)
                this.ClickItemDelegate(((UserFriendItemUserControl)sender).Index);
        }

        /// <summary>
        /// 将某一项移动到最顶端
        /// </summary>
        /// <param name="index"></param>
        public void MoveItemToTop(int index)
        {
            if (index <= 0)
                return;

            if (ufiUserControls.Count <= index)
                return;

            if (ufiUserControls.Count <= 1)
                return;

            UserFriendItemUserControl ufiItem = ufiUserControls[index];
            ufiUserControls.RemoveAt(index);
            ufiUserControls.Insert(0, ufiItem);

            dataIsChange = true;

            this.RedrawItemsView();
        }

        /// <summary>
        /// 重绘界面
        /// </summary>
        public void RedrawItemsView()
        {
            do
            {
                if (!dataIsChange)
                    break;

                lock (this)
                {
                    dataIsChange = false;

                    panel_box.Controls.Clear();

                    UserFriendItemUserControl[] items = ufiUserControls.ToArray();

                    Size _size = panel_box.Size;
                    _size.Height = items.Length * itemHeight;
                    bool isScroll = _size.Height > this.Height;
                    _size.Width = isScroll ? this.Width - 10 : this.Width;

                    if (isScroll) { vScrollBar_box.Show(); } else { vScrollBar_box.Hide(); }
                    if (isScroll)
                        vScrollBar_box.Maximum = (_size.Height - this.Size.Height) / 5 + vScrollBar_box.LargeChange;

                    panel_box.Size = _size;

                    if (items.Length == 0)
                        break;

                    for (int i = 0; i < items.Length; i++)
                    {
                        UserFriendItemUserControl item = items[i];
                        item.Location = new Point(0, i * itemHeight);
                        item.Size = new Size(panel_box.Width, itemHeight);
                        item.Index = i;
                        panel_box.Controls.Add(item);
                    }
                }
            } while (false);
        }
    }
}
