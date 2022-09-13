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
                return context.Set<Car>().Where(c => c.BrandID == id).ToList();
            }
        }

        public List<Car> GetCarsByColorId(int id)
        {
            using (CarsContext context = new CarsContext())
            {
                return context.Set<Car>().Where(c => c.ColorID == id).ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (CarsContext context = new CarsContext())
            {
                var result = from car in context.Cars

                    join brand in context.Brands on
                        car.BrandID equals brand.BrandID
                    join color in context.Colors on 
                        car.ColorID equals color.ColorID
                    
                    select new CarDetailDto
                    {
                        Brand = brand.BrandName,
                        Color = color.ColorName,
                        dailyPrice = car.DailyPrice,
                        Description = car.Description,
                        modelYear = car.ModelYear
                    };
                Console.WriteLine(result.ToList().Count);
                return result.ToList();

            }
        }

        public Car GetCarById(int id)
        {
            using (CarsContext context = new CarsContext())
            {
                return context.Set<Car>().SingleOrDefault(c => c.CarID == id);
            }
        }
    }
}
