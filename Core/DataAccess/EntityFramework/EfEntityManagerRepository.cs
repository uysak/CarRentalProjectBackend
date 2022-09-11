using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.DataAccess;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityManagerRepository<TEntity,TInterface> 

        where TEntity : class,IEntity,new()
        where TInterface : class,IEntityRepository<TEntity>
    {

        public TInterface _interface;

        public virtual IResult Add(TEntity entity)
        {
            _interface.Add(entity); 
            return new SuccessResult("Ürün eklendi.");
        }

        public IResult Delete(TEntity entity)
        {
            _interface.Delete(entity);
            return new SuccessResult("Ürün silindi.");
        }

        public IDataResult<List<TEntity>> GetAll()
        {
            return new SuccessDataResult<List<TEntity>>(_interface.GetAll());
        }

        public IResult Update(TEntity entity)
        {
            return new SuccessResult("Ürün güncellendi.");
        }

    }
}
