using Sitecore.Mvc.Pipelines.Response.GetModel;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;

namespace Bolt.Common.Sc.Mvc
{
    public class ViewModelProcessor : GetModelProcessor
    {
        protected virtual object GetFromViewPath(Rendering rendering, GetModelArgs args)
        {
            var path = rendering.Renderer is ViewRenderer
                ? ((ViewRenderer)rendering.Renderer).ViewPath
                : rendering.ToString().Replace("View: ", string.Empty);

            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            // don't act on SPEAK or other Sitecore views
            if (path.Contains("sitecore/shell"))
            {
                return null;
            }

            // Retrieve the compiled view
            var compiledViewType = BuildManager.GetCompiledType(path);
            var baseType = compiledViewType.BaseType;

            // Check to see if the view has been found and that it is a generic type
            if (baseType == null || !baseType.IsGenericType)
            {
                return null;
            }

            var modelType = baseType.GetGenericArguments()[0];

            // Check to see if no model has been set
            if (modelType == typeof(object))
            {
                return null;
            }

            var fullyQualifiedName = modelType.FullName + ", " + modelType.Assembly.GetName().Name;

            var modelLocator = new RenderingModelLocator();

            return modelLocator.GetModel(fullyQualifiedName, true);
        }

        public override void Process(GetModelArgs args)
        {
            if (args.Result == null)
            {
                args.Result = GetFromViewPath(args.Rendering, args);
            }
        }
    }
}
