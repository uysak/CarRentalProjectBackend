using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entities;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        public void Rent(Rental rental);
    }
}
