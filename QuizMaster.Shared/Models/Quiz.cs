using System.Collections.Generic;
using QuizMaster.Shared.Models.Base;

namespace QuizMaster.Shared.Models
{
    public class Quiz : Model
    {
        public Quiz()
        {
            Rounds = new List<Round>();
            IsPublic = true;
        }
        public string Title { get; set; }
        public IEnumerable<Round> Rounds { get; set; }
        public bool IsPublic { get; set; }
        public string Password { get; set; } 
    }
}