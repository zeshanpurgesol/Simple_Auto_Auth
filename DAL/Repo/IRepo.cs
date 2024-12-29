using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public interface IRepo<T> where T : class

    {
        IQueryable<T> GetAll(); 
        EntityList<T> GetAll(int page, int pageSize);
        Task<T?> Get(object id);
        Task<T> Insert(T item);

        Task<List<T>> InsertRange(List<T> item);
        Task<List<T>> DeleteRange(List<T> item);

        Task<T> Update(T item);

        Task<List<T>> UpdateRange(List<T> item);
        Task<T?> Delete(object id);
    }
}
