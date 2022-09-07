using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityServiceRepository<TEntity> where TEntity : class, IEntity, new()
    {
        public void Add(TEntity entity);
        public void Delete(TEntity entity);
        public void Update(TEntity entity);
        public List<TEntity> GetAll();
    }
}
