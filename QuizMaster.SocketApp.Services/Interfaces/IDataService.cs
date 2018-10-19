using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizMaster.Shared.Models.Base;

namespace QuizMaster.SocketApp.Services.Interfaces
{
    public interface IDataService<T> where T : IModel
    {
        Task<T> CreateAsync(T model);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetOneAsync(int id);
        Task<TProperty> GetPropertyAsync<TProperty>(int id, Func<T, TProperty> selector);
        Task<T> UpdateAsync(T model, int id);
        Task<bool> DeleteAsync(int id);
    }
}