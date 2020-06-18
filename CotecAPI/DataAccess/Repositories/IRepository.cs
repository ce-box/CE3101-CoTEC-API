using System.Collections.Generic;

namespace CotecAPI.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetEntityById(int id);

    }
}