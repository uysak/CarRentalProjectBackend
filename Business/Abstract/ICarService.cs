using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.DataAccess;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService : IEntityServiceRepository<Car>
    {
        public List<CarDetailDto> GetCarDetails();
    }
}
