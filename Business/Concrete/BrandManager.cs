using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Business.Concrete
{
    public class BrandManager : EfEntityManagerRepository<Brand, IBrandDal>, IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
            base._interface = _brandDal;
        }

        public IDataResult<Brand> GetBrandById(int id)
        {
           return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandID == id));
        }
    }
}
