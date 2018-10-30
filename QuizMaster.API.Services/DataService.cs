using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizMaster.API.Data;
using QuizMaster.API.Services.Interfaces;
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
}