using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepo
{
    public interface IRepo<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T?> Get(object id);
        Task<T> Insert(T item);
        Task<T> Update(T item);
        Task<T?> Delete(object id);
    }
}
