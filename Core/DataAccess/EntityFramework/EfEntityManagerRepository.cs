using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.DataAccess;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityManagerRepository<TEntity,TInterface>

        where TEntity : class,IEntity,new()
        where TInterface : class,IEntityRepository<TEntity>
    {

        public TInterface _interface;

        public void Add(TEntity entity)
        {
            _interface.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _interface.Delete(entity);
        }

        public List<TEntity> GetAll()
        {
            return _interface.GetAll();
        }

        public void Update(TEntity entity)
        {
            _interface.Update(entity);
        }

    }
}
