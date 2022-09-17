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
    public interface IRentalService
    {
        public IResult Rent(Car car, Customer customer);
        public IResult Delete(Rental rental);
        public IDataResult<List<Rental>> GetAll();
        public IResult Update(Rental rental);
        public IResult ReturnCar(Rental rental);
    }
}
