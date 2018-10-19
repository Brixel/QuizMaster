using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using QuizMaster.Shared.Models;
using QuizMaster.SocketApp.Services.Interfaces;

namespace QuizMaster.SocketApp.Hubs
{
    public class GameHub : Hub<User>
    {
        private readonly IGameService _gameService;

        public GameHub(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task JoinGame(int game, int user, string token)
        {
            // TODO verify the user with the token
            await _gameService.JoinGame(game, user);
        }

        public async Task LeaveGame(int game, int user, string token)
        {
            // TODO verify the user with the token
            await _gameService.LeaveGame(game, user);
        }

        public async Task KickFromGame(int game, string token, int userToKick)
        {
            // TODO verify the user with the token
            await _gameService.LeaveGame(game, userToKick);
        }

        public async Task StartGames(int game, string token)
        {
            // TODO verify the user with the token
            await _gameService.StartGame(game);
        }
    }
}