using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;



namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,CarsContext>,IRentalDal
    {
        public void Rent(Car car, Customer customer)
        {
            var rental = new Rental();

            rental.CarID = car.CarID;
            rental.CustomerID = customer.CustomerID;
            rental.RentDate = DateTime.Now;
            rental.ReturnDate = DateTime.Today;

            base.Add(rental);

            using (CarsContext context = new CarsContext())
            {
                context.Set<Car>().SingleOrDefault(c => c.CarID == car.CarID).isAvailable = false;
                context.SaveChanges();
            }

        }
    }
}
