using System.Collections.Generic;

namespace QuizMaster.Shared.Models
{
    public class User : Base.Model
    {
        public List<string> ConnectionIds { get; set; }
    }
}