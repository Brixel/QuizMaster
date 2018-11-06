using QuizMaster.API.Data;
using QuizMaster.Shared.Models;

namespace QuizMaster.API.Services
{
    public class QuestionService : DataService<Question>
    {
        public QuestionService(QuizContext context) : base(context)
        {
        }
    }
}