using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IColorService
    {
        public IDataResult<Color> GetColorById(int id);
        public IDataResult<List<Color>> GetAll();
    }
}
