using System.Collections.Generic;
using QuizMaster.Shared.Models.Base;

namespace QuizMaster.Shared.Models
{
    public class Question : Model
    {
        public string Text { get; set; }
        
        public IEnumerable<Answer> Answers { get; set; }
        
        public bool IsMultipleChoice { get; set; }
        public string AnswerMustContain { get; set; }
    }
}