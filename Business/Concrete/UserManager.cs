using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : EfEntityManagerRepository<User,IUserDal>,IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userdal)
        {
            _userDal = userdal;
            base._interface = _userDal;
        }
    }
}
