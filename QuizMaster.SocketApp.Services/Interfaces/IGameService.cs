using System.Threading.Tasks;

namespace QuizMaster.SocketApp.Services.Interfaces
{
    public interface IGameService
    {
        Task JoinGame(int game, int user);
        Task LeaveGame(int game, int user);
        Task StartGame(int game);
    }
}