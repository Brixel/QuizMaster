using System.Linq;
using System.Threading.Tasks;
using QuizMaster.Shared.Exceptions;
using QuizMaster.Shared.Extensions;
using QuizMaster.Shared.Models;
using QuizMaster.SocketApp.Services.Interfaces;

namespace QuizMaster.SocketApp.Services
{
    public class MockGameService : MockDataService<Game>, IGameService
    {
        private readonly IDataService<User> _userService;


        public MockGameService(IDataService<User> userService)
        {
            _userService = userService;
        }


        public async Task JoinGame(int gameId, int userId)
        {
            var user = await _userService.GetOneAsync(userId);
            if (user == null)
                throw new NotFoundException<User>(userId, $"Could not find the user (id={userId}) that wants to join.");

            var game = Data.FirstOrDefault(x => x.Id == gameId);
            if (game == null)
                throw new NotFoundException<Game>(gameId, $"Could not find the game (id={gameId}) to join.");

            game.Participants.Add(user);
        }

        public async Task LeaveGame(int gameId, int userId)
        {
            await Task.Run(() =>
            {
                var game = Data.FirstOrDefault(x => x.Id == gameId);
                if (game == null)
                    throw new NotFoundException<Game>(gameId, $"Could not find the game (id={gameId}) to join.");

                if (!game.Participants.RemoveOne(x => x.Id == userId))
                    throw new NotFoundException<User>(userId,
                        $"Could not find the user (id={userId}) that wants to leave in the game.");
            });
        }

        public async Task StartGame(int gameId)
        {
            await Task.Run(() =>
            {
                var game = Data.FirstOrDefault(x => x.Id == gameId);
                if (game == null)
                    throw new NotFoundException<Game>(gameId, $"Could not find the game (id={gameId}) to join");

                game.CurrentRound = 0;
                game.CurrentQuestion = 0;
            });
        }
    }
}