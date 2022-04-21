using HotelApril.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelApril.DAL.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        T Get(Func<T, bool> predicate);

        T Get(Guid id);

        List<T> All();

        List<T> Find(Func<T, bool> predicate);

        void CreateOrUpdate(T entity);

        Task<T> GetAsync(Func<T, bool> predicate);

        Task<T> GetAsync(Guid id);

        Task<List<T>> AllAsync();

        Task<List<T>> FindAsync(Func<T, bool> predicate);

        Task CreateOrUpdateAsync(T entity);



    }
}
