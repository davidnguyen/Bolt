using Zeus.Common.Logging;
using Zeus.Common.Sc.Mvc;
using Glass.Mapper;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zeus.Samples.MainSite.Features.DefaultLayout
{
    public class DefaultLayoutRenderingModel : RenderingModel<LayoutModel>
    {
        private ILogService _logService = null;

        public DefaultLayoutRenderingModel(ILogService logService)
        {
            _logService = logService;
        }

        public override LayoutModel InitialiseViewModel(Rendering rendering, IMvcContext mvcContext)
        {
            var viewModel = mvcContext.GetContextItem<LayoutModel>();
            viewModel.SiteRoot = mvcContext.GetRootItem<SiteRoot>();
            return viewModel;
        }
    }
}