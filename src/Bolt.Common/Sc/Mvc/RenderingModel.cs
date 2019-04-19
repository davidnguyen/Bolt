using Glass.Mapper.Sc.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeus.Common.Sc.Mvc
{
    public abstract class RenderingModel<TViewModel> : RenderingModel
        where TViewModel : class
    {
        public TViewModel ViewModel { get; set; }

        public override void Initialize(Rendering rendering)
        {
            var mvcContext = ServiceLocator.ServiceProvider.GetService<IMvcContext>();
            ViewModel = InitialiseViewModel(rendering, mvcContext);
            base.Initialize(rendering);
        }

        public abstract TViewModel InitialiseViewModel(Rendering rendering, IMvcContext mvcContext);
    }
}
