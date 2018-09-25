using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.API.Controllers.Base;
using QuizMaster.API.Services.Interfaces;
using QuizMaster.Shared.Models;

namespace QuizMaster.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class QuizController : CRUDControllerBase<Quiz>
    {
        public QuizController(IDataService<Quiz> dataService)
            : base(dataService)
        {
        }

        [HttpPost]
        public override async Task<ActionResult> CreateAsync([FromBody] Quiz quiz)
            => await base.CreateAsync(quiz);

        [HttpGet]
        public override async Task<ActionResult> GetAllAsync()
            => await base.GetAllAsync();

        [HttpGet]
        [Route("{id}")]
        public override async Task<ActionResult> GetOneAsync(int id)
            => await base.GetOneAsync(id);

        [HttpGet]
        [Route("{id}/{propertyName}")]
        public override async Task<ActionResult> GetPropertyAsync(int id, string propertyName)
            => await base.GetPropertyAsync(id, propertyName);

        [HttpPut]
        [Route("{id}")]
        public override async Task<ActionResult> UpdateAsync([FromBody] Quiz quiz, int id)
            => await base.UpdateAsync(quiz, id);

        [HttpDelete]
        [Route("{id}")]
        public override async Task<ActionResult> DeleteAsync(int id)
            => await base.DeleteAsync(id);
    }
}