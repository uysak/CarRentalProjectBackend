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
       
        public static void Main(String[] args)
        {

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CarManager carManager = new CarManager(new EfCarDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = rentalManager.Rent(carManager.GetCarById(1).Data, customerManager.GetCustomerById(0).Data);
            Console.WriteLine(result.Message);

        }
        
    }
}
