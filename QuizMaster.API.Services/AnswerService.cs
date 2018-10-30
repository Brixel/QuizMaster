using QuizMaster.API.Data;
using QuizMaster.Shared.Models;

namespace QuizMaster.API.Services
{
    public class AnswerService : DataService<Answer>
    {
        public AnswerService(QuizContext context) : base(context)
        {
        }
    }
}