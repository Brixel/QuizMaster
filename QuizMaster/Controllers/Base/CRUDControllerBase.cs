using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Base;

namespace QuizMaster.Controllers.Base
{
    public abstract class CRUDControllerBase<T> : Controller where T : IModel
    {
        public virtual async Task<ActionResult> Create<T>(T model)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ActionResult> Read<T>(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ActionResult> Update<T>(T model, int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ActionResult> Delete<T>(int id)
        {
            throw new NotImplementedException();
        }
    }
}