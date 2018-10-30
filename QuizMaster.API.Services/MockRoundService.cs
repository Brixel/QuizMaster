using System.Collections.Generic;
using System.Linq;
using QuizMaster.API.Services.Interfaces;
using QuizMaster.Shared.Models;

namespace QuizMaster.API.Services
{
    public class MockRoundService : MockDataService<Round>
    {
        public MockRoundService(IDataService<Question> questionService)
        {
            var questions = questionService.GetAllAsync().Result.ToList();

            Data = new List<Round>
            {
                new Round
                {
                    Id = 0,
                    Name = "Ronde 1",
                    Questions = questions.Where(x => x.Id == 1 || x.Id == 2)
                },
                new Round
                {
                    Id = 1,
                    Name = "Ronde 2",
                    Questions = questions.Where(x => x.Id == 3)
                }
            };
        }
    }
}