using DAL.DataContext;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly DatabaseContext dbContext;
        private readonly DbSet<T> entity;
        public Repo(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            entity = dbContext.Set<T>();
        }


        public async Task<T?> Delete(object id)
        {
            T? obj = entity.Find(id);
            if (obj != null)
            {
                entity.Remove(obj);
                await dbContext.SaveChangesAsync();
            }
            return obj;

        }
        public async Task<List<T>> DeleteRange(List<T> item)
        {

            entity.RemoveRange(item);
            await dbContext.SaveChangesAsync();
            return item;

        }

        public async Task<T?> Get(object id)
        {
            var obj = await entity.FindAsync(id);
            return obj;
        }
        public IQueryable<T> GetAll()
        {
            return entity;
        }

        public EntityList<T> GetAll(int page = 1, int pageSize = 10)
        {

            return new EntityList<T>
            {
                TotalCount = entity.Count(),
                List = entity.Skip((page - 1) * pageSize).Take(pageSize)
            };

        }

        public async Task<T> Insert(T item)
        {
            entity.Add(item);
            await dbContext.SaveChangesAsync();

            return item;

        }

        public async Task<List<T>> InsertRange(List<T> item)
        {
            entity.AddRange(item);
            await dbContext.SaveChangesAsync();

            return item;
        }

        public async Task<List<T>> UpdateRange(List<T> item)
        {
            entity.UpdateRange(item);
            await dbContext.SaveChangesAsync();

            return item;
        }

        public async Task<T> Update(T item)
        {
            entity.Update(item);
            await dbContext.SaveChangesAsync();

            return item;
        }
    }
}
