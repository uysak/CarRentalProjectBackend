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
                    join fuelType in context.FuelTypes on
                        car.FuelID equals fuelType.FuelID

                    select new CarDetailDto
                    {
                        CarId = car.CarID,
                        Brand = brand.BrandName,
                        Color = color.ColorName,
                        DailyPrice = car.DailyPrice,
                        Description = car.Description,
                        ModelYear = car.ModelYear,
                        FuelType = fuelType.Fuel
                    };
               // Console.WriteLine(result.ToList().Count);
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
