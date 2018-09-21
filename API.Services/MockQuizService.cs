using System.Collections.Generic;
using API.Services.Interfaces;
using QuizMaster.Shared.Models;

namespace API.Services
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
}