using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Zeus.Common.Mvc;

namespace Zeus.Samples.MainSite
{
    public class Global : Sitecore.Web.Application
    {
        public override void Application_Start(object sender, EventArgs e)
        {
            base.Application_Start(sender, e);
            ViewEngines.Engines.Add(new DynamicViewEngine());
        }
    }
}