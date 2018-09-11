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

        protected CRUDControllerBase(IDataService<T> dataService)
        {
            _dataService = dataService;
        }
        
        public virtual async Task<ActionResult> Create(T model)
        {
            var ret = await _dataService.Create(model);
            return Created($"{Request.Path}{ret.Id}",ret);
        }

        public virtual async Task<ActionResult> ReadAll()
        {
            return Json(await _dataService.ReadAll());
        }

        public virtual async Task<ActionResult> Read(int id)
        {
            return Json(await _dataService.ReadOne(id));
        }

        public virtual async Task<ActionResult> Update(T model, int id)
        {
            return Json(await _dataService.Update(model, id));
        }

        public virtual async Task<ActionResult> Delete(int id)
        {
            await _dataService.Delete(id);
            return Ok();
        }
    }
}