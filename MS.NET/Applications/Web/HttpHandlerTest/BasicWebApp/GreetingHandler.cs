using System;
using System.Web;

namespace BasicWebApp
{
    public class GreetingHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        private int n;

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string name = context.Request.QueryString["visitor"];
            var output = context.Response.Output;

            output.WriteLine("<html>");
            output.WriteLine("<head><title>BasicWebApp</title></head>");
            output.WriteLine("<body>");
            output.WriteLine($"<h1>Welcome Visitor {name}</h1>");
            output.WriteLine($"<b>Time on server<{++n}>: </b>{DateTime.Now}");
            output.WriteLine("</body>");
            output.WriteLine("</html>");
        }

        #endregion
    }
}
