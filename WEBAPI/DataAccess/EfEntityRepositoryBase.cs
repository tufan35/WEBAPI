using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WEBAPI.Entities;

namespace WEBAPI.DataAccess
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : Context, new()
    {
        public void add(TEntity Entity)
        {
            using (TContext db = new TContext())
            {


                try
                {
                    var addedproduct = db.Entry(Entity);
                    addedproduct.State = EntityState.Added;
                    db.SaveChanges();
                    
                }
                catch (Exception)
                {

                    throw;
                }


            }
        }

        public void Delete(TEntity Entity)
        {
            using (TContext db = new TContext())
            {


                var deletedproduct = db.Entry(Entity);
                deletedproduct.State = EntityState.Deleted;
                db.SaveChanges();


            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new TContext()) {

                return db.Set<TEntity>().SingleOrDefault(filter);
            
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext db = new TContext())
            {
                return filter == null
                    ? db.Set<TEntity>().ToList()
                    : db.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity Entity)
        {
            using (TContext db = new TContext())
            {


                var updatedproduct = db.Entry(Entity);
                updatedproduct.State = EntityState.Modified;
                db.SaveChanges();


            }
        }
    }
}
