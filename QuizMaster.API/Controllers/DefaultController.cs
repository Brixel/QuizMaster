using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace QuizMaster.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DefaultController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] {"Didn't", "believe", "it", "right??"};
        }
    }
}