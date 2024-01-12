using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http;
using System.Net;
using System;
using Microsoft.Extensions.Logging;
using Serilog;

namespace WebApi
{
    public class CustomExceptionFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            Log.Error(context.Exception, "\n\nLOGGER WORKS !!!!!!!!!!!!!!!!!!!\n\n");
            Log.Information("\nEND OF LOGGING MESSAGE");
        }
    }
}
