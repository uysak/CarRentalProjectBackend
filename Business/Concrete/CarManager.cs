using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Business.Concrete;
using Core.DataAccess.EntityFramework;
namespace Business.Concrete
{
    public class CarManager : EfEntityManagerRepository<Car, ICarDal>, ICarService
    {

        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public Car GetCarById(int id)
        {
            return _carDal.Get(c => c.CarId == id);
        }
    }
}
