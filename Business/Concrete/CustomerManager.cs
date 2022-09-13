using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : EfEntityManagerRepository<Customer,ICustomerDal>,ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
            base._interface = _customerDal;
        }

        public IDataResult<Customer> GetCustomerById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.GetCustomerById(id));
        }
    }
}
