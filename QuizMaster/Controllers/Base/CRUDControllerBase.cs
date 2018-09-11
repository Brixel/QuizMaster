using System;
using System.Threading.Tasks;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.Shared.Models.Base;

namespace QuizMaster.Controllers.Base
{
    public abstract class CRUDControllerBase<T> : Controller where T : IModel
    {
        protected readonly IDataService<T> _dataService;

        public CRUDControllerBase(IDataService<T> dataService)
        {
            _dataService = dataService;
        }
        public virtual async Task<ActionResult> Create(T model)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ActionResult> Read(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ActionResult> Update(T model, int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}