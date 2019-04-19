using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zeus.Samples.MainSite.Features.TileListHorizontal
{
    public class TileListHorizontalController : Controller
    {
        IMvcContext _mvcContext = null;

        public TileListHorizontalController(IMvcContext mvcContext)
        {
            _mvcContext = mvcContext;
        }

        public ActionResult TileListHorizontal()
        {
            var model = _mvcContext.GetDataSourceItem<TileListHorizontalModel>();
            return View(model);
        }
    }
}