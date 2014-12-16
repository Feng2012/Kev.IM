using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kev.Dao
{
    [AttributeUsage(AttributeTargets.Property)]
    public class KevDataMemberAttribute : Attribute
    {
        /// <summary>
        /// 表属性名
        /// </summary>
        public string TableFieldName { get; set; }
    }
}
