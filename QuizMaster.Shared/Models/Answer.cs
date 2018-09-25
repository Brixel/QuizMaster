using QuizMaster.Shared.Models.Base;

namespace QuizMaster.Shared.Models
{
    public class Answer : Model
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}