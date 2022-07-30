using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(Users users);
        List<Users> GetAll();
        Users GetByMail(string email);
        void Update(Users users);
    }
}
