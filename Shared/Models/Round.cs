using System.Collections.Generic;
using QuizMaster.Shared.Models.Base;

namespace QuizMaster.Shared.Models
{
    public class Round: Model
    {
        public string Name { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}