using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicWebApp
{
    public class Clock : WebControl
    {
        public string Pattern { get; set; }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write(DateTime.Now.ToString(Pattern));
        }
    }
}