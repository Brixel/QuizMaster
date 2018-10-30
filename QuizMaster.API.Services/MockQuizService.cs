using System.Collections.Generic;
using QuizMaster.API.Data;
using QuizMaster.API.Services.Interfaces;
using QuizMaster.Shared.Models;

namespace QuizMaster.API.Services
{
    public class MockQuizService : MockDataService<Quiz>
    {
        public MockQuizService(IDataService<Round> roundService)
        {
            Data = new List<Quiz>
            {
                new Quiz {Id = 0, Title = "Test Quiz", Rounds = roundService.GetAllAsync().Result}
            };
        }
    }

    public class QuizService : DataService<Quiz>
    {
        public QuizService(QuizContext context) : base(context)
        {
        }
    }
}