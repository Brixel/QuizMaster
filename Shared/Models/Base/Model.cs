namespace QuizMaster.Shared.Models.Base
{
    public abstract class Model : IModel
    {
        public virtual int Id { get; set; }
    }
}