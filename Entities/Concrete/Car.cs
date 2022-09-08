using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{

    public class Car : IEntity
    {

        public short carId { get; set; }
        public short brandId { get; set; }
        public short colorId { get; set; }
        public short modelYear { get; set; }
        public short dailyPrice { get; set; }
        public string Description { get; set; }

    }
}