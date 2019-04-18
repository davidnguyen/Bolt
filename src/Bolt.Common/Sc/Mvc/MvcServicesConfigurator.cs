using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bolt.Common.Sc.Mvc
{
    public class MvcServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            var autowireName = ConfigurationManager.AppSettings["Bolt.Common.Mvc.DiAutowireName"];

            var autowireAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName.StartsWith(autowireName));

            var mvcTypes = new[] { typeof(Controller), typeof(RenderingModel) };

            autowireAssemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => !x.IsAbstract)
                .Where(x => mvcTypes.Any(y => y.IsAssignableFrom(x)))
                .ToList().ForEach(x => serviceCollection.AddTransient(x));
        }
    }
}
