using System.Collections.Generic;
using System.Threading.Tasks;
using QuizMaster.Shared.Models.Base;

namespace API.Services.Interfaces
{
    public interface IDataService<T> where T : IModel
    {
        Task<T> CreateAsync(T model);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetOneAsync(int id);
        Task<T> UpdateAsync(T model, int id);
        Task<bool> DeleteAsync(int id);
    }
}