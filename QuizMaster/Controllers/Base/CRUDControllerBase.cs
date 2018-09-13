using System.Threading.Tasks;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.Shared.Models.Base;

namespace QuizMaster.Controllers.Base
{
    public abstract class CRUDControllerBase<T> : Controller where T : IModel
    {
        protected readonly IDataService<T> DataService;

        protected CRUDControllerBase(IDataService<T> dataService)
        {
            DataService = dataService;
        }

        public virtual async Task<ActionResult> CreateAsync(T model)
        {
            var ret = await DataService.CreateAsync(model);
            return Created($"{Request.Path}{ret.Id}", ret);
        }

        public virtual async Task<ActionResult> GetAllAsync()
            => Json(await DataService.GetAllAsync());

        public virtual async Task<ActionResult> GetOneAsync(int id)
        {
            var model = await DataService.GetOneAsync(id);
            if (model == null)
                return NotFound();
            return Json(model);
        }

        public virtual async Task<ActionResult> UpdateAsync(T model, int id)
        {
            var newModel = await DataService.UpdateAsync(model, id);
            if (newModel == null)
                return NotFound();
            return Json(newModel);
        }

        public virtual async Task<ActionResult> DeleteAsync(int id)
        {
            if (await DataService.DeleteAsync(id))
                return Ok();
            return NotFound();
        }
    }
}