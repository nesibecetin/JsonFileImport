using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(Users users)
        {
            _userDal.Add(users);

        }

        public List<Users> GetAll()
        {
            var result = _userDal.GetAll();
            if(result == null)
            {
                throw new Exception("Kullanıcı bulunmamaktadır");
            }
            return result;
        }

        public Users GetByMail(string email)
        {
            var result = _userDal.Get(x => x.Email == email);
            if (result == null)
            {
                throw new Exception("Kullanıcı bulunmamaktadır");
            }
            return result;
        }

        public void Update(Users users)
        {
            _userDal.Update(users);
        }
    }
}
