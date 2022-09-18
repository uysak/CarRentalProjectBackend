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
        public void Rent(Rental rental)
        {
            base.Add(rental);

            using (CarsContext context = new CarsContext())
            {
                context.Set<Car>().SingleOrDefault(c => c.CarID == rental.CarID).isAvailable = false;
                context.SaveChanges();
            }

        }
    }
}
