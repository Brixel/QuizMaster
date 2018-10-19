using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using QuizMaster.Shared.Exceptions;
using QuizMaster.Shared.Models;
using QuizMaster.SocketApp.Services.Interfaces;

namespace QuizMaster.SocketApp.Hubs
{
    public class GameHub : Hub
    {
        private const string RespondToJoinMethodName = "RespondToJoin";
        private const string RespondToLeaveMethodName = "RespondToLeave";
        private const string RespondToKickMethodName = "RespondToKick";
        private const string RespondToStartMethodName = "RespondToStart";

        private readonly IGameService _gameService;
        private readonly IDataService<User> _userService;

        public GameHub(IGameService gameService, IDataService<User> userService)
        {
            _gameService = gameService;
            _userService = userService;
        }

        public async Task JoinGame(int game, int user, string token)
        {
            // TODO verify the user with the token

            if (!await ConnectionIdMatchesUserId(user, RespondToJoinMethodName))
                return;

            await _gameService.JoinGame(game, user);
            await Clients.Client(Context.ConnectionId)
                .SendAsync(RespondToJoinMethodName, true, $"Joined game with id {game}.");
        }

        public async Task LeaveGame(int game, int user, string token)
        {
            // TODO verify the user with the token

            if (!await ConnectionIdMatchesUserId(user, RespondToLeaveMethodName))
                return;

            await _gameService.LeaveGame(game, user);
            await Clients.Client(Context.ConnectionId)
                .SendAsync(RespondToLeaveMethodName, true, $"Left game with id {game}.");
        }

        public async Task KickFromGame(int game, string token, int userIdToKick)
        {
            // TODO verify the user with the token

            if (!await ConnectionIdMatchesQuizMaster(game, RespondToKickMethodName))
                return;

            await _gameService.LeaveGame(game, userIdToKick);
            await Clients.Client(Context.ConnectionId)
                .SendAsync(RespondToKickMethodName, true, $"Kicked user with id {userIdToKick} from the game with id {game}.");

            var userToKick = await _userService.GetOneAsync(userIdToKick);
            if (userToKick == null)
                throw new NotFoundException<User>(userIdToKick, $"Could not find user with id {userIdToKick} to kick from game with id {game}.");

            await Clients.Clients(userToKick.ConnectionIds)
                .SendAsync($"You just got kicked out of the game with id {game} by the quiz master.");
        }

        public async Task StartGames(int game, string token)
        {
            // TODO verify the user with the token
            
            if (!await ConnectionIdMatchesQuizMaster(game, RespondToKickMethodName))
                return;

            await _gameService.StartGame(game);
            await Clients.Client(Context.ConnectionId)
                .SendAsync(RespondToStartMethodName, true, $"Started game with id {game}");
        }


        private async Task<bool> ConnectionIdMatchesUserId(int userId, string respondMethodName)
        {
            var user = await _userService.GetOneAsync(userId);
            if (user?.ConnectionIds.Any(x => x == Context.ConnectionId) == true)
                return true;

            await Clients.Client(Context.ConnectionId).SendAsync(respondMethodName, false,
                $"Connection ID ({Context.ConnectionId}) and user ID ({userId}) do not match. Cannot join another player.");
            return false;
        }

        private async Task<bool> ConnectionIdMatchesQuizMaster(int gameId, string respondMethodName)
        {
            var game = await _gameService.GetOneAsync(gameId);
            if (game == null)
            {
                await Clients.Client(Context.ConnectionId).SendAsync(respondMethodName, false,
                    $"The game (id = {gameId}) was not found.");
                return false;
            }

            if (game.QuizMaster.ConnectionIds.All(x => x != Context.ConnectionId))
            {
                await Clients.Client(Context.ConnectionId).SendAsync(respondMethodName, false,
                    $"Connection ID ({Context.ConnectionId}) is not of the quiz master. Cannot just kick another player.");
                return false;
            }

            return true;
        }
    }
}