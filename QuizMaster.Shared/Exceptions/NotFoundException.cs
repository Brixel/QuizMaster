using System;
using QuizMaster.Shared.Models.Base;

namespace QuizMaster.Shared.Exceptions
{
    public class NotFoundException<T> : Exception where T : Model
    {
        public int IdNotFound { get; set; } = -1;
        
        public NotFoundException()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        
        public NotFoundException(int idNotFound, string message)
            : base(message)
        {
            IdNotFound = idNotFound;
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}