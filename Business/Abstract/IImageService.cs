using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IImageService : IEntityServiceRepository<Image>
    {
        public IDataResult<List<Image>> GetImagesByCarId(int carId);
        public IResult UploadImage(IFormFile file,int carId);
    }
}
