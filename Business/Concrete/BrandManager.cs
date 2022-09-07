using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;

namespace Business.Concrete
{
    public class BrandManager : EfEntityManagerRepository<Brand, IBrandDal>, IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public Brand GetBrandById(int id)
        {
           return _brandDal.Get(b => b.brandId == id);
        }
    }
}
