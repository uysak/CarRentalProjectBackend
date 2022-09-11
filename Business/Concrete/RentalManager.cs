using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : EfEntityManagerRepository<Rental,IRentalDal>,IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
            base._interface = _rentalDal;
        }


        public IResult Rent(Car car, Customer customer)
        {
            if (car.isAvailable == true)
            {
                _rentalDal.Rent(car,customer);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.ErrorUnavailableCar);
            }
        }
    }
}
