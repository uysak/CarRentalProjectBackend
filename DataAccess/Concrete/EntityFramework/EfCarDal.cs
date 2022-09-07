using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsContext>, ICarDal
    {
        public List<Car> GetCarsByBrandId(int id)
        {
            using(CarsContext context = new CarsContext())
            {
                return context.Set<Car>().Where( c => c.BrandId == id).ToList();
            }
        }

        public List<Car> GetCarsByColorId(int id)
        {
            using(CarsContext context = new CarsContext())
            {
                return context.Set<Car>().Where(c => c.ColorId == id).ToList();
            }
        }
    }
}
