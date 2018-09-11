using API.Services.Interfaces;
using QuizMaster.Controllers.Base;
using QuizMaster.Shared.Models;

namespace QuizMaster.Controllers
{
    public class QuizController : CRUDControllerBase<Quiz>
    {
        public QuizController(IDataService<Quiz> dataService)
            : base(dataService)
        {
        }
    }
}