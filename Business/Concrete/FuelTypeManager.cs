using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FuelTypeManager : EfEntityManagerRepository<FuelType,IFuelTypeDal>,IFuelTypeService
    {

    }
}
