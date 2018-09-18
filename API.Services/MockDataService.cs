using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services.Interfaces;
using QuizMaster.Shared.Extensions;
using QuizMaster.Shared.Models.Base;

namespace API.Services
{
    public class MockDataService<T> : IDataService<T> where T : class, IModel
    {
        public MockDataService()
        {
            Data = new List<T>();
        }


        private IList<T> Data { get; set; }


        public Task<T> CreateAsync(T model)
        {
            model.Id = Data.Max(x => x.Id) + 1;
            Data.Add(model);
            return Task.FromResult(model);
        }

        public Task<IEnumerable<T>> GetAllAsync()
            => Task.FromResult(Data as IEnumerable<T>);

        public Task<T> GetOneAsync(int id)
            => Task.FromResult(Data.FirstOrDefault(x => x.Id == id));

        public Task<TProperty> GetPropertyAsync<TProperty>(int id, Func<T, TProperty> selector)
            => Task.FromResult(Data
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault());

        public Task<T> UpdateAsync(T model, int id)
        {
            var index = Data.FindIndex(x => x.Id == id);
            if (index == -1)
                return Task.FromResult(null as T);

            model.Id = id;
            Data[index] = model;

            return Task.FromResult(Data[index]);
        }

        public Task<bool> DeleteAsync(int id)
            => Task.FromResult(Data.RemoveOne(x => x.Id == id));
    }
}