using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity:class 
    {
        //Create
        void Insert(TEntity entity);

        //Read
        TEntity Get(object id);
        IQueryable<TEntity> GetAll();

        //Update
        void Update(TEntity entity);

        //Delete
        void Delete(object id);
        void Delete(TEntity entity);
    }
}
