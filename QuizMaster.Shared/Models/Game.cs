using System.Collections.Generic;
using QuizMaster.Shared.Models.Base;

namespace QuizMaster.Shared.Models
{
    public class Game : Model
    {
        public User QuizMaster { get; set; }
        public List<User> Participants { get; set; }
        public Quiz Quiz { get; set; }
        public int CurrentRound { get; set; }
        public int CurrentQuestion { get; set; }
    }
}