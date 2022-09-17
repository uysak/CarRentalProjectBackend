using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string FuelType { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public short DailyPrice { get; set; }
        public short ModelYear { get; set; }

    }
}
