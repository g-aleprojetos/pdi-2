using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;

namespace Services.Interface
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : BaseEntity;
        Task<T> GetByIdAsync<T>(Guid id) where T : BaseEntity;
        Task<T> GetByLoginAsync<T>(string login) where T : User;
        Task<List<T>> ListAsync<T>() where T : BaseEntity;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;
        Task UpdateAsync<T>(T entity) where T : BaseEntity;
        Task DeleteAsync<T>(T entity) where T : BaseEntity;
        Task DeleteLogicAsync<T>(T entity) where T : BaseEntity;
    }
}
