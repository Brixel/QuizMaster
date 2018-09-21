using System.Threading.Tasks;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.Controllers.Base;
using QuizMaster.Shared.Models;

namespace QuizMaster.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class QuestionsController : CRUDControllerBase<Question>
    {
        public QuestionsController(IDataService<Question> dataService) : base(dataService)
        {
        }

        [HttpPost]
        public override async Task<ActionResult> CreateAsync([FromBody] Question question)
            => await base.CreateAsync(question);

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
        public override async Task<ActionResult> UpdateAsync([FromBody] Question question, int id)
            => await base.UpdateAsync(question, id);

        [HttpDelete]
        [Route("{id}")]
        public override async Task<ActionResult> DeleteAsync(int id)
            => await base.DeleteAsync(id);
    }
}