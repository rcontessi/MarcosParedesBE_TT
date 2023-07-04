using System;
namespace Evoltis.Middleware.Exceptions
{
    public class ServerErrorModel
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public ServerErrorModel(Exception exception)
        {
            Message = exception?.Message;
            StackTrace = exception?.StackTrace;
        }
    }
}

