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
        
        public async Task JoinGame(string lobby, string username, string token)
        {
        }

        public async Task LeaveGame(string lobby, string username, string token)
        {
        }

        public async Task KickFromGame(string lobby, string token, string userToKick)
        {
        }

        public async Task StartGames(string lobby, string token)
        {
        }
    }
}