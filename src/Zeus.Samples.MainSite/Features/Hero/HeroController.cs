using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zeus.Samples.MainSite.Features.Hero
{
    public class HeroController : Controller
    {
        IMvcContext _mvcContext = null;

        public HeroController(IMvcContext mvcContext)
        {
            _mvcContext = mvcContext;
        }

        public ActionResult Hero()
        {
            var model = _mvcContext.GetDataSourceItem<HeroModel>();
            return View(model);
        }
    }
}