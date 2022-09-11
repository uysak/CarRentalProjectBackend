using Core.Entities;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityServiceRepository<TEntity> where TEntity : class, IEntity, new()
    {
        public IResult Add(TEntity entity);
        public IResult Delete(TEntity entity);
        public IResult Update(TEntity entity);
        public IDataResult<List<TEntity>> GetAll();

    }
}
