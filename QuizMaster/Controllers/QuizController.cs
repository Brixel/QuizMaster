using System.Threading.Tasks;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.Controllers.Base;
using QuizMaster.Shared.Models;

namespace QuizMaster.Controllers
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
        [Route("api/v1/[controller]/")]
        public override async Task<ActionResult> CreateAsync([FromBody] Quiz quiz)
            => await base.CreateAsync(quiz);

        [HttpGet]
        [Route("api/v1/[controller]/")]
        public override async Task<ActionResult> GetAllAsync()
            => await base.GetAllAsync();

        [HttpGet]
        [Route("api/v1/[controller]/{id}")]
        public override async Task<ActionResult> GetOneAsync([FromQuery] int id)
            => await base.GetOneAsync(id);

        [HttpGet]
        [Route("api/v1/[controller]/{id}/{propertyName}")]
        public override async Task<ActionResult> GetPropertyAsync([FromQuery] int id, [FromQuery] string propertyName)
            => await base.GetPropertyAsync(id, propertyName);

        [HttpPut]
        [Route("api/v1/[controller]/{id}")]
        public override async Task<ActionResult> UpdateAsync([FromBody] Quiz quiz, [FromQuery] int id)
            => await base.UpdateAsync(quiz, id);

        [HttpDelete]
        [Route("api/v1/[controller]/{id}")]
        public override async Task<ActionResult> DeleteAsync([FromQuery] int id)
            => await base.DeleteAsync(id);
    }
}