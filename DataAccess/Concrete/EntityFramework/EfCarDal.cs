using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsContext>, ICarDal
    {
        public List<Car> GetCarsByBrandId(int id)
        {
            using (CarsContext context = new CarsContext())
            {
                return context.Set<Car>().Where(c => c.brandId == id).ToList();
            }
        }

        public List<Car> GetCarsByColorId(int id)
        {
            using (CarsContext context = new CarsContext())
            {
                return context.Set<Car>().Where(c => c.colorId == id).ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (CarsContext context = new CarsContext())
            {
                var result = from car in context.Cars
                    join brand in context.Brands on
                        car.brandId equals brand.brandId

                    join color in context.Colors on car.colorId equals color.colorId
                    select new CarDetailDto
                    {
                        Brand = brand.brandName,
                        Color = color.colorName,
                        dailyPrice = car.dailyPrice,
                        Description = car.Description,
                        modelYear = car.modelYear
                    };
                Console.WriteLine(result.ToList().Count);
                return result.ToList();


            }
        }
    }
}
