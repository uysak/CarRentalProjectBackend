using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFuelTypeService
    {
        public IDataResult<List<FuelType>> GetAll();
        public IDataResult<FuelType> GetFuelTypeById(int id);
    }
}
