using Microsoft.EntityFrameworkCore;
using QuizMaster.Shared.Models;

namespace QuizMaster.API.Data
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options): base(options)
        {
            
        }

        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}