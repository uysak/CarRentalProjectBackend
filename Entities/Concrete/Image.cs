using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Image : IEntity
    {
        public int ImageID { get; set; }
        public int CarID  { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
