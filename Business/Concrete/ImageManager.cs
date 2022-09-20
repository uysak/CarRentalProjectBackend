using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        private IImageDal _imageDal;
        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }
        
        public IResult Add(Image entity)
        {
            _imageDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Image entity)
        {
            FileHelper.DeleteFile(entity.ImagePath);
            _imageDal.Delete(entity);
            return new SuccessResult();
        }

        public IResult Update(Image entity)
        {

            _imageDal.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Image>> GetAll()
        {
            var result = _imageDal.GetAll();
            return new SuccessDataResult<List<Image>>(result);
        }

        public IResult CheckIfImageLimitExceeded(int carId)
        {
            var result = _imageDal.GetAll(i => i.CarID == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }

            return new SuccessResult();
        }

        public IDataResult<List<Image>> GetImagesByCarId(int carId)
        {
            var result = _imageDal.GetAll(i => i.CarID == carId);
            if (result.Count == 0)
            { 
                var defaultImage = _imageDal.GetAll(i => i.ImageID == 0);
            }
            return new SuccessDataResult<List<Image>>(result);
        }

        public IResult UploadImage(IFormFile file,int carId)
        {
            var check = BusinessRules.Run(CheckIfImageLimitExceeded(carId));

            if (!check.Success)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }

            var path = FileHelper.UploadFile(file);

            var result = Add(new Image
            {
                CarID = carId,
                Date = DateTime.Now,
                ImagePath = path
            });

            if (result.Success && path != null)
            {
                return new SuccessResult(result.Message);
            }

            return new ErrorResult(result.Message);

        }

   

    }
}
