using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService : IEntityServiceRepository<User>
    {
        public IDataResult<User> GetUserById(int id);
    }
}
