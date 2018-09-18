using System.Collections.Generic;
using QuizMaster.Shared.Models.Base;

namespace QuizMaster.Shared.Models
{
    public class Quiz : Model
    {
        public string Title { get; set; }
        public IEnumerable<Round> Rounds { get; set; }
    }
}