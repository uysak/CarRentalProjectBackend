using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public short dailyPrice { get; set; }
        public short modelYear { get; set; }

    }
}
