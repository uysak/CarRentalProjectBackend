using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using DateTime = System.DateTime;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        private ICarDal _carDal;

        public RentalManager(IRentalDal rentalDal, ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;

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

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult("Ürün silindi.");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult("Ürün güncellendi.");
        }

        public IResult ReturnCar(Rental rental)
        {
            var returnedCar = _carDal.GetCarById(rental.CarID);
            returnedCar.isAvailable = true;
            _carDal.Update(returnedCar);
            rental.ReturnDate = DateTime.Now;
            return new SuccessResult(Messages.CarReturned);
        }
    }
}
