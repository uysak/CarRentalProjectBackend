using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    
    /*
    public class InMemoryCarDal : ICarDal
    {
        List<Brand> _brands = new List<Brand>
        {

        };

        List<Color> _colors = new List<Color>
        {
            new Color(1,"Red"),
            new Color(2,"Yellow"),
            new Color(3,"Black"),
            new Color(4,"Blue")
        };

        List<Car> _cars = new List<Car>
        {
            new Car(1,1,3,2010,500,"Mercedes A180 1.5 Diesel"),
            new Car(2,2,3,2007,400,"BMW 1.16i 1.6 Petrol"),
            new Car(3,4,1,2012,300,"Renault Clio 1.5Dci Diesel")
        };

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.FirstOrDefault(c => car.carId == c.carId);

            _cars.Remove(carToDelete);
            

        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int Id)
        {
            return _cars.FirstOrDefault(c => c.carId == Id);
        }

        public void Update(Car car)
        {
            Car carToUpdate;

            carToUpdate = _cars.SingleOrDefault(c => c.carId == car.carId);

            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.ModelYear;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
    */
}
