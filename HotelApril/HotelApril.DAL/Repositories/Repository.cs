using HotelApril.DAL.Data;
using HotelApril.DAL.Entities;
using HotelApril.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApril.DAL
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DataContext _databaseContext;

        public Repository(DataContext context)
        {
            _databaseContext = context;
        }

        public List<T> All()
        {
            return _databaseContext.Set<T>().ToList();
        }

        public async Task<List<T>> AllAsync()
        {
            return await Task.FromResult(_databaseContext.Set<T>().ToList());
        }

        public void CreateOrUpdate(T entity)
        {
            if (entity.Id != Guid.Empty)
            {
               _databaseContext.Set<T>().Update(entity);
            }
            else
            {
                _databaseContext.Add(entity);
            }
            _databaseContext.SaveChanges();
        }

        public async Task CreateOrUpdateAsync(T entity)
        {
            if (entity.Id != Guid.Empty)
            {
                _databaseContext.Set<T>().Update(entity);
            }
            else
            {
                _databaseContext.Add(entity);
            }
            await _databaseContext.SaveChangesAsync();
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            return _databaseContext.Set<T>().Where(predicate).ToList();
        }

        public async Task<List<T>> FindAsync(Func<T, bool> predicate)
        {
            return await Task.FromResult(_databaseContext.Set<T>().Where(predicate).ToList());
        }

        public T Get(Func<T, bool> predicate)
        {
            return _databaseContext.Set<T>().FirstOrDefault(predicate);
        }

        public T Get(Guid id)
        {
            return _databaseContext.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public async Task<T> GetAsync(Func<T, bool> predicate)
        {
            return await Task.FromResult(_databaseContext.Set<T>().FirstOrDefault(predicate));
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await Task.FromResult(_databaseContext.Set<T>().FirstOrDefault(e => e.Id == id));
        }

    }
}
