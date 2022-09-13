using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer,CarsContext>,ICustomerDal
    {
        public Customer GetCustomerById(int id)
        {
            using (CarsContext context = new CarsContext())
            {
                return context.Set<Customer>().SingleOrDefault(c => c.CustomerID == id);
            }
        }
    }
}
