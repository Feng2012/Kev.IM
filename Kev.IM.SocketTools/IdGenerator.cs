using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kev.IM
{
    public static class IdGenerator
    {
        private static long lastTimeStamp;
        private static List<long> ids = new List<long>();

        /// <summary>
        /// 获取下一个Id
        /// </summary>
        /// <returns></returns>
        public static long NextId()
        {
            long id = 0;
            while (true)
            {
                long timeStamp = GetTimeStamp();
                if (timeStamp != lastTimeStamp)
                {
                    lastTimeStamp = timeStamp;
                }

                id = timeStamp * 1000 + new Random((int)DateTime.Now.Ticks).Next(999);

                lock (ids)
                {
                    if (!ids.Contains(id))
                    {
                        ids.Add(id);
                        break;
                    }
                }
            }
            return id;
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp()
        {
            return (DateTime.Now.Ticks - new DateTime(2014, 12, 10).Ticks) / 10000;
        }
    }
}
