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
        
        public virtual async Task<ActionResult> CreateAsync(T model)
        {
            var ret = await _dataService.CreateAsync(model);
            return Created($"{Request.Path}{ret.Id}",ret);
        }

        public virtual async Task<ActionResult> GetAllAsync()
        {
            return Json(await _dataService.GetAllAsync());
        }

        public virtual async Task<ActionResult> GetOneAsync(int id)
        {
            return Json(await _dataService.GetOneAsync(id));
        }

        public virtual async Task<ActionResult> UpdateAsync(T model, int id)
        {
            return Json(await _dataService.UpdateAsync(model, id));
        }

        public virtual async Task<ActionResult> DeleteAsync(int id)
        {
            await _dataService.DeleteAsync(id);
            return Ok();
        }
    }
}