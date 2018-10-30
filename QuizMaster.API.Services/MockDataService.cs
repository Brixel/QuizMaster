using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizMaster.API.Data;
using QuizMaster.API.Services.Interfaces;
using QuizMaster.Shared.Extensions;
using QuizMaster.Shared.Models.Base;

namespace QuizMaster.API.Services
{
    public class DataService<T> : IDataService<T> where T : class, IModel
    {
        private readonly QuizContext _context;

        protected DataService(QuizContext context)
        {
            _context = context;
        }
        public async Task<T> CreateAsync(T model)
        {
            await _context.Set<T>().AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetOneAsync(int id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TProperty> GetPropertyAsync<TProperty>(int id, Func<T, TProperty> selector)
        {
            var item = await _context.Set<T>().SingleAsync(x => x.Id == id);
            return selector(item);
        }

        public async Task<T> UpdateAsync(T model, int id)
        {
            _context.Set<T>().Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Set<T>().SingleAsync(x => x.Id == id);
            _context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();
        }
    }

    public class MockDataService<T> : IDataService<T> where T : class, IModel
    {
        public MockDataService()
        {
            Data = new List<T>();
        }


        protected IList<T> Data { get; set; }


        public virtual Task<T> CreateAsync(T model)
        {
            model.Id = Data.Max(x => x.Id) + 1;
            Data.Add(model);
            return Task.FromResult(model);
        }

        public virtual Task<IEnumerable<T>> GetAllAsync()
            => Task.FromResult(Data as IEnumerable<T>);

        public virtual Task<T> GetOneAsync(int id)
            => Task.FromResult(Data.FirstOrDefault(x => x.Id == id));

        public virtual Task<TProperty> GetPropertyAsync<TProperty>(int id, Func<T, TProperty> selector)
            => Task.FromResult(Data
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault());

        public virtual Task<T> UpdateAsync(T model, int id)
        {
            var index = Data.FindIndex(x => x.Id == id);
            if (index == -1)
                return Task.FromResult(null as T);

            model.Id = id;
            Data[index] = model;

            return Task.FromResult(Data[index]);
        }

        public virtual Task DeleteAsync(int id)
            => Task.FromResult(Data.RemoveOne(x => x.Id == id));
    }
}