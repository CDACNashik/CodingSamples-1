using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BasicWebApp
{
    /// <summary>
    /// Summary description for StateHandler
    /// </summary>
    public class StateHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string name = context.Request.Form["visitor"];
            if (name.Length == 0)
                context.Response.Redirect("welcome.gwh", true);

            int count = (int?)context.Session[name] ?? 1;
            context.Session[name] = count + 1;

            var output = context.Response.Output;

            output.WriteLine("<html>");
            output.WriteLine("<head><title>BasicWebApp</title></head>");
            output.WriteLine("<body>");
            output.WriteLine($"<h1>Hello {name}</h1>");
            output.WriteLine($"<b>Number of greetings: </b>{count}");
            output.WriteLine("</body>");
            output.WriteLine("</html>");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}