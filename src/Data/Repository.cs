using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Data.Dapper;
using Domain.Repositories;

namespace Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(object id)
        {
            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(SqlHelper.ConnectionString))
            {
                sqlConnection.Open();
                var post = sqlConnection.Query<TEntity>(string.Format(SqlHelper.ReadStatement, typeof(TEntity).Name), new { Id = (int)id }).SingleOrDefault();
                return post;
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(SqlHelper.ConnectionString))
            {
                sqlConnection.Open();
                var posts = sqlConnection.Query<TEntity>(string.Format(SqlHelper.ReadAllStatement, typeof(TEntity).Name));
                return posts.AsQueryable();
            }
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
