using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Domain.Models;
using Domain.Repositories;

namespace EFData
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity:class
    {

        #region DI
        protected PHeartDbContext Context = null;

        public Repository()
        {
            Context = new PHeartDbContext();
        }

        //public Repository(PHeartDbContext context)
        //{
        //    Context = context;
        //} 
        #endregion

        protected DbSet<TEntity> DbSet
        {
            get { return Context.Set<TEntity>(); }
        }

        #region Implementation of IRepository<TEntity>

        //C
        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        //R
        public TEntity Get(object id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = DbSet;
            return query;
        }

        //U
        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        //D
        public void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if(Context.Entry(entity).State==EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        //public IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        //{
        //    return DbSet.SqlQuery(query, parameters).ToList();
        //}

        #endregion
    }
}
