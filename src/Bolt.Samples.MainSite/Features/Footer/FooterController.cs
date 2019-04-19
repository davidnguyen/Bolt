using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zeus.Samples.MainSite.Features.Footer
{
    public class FooterController : Controller
    {
        IMvcContext _mvcContext = null;

        public FooterController(IMvcContext mvcContext)
        {
            _mvcContext = mvcContext;
        }

        public ActionResult Footer()
        {
            var model = _mvcContext.GetDataSourceItem<FooterModel>();
            return View(model);
        }
    }
}