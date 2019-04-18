using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bolt.Common.Mvc
{
    public class DynamicViewEngine : RazorViewEngine
    {
        public DynamicViewEngine()
        {
            var viewLocations = new[] {
                "~/Views/%1/{0}.cshtml"
            };

            PartialViewLocationFormats = viewLocations;
            ViewLocationFormats = viewLocations;
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var subPath = string.Join("/", new ControllerNamespaceParser().Parse(controllerContext.Controller.GetType().Namespace));
            return base.CreateView(controllerContext, viewPath.Replace("%1", subPath), masterPath);
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            var subPath = string.Join("/", new ControllerNamespaceParser().Parse(controllerContext.Controller.GetType().Namespace));
            return base.FileExists(controllerContext, virtualPath.Replace("%1", subPath));
        }
    }
}
