using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bolt.Samples.MainSite.Features.Header
{
    public class HeaderController : Controller
    {
        IMvcContext _mvcContext = null;

        public HeaderController(IMvcContext mvcContext)
        {
            _mvcContext = mvcContext;
        }

        public ActionResult Header ()
        {
            var model = _mvcContext.GetDataSourceItem<HeaderModel>();
            return View(model);
        }
    }
}