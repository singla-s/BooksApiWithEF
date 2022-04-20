using Microsoft.AspNetCore.Mvc.Filters;
using BooksApiWithEF.Models;
using System;

namespace BooksApiWithEF.Filters
{
    public class ActionLogFilterAttribute : ActionFilterAttribute, IActionFilter

    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            LoggingDBContext ctx = new LoggingDBContext();
            Logging newLog = new Logging();
            newLog.Id = 0;
            newLog.Timestamp = DateTime.Now;
            newLog.SourceIp = context.HttpContext.Connection.RemoteIpAddress.ToString();
            newLog.Action = "";
            newLog.Controller = context.Controller.ToString().Split('.')[context.Controller.ToString().Split('.').Length -1];
            ctx.Loggings.Add(newLog);
            ctx.SaveChanges();
            //base.OnActionExecuting(context);
        }
    }
}
