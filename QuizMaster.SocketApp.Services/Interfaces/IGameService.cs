using System.Threading.Tasks;
using QuizMaster.Shared.Models;

namespace QuizMaster.SocketApp.Services.Interfaces
{
    public interface IGameService : IDataService<Game>
    {
        Task JoinGame(int game, int user);
        Task LeaveGame(int game, int user);
        Task StartGame(int game);
    }
}