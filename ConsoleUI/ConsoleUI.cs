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

            Console.WriteLine(brandManager.GetBrandById(2).brandName);
        }
    }
}
