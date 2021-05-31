using DAL.Abstract;
using DAO.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CoffeeShop.DAL.Abstract
{
    public abstract class ParentRepository<TContext, TEntity> : IRepository<TEntity> where TEntity:class, IEntity
        where TContext: DbContext
    {
        protected readonly TContext context;

        public ParentRepository(TContext context)
        {
            this.context = context;
        }

        public void Create(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
        }
        public void Delete(int id)
        {
            var temp = this.Get(id);
            if (temp != null)
                this.context.Set<TEntity>().Remove(temp);
        }

        public TEntity Get(int id)
        {
            return this.context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.context.Set<TEntity>();
        }
        public IEnumerable<TEntity> ListEntities(Expression<Func<TEntity, bool>> expression)
        {
            return context.Set<TEntity>().Where(expression).ToList();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
        }
    }
}
