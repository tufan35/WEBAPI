using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WEBAPI.Entities;

namespace WEBAPI.DataAccess
{
   public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);

    }
}
