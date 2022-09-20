using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Business.Concrete;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.DTOs;
using Core.Entities;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarManager :  ICarService
    {

        ICarDal _carDal;
        private IImageService _imageService;
        public CarManager(ICarDal carDal,IImageService imageService)
        {
            _carDal = carDal;
            _imageService = imageService;
        }

        public IDataResult<Car> GetCarById(int carId)
        {
            BusinessRules.Run(CheckIfCarExist(carId));
            return new SuccessDataResult<Car>(_carDal.GetCarById(carId));
        }

        public SuccessDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidator))]
        public virtual IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult("Araba eklendi.");
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Araba silindi.");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IResult Update(Car car)
        {
            BusinessRules.Run(CheckIfCarExist(car.CarID));
            _carDal.Update(car);
            return new SuccessResult("Araba güncellendi.");
        }

        public IResult CheckIfCarExist(int carId)
        {
            var result = _carDal.GetAll(c => c.CarID == carId).Any();
            if (result)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.CarIsNotExist);
        }

    }
}
