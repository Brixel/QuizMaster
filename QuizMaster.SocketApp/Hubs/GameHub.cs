using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using QuizMaster.Shared.Models;
using QuizMaster.SocketApp.Services.Interfaces;

namespace QuizMaster.SocketApp.Hubs
{
    public class GameHub : Hub<User>
    {
        private readonly IDataService<Game> _gameService;

        public GameHub(IDataService<Game> gameService)
        {
            _gameService = gameService;
        }
        
        public async Task JoinGame(int game, int user, string token)
        {
            
        }

        public async Task LeaveGame(int game, int user, string token)
        {
        }

        public async Task KickFromGame(int game, string token, int userToKick)
        {
        }

        public async Task StartGames(int game, string token)
        {
        }
    }
}