using System;
using System.Web;

//Web.config
//<configuration>
//<system.webServer><modules><add name = "DemoHttpModule" type="DemoHttpModule"/></modules></system.webServer>
//</configuration>

namespace DemoHttpModule
{
    public class DemoHttpModule : IHttpModule
    {
        public DemoHttpModule()
        {
        }

        public String ModuleName
        {
            get { return "DemoHttpModule"; }
        }

        // In the Init function, register for HttpApplication 
        // events by adding your handlers.
        public void Init(HttpApplication application)
        {
            application.BeginRequest +=
                (new EventHandler(this.Application_BeginRequest));
            application.EndRequest +=
                (new EventHandler(this.Application_EndRequest));
        }

        private void Application_BeginRequest(Object source,
             EventArgs e)
        {
            // Create HttpApplication and HttpContext objects to access
            // request and response properties.
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension =
                VirtualPathUtility.GetExtension(filePath);
            //if (fileExtension.Equals(".aspx"))
            //{
                context.Response.Write("<h1><font color=red>" +
                    "DemoHttpModule: Beginning of Request" +
                    "</font></h1><hr>");
            //}
        }

        private void Application_EndRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension =
                VirtualPathUtility.GetExtension(filePath);
            //if (fileExtension.Equals(".aspx"))
            //{
                context.Response.Write("<hr><h1><font color=red>" +
                    "DemoHttpModule: End of Request</font></h1>");
            //}
        }

        public void Dispose() { }
    }
}
