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

            List<CarDetailDto> detailList = new List<CarDetailDto>();

            carManager.GetCarDetails();
        }
    }
}
