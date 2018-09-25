using System.Collections.Generic;
using System.Linq;
using QuizMaster.API.Services.Interfaces;
using QuizMaster.Shared.Models;

namespace QuizMaster.API.Services
{
    public class MockQuestionService : MockDataService<Question>
    {
        public MockQuestionService(IDataService<Answer> answerService)
        {
            var answers = answerService.GetAllAsync().Result.ToList();
            Data = new List<Question>
            {
                new Question
                {
                    Id = 0,
                    Text = "Wat is de hoofdstad van Frankrijk?",
                    Answers = answers.Where(x => x.Id == 0 || x.Id == 1 || x.Id == 2 || x.Id == 3),
                    IsMultipleChoice = true
                },
                new Question
                {
                    Id = 1,
                    Text = "Wat is de beste programmeertaal?",
                    Answers = answers.Where(x => x.Id == 4 || x.Id == 5 || x.Id == 6 || x.Id == 7),
                },
                new Question
                {
                    Id = 2,
                    Text = "Wie schreef de relativiteitstheorie?",
                    Answers = answers.Where(x => x.Id == 8 || x.Id == 9 || x.Id == 10)
                }
            };
        }
    }
}