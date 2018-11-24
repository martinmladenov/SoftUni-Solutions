namespace Eventures.Web.Filters
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using Models;

    public class AdminCreateLoggerActionFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger logger;

        public AdminCreateLoggerActionFilterAttribute(ILogger<AdminCreateLoggerActionFilterAttribute> logger)
        {
            this.logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var model = context.ActionArguments.Values.OfType<EventCreateBindingModel>().Single();

            this.logger.LogInformation(
                $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Administrator " +
                $"{(context.Controller as Controller)?.User?.Identity?.Name} create event " +
                $"{model?.Name} ({model?.StartDate:dd-MMM-yyyy hh:mm:ss} / {model?.EndDate:dd-MMM-yyyy hh:mm:ss})");
        }
    }
}