using QuizMaster.API.Data;
using QuizMaster.Shared.Models;

namespace QuizMaster.API.Services
{
    public class RoundService : DataService<Round>
    {
        public RoundService(QuizContext context) : base(context)
        {
        }
    }
}