using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Business.Concrete;
using Entities.DTOs;

namespace ConsoleUI
{
    public class ConsoleUI
    {
        
        static void Main(string[] args)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager= new ColorManager(new EfColorDal());

            List<CarDetailDto> detailList = new List<CarDetailDto>();

            detailList = carManager.GetCarDetails();
            foreach (var car in detailList)
            {
                Console.WriteLine(car.Brand + " " + car.dailyPrice + " " + car.Color + " " + car.modelYear + " " + car.Description );
            }
            


        }
    }
}
