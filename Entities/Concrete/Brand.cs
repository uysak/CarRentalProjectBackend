using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public Brand(int brandId, string brandName)
        {
            this.brandId = brandId;
            this.brandName = brandName;
        }

        public int brandId { get; set; }
        public string brandName { get; set; }
    }

}
