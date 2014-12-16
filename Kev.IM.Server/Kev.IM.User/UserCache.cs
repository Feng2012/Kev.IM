using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Kev.IM.User
{
    public static class UserCache
    {
        private static ConcurrentDictionary<long, UserModel> id_uModels = new ConcurrentDictionary<long, UserModel>();
        private static ConcurrentDictionary<string, long> name_uModels = new ConcurrentDictionary<string, long>();

        //public static UserModel Get(string userName, Func<UserModel> fun = null)
        //{

        //}

        public static UserModel Get(long id, Func<UserModel> fun = null)
        {
            UserModel uModel;
            if (id_uModels.TryGetValue(id, out uModel))
                return uModel;

            if (fun == null)
                return null;

            uModel = fun();

            if (uModel != null)
                id_uModels.TryAdd(id, uModel);

            return uModel;
        }

        public static void Update(long id, UserModel uModel)
        {
            UserModel tmp_uModel;

            if (id_uModels.ContainsKey(id))
                id_uModels.TryRemove(id, out tmp_uModel);

            id_uModels.TryAdd(id, uModel);
        }

        public static void Delete(long id)
        {
            UserModel uModel;
            id_uModels.TryRemove(id, out uModel);
        }
    }
}
