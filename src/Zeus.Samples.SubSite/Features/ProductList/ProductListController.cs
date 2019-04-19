using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zeus.Samples.SubSite.Features.ProductList
{
    public class ProductListController : Controller
    {
        IMvcContext _mvcContext = null;

        public ProductListController(IMvcContext mvcContext)
        {
            _mvcContext = mvcContext;
        }

        public ActionResult ProductList()
        {
            var model = _mvcContext.GetDataSourceItem<ProductListModel>();
            return View(model);
        }
    }
}