using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kev.Dao
{
    [AttributeUsage(AttributeTargets.Class)]
    public class KevModelAttribute : Attribute
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey { get; set; }

        /// <summary>
        /// 主键自增长
        /// </summary>
        public bool AutoPrimaryKey { get; set; }

        /// <summary>
        /// 表明
        /// </summary>
        public string TableName { get; set; }
    }
}
