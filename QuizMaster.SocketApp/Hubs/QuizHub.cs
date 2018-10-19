using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using QuizMaster.Shared.Models;

namespace QuizMaster.SocketApp.Hubs
{
    public class QuizHub : Hub<User>
    {
        public async Task JoinQuiz(string lobby, string username, string token)
        {
        }

        public async Task LeaveQuiz(string lobby, string username, string token)
        {
        }

        public async Task KickFromQuiz(string lobby, string token, string userToKick)
        {
        }

        public async Task StartQuiz(string lobby, string token)
        {
        }
    }
}