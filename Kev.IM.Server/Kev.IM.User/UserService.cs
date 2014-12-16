using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kev.Dao;

namespace Kev.IM.User
{
    public class UserService
    {
        private KevProvider<UserModel> _provider;

        public bool Insert(UserModel model)
        {
            return _provider.Insert(model);
        }

        public UserModel Get(long id)
        {
            return UserCache.Get(id, () =>
            {
                return _provider.Get(id);
            });
        }

        //public UserModel Get(string UserName)
        //{
        //    return UserCache.Get();
        //}

        public bool Update(UserModel model)
        {
            UserCache.Delete(model.Id);
            return _provider.Update(model);
        }

        public bool Delete(long id)
        {
            UserCache.Delete(id);
            return _provider.Delete(id);
        }

        private KevProvider<UserModel> GetProvider()
        {
            if (_provider == null)
                _provider = new KevProvider<UserModel>();

            return _provider;
        }
    }
}
