using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kev.Dao;

namespace Kev.IM.User
{
    [KevModel(AutoPrimaryKey = true, PrimaryKey = "Id", TableName = "Kev.IM.User")]
    public class UserModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string PassWord { get; set; }
    }
}
