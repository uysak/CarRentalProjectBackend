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

        public short CarId { get; set; }
        public short BrandId { get; set; }
        public short ColorId { get; set; }
        public short ModelYear { get; set; }
        public short DailyPrice { get; set; }
        public string Description { get; set; }

    }
}