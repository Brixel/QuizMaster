using System.Threading.Tasks;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.Controllers.Base;
using QuizMaster.Shared.Models;

namespace QuizMaster.Controllers
{
    public class RoundsController : CRUDControllerBase<Round>
    {
        public RoundsController(IDataService<Round> dataService) : base(dataService)
        {
        }
        
        [HttpPost]
        public override async Task<ActionResult> CreateAsync([FromBody] Round round)
            => await base.CreateAsync(round);

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
        public override async Task<ActionResult> UpdateAsync([FromBody] Round round, int id)
            => await base.UpdateAsync(round, id);

        [HttpDelete]
        [Route("{id}")]
        public override async Task<ActionResult> DeleteAsync(int id)
            => await base.DeleteAsync(id);
    }
}