using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
namespace Business.Concrete
{
    public class ColorManager : EfEntityManagerRepository<Color, IColorDal>,IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
            base._interface = _colorDal;
        }

        public Color GetColorById(int id)
        {
            return base._interface.Get(c => c.colorId == id);
        }
    }
}