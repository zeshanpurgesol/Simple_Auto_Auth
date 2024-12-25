using ApplicationLayer.IRepo;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repo
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly AppDataContext dbContext;
        private readonly DbSet<T> entity;

        public Repo(AppDataContext dbContext, DbSet<T> entity)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.entity = entity;
        }

        public async Task<T?> Delete(object id)
        {
            T? obj = entity.Find(id);
            if (obj != null)
            {
                entity.Remove(obj);
                dbContext.SaveChangesAsync();
            }
            return obj;
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

        public async Task<T> Insert(T item)
        {
            entity.Add(item);
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

    public class TempRepo<T> : IRepo<T> where T : class
    {
        private readonly List<T> _items = new();

        public async Task<T?> Delete(object id)
        {
            var item = await Get(id);
            if (item != null)
            {
                _items.Remove(item);
            }
            return item;
        }

        public async Task<T?> Get(object id)
        {
            // Assuming that 'id' is a property of type 'int' in the class with a name 'Id'.
            // Adjust this method according to your actual ID property and its type.
            var item = _items.FirstOrDefault(i => ((dynamic)i).Id == id);
            return await Task.FromResult(item);
        }

        public IQueryable<T> GetAll()
        {
            return _items.AsQueryable();
        }

        public async Task<T> Insert(T item)
        {
            _items.Add(item);
            return await Task.FromResult(item);
        }

        public async Task<T> Update(T item)
        {
            var existingItem = await Get(((dynamic)item).Id);
            if (existingItem != null)
            {
                var index = _items.IndexOf(existingItem);
                if (index != -1)
                {
                    _items[index] = item;
                }
            }
            return await Task.FromResult(item);
        }
    }
}
