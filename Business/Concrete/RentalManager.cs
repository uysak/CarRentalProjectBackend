using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        private ICarService _carService;
        private IUserService _userService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, IUserService userService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _userService = userService;

        }


        [ValidationAspect(typeof(RentalValidator))]
        public IResult Rent(Rental rental)
        {
            var rentedCar = _carService.GetCarById(rental.CarID).Data;
            if (rentedCar.isAvailable == true)
            {
                _rentalDal.Rent(rental);
                return new SuccessResult("Araç Kiralandı");
            }
            else
            {
                return new ErrorResult(Messages.ErrorUnavailableCar);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult("Kayıt silindi.");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult("Kayıt güncellendi.");
        }

        public IResult ReturnCar(Rental rental)
        {
            var returnedCar = _carService.GetCarById(rental.CarID).Data;
            returnedCar.isAvailable = true;
            _carService.Update(returnedCar);
            rental.ReturnDate = DateTime.Now;
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.CarReturned);
        }

        public IResult CheckIfUserAlreadyHasRentedCar(int userId)
        {
            var result = _rentalDal.GetAll(u =>u.UserID == userId ).Any();
            if (result)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();
        }

    }
}
