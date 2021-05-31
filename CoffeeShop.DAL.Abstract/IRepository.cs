using DAO.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(T entity);
        void Create(T entity);
        void Delete(int id);
        void Save();
    }
}
