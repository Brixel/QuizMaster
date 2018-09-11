using System.Collections.Generic;
using System.Threading.Tasks;
using QuizMaster.Shared.Models.Base;

namespace API.Services.Interfaces
{
    public interface IDataService<T> where T : IModel
    {
        T Create(T model);
        Task<IEnumerable<T>> ReadAll();
        Task<T> ReadOne(int id);
        Task<T> Update(T model, int id);
        void Delete(int id);
    }
}