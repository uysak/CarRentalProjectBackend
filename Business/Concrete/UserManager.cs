using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userdal)
        {
            _userDal = userdal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public virtual IResult Add(User user)
        {

            BusinessRules.Run(CheckIfUserExits(user.Email));
            _userDal.Add(user);
            return new SuccessResult("Kullanıcı eklendi.");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("Kullanıcı silindi.");
        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetUserById(int id)
        {
            BusinessRules.Run(CheckIfUserExits(id));
            var result = _userDal.Get(u => u.UserID == id);
            return new SuccessDataResult<User>(result);
        }

        public IResult Update(User user)
        {;
            _userDal.Update(user);
            return new SuccessResult("Kullanıcı güncellendi.");
        }
        public IResult CheckIfUserExits(string email)
        {
            var result = _userDal.GetAll(u => u.Email == email).Any();
            if (!result)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();
        }
        public IResult CheckIfUserExits(int id)
        {
            var result = _userDal.GetAll(u => u.UserID == id).Any();
            if (!result)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
