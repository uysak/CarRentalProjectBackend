using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
namespace Business.Abstract
{
    public interface IBrandService : IEntityServiceRepository<Brand>
    {
        public Brand GetBrandById(int id);
    }
}
