using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BasicWebApp
{
    public class HtmxHandlerFactory : IHttpHandlerFactory
    {
        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            return new HtmxHandler(pathTranslated);
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
        }

        class HtmxHandler : IHttpHandler
        {
            private string htmxPage;

            public HtmxHandler(string path)
            {
                htmxPage = path;
            }

            public bool IsReusable => false;

            public void ProcessRequest(HttpContext context)
            {
                try
                {
                    string content = File.ReadAllText(htmxPage)
                                        .Replace("<x:now/>", DateTime.Now.ToString());
                    context.Response.Write(content);
                }
                catch(FileNotFoundException)
                {
                    context.Response.StatusCode = 404;
                }
            }
        }
    }
}