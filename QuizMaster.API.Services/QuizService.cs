using QuizMaster.API.Data;
using QuizMaster.Shared.Models;

namespace QuizMaster.API.Services
{
    public class QuizService : DataService<Quiz>
    {
        public QuizService(QuizContext context) : base(context)
        {
        }
    }
}