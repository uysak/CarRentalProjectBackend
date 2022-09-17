using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IBrandService
    {
        public IDataResult<Brand> GetBrandById(int id);
        public IDataResult <List<Brand>> GetAll();
    }
}
