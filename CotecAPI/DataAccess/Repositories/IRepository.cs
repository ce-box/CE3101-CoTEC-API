using System.Collections.Generic;

namespace CotecAPI.DataAccess.Repositories
{
    public interface IRepository<T,S> 
    where T: class
    where S: class
    {
        IEnumerable<S> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool SaveChanges();

    }
}