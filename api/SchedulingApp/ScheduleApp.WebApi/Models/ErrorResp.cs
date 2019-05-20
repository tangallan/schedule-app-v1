using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ScheduleApp.WebApi.Models
{
    public class ErrorResp
    {
        public int HttpCode { get; private set; }

        public List<string> Messages { get; private set; }

        public ErrorResp()
        {
            HttpCode = (int)HttpStatusCode.InternalServerError;
            Messages = new List<string>();
        }

        public void SetHttpCode(HttpStatusCode httpStatusCode)
        {
            this.HttpCode = (int)httpStatusCode;
        }

        public void AddErrors(string message)
        {
            this.Messages.Add(message);
        }
    }
}
