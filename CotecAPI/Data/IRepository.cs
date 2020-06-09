using System.Collections.Generic;

namespace CotecAPI.Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetEntityById(int id);

    }
}