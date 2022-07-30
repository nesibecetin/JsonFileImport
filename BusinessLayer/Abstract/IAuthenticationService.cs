using Business.Authentication;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthenticationService
    {
        Users Login(Users user);
        Users Register(Users user);
        Language GetUserCulture(Users users);
    }
}
