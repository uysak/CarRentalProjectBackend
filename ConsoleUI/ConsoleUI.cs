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

namespace ConsoleUI
{
    public class ConsoleUI
    {
        
        static void Main(string[] args)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CarManager carManager = new CarManager(new EfCarDal());

     //       carManager.Add( new Car{BrandId = 1, CarId = 1, DailyPrice = 700,Description = "test1"});

           // carManager.Add(new Car { BrandId = 1, CarId = 2, DailyPrice = 900,Description = "test2" });
            //
            Console.WriteLine(carManager.GetCarById(1).Description);
            Console.WriteLine(brandManager.GetBrandById(2).brandName);
        }
    }
}
