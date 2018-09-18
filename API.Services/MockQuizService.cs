using System.Collections.Generic;
using QuizMaster.Shared.Models;

namespace API.Services
{
    public class MockQuizService : MockDataService<Quiz>
    {
        public MockQuizService()
        {
            Data = new List<Quiz>
            {
                new Quiz {Id = 0, Title = "Test Quiz"}
            };
        }
    }
}