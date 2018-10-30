using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizMaster.Shared.Models
{
    public class User : Base.Model
    {
        [NotMapped]
        public List<string> ConnectionIds { get; set; }
    }
}