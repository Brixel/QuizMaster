using System.Collections.Generic;
using QuizMaster.Shared.Models;

namespace QuizMaster.API.Services
{
    public class MockAnswerService : MockDataService<Answer>
    {
        public MockAnswerService()
        {
            Data = new List<Answer>
            {
                new Answer {Id = 0, IsCorrect = false, Text = "Brussel"},
                new Answer {Id = 1, IsCorrect = false, Text = "Budapest"},
                new Answer {Id = 2, IsCorrect = false, Text = "London"},
                new Answer {Id = 3, IsCorrect = true, Text = "Paris"},
                new Answer {Id = 4, IsCorrect = false, Text = "Java"},
                new Answer {Id = 5, IsCorrect = true, Text = "C#"},
                new Answer {Id = 6, IsCorrect = false, Text = "JavaScript"},
                new Answer {Id = 7, IsCorrect = false, Text = "PHP"},
                new Answer {Id = 8, IsCorrect = true, Text = "Einstein"},
                new Answer {Id = 9, IsCorrect = false, Text = "Cury"},
                new Answer {Id = 10, IsCorrect = false, Text = "Newton"}
            };
        }
    }
}