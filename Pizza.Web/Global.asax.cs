using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Pizza.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

		// global exception handler
		void Application_Error(object sender, EventArgs e)
		{
			Exception ex = Server.GetLastError();
			var innerException = ex.InnerException;
			Response.Write(innerException.Message);
			Server.ClearError();
		}
	}
}