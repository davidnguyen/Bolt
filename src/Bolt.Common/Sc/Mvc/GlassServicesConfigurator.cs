using Glass.Mapper;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web;
using Glass.Mapper.Sc.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Data;
using Sitecore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeus.Common.Sc.Mvc
{
    public class GlassServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            // For getting a SitecoreService for any database
            serviceCollection.AddSingleton<Func<Database, ISitecoreService>>(x => CreateSitecoreService);

            // For injecting into Controllers and Rendering Models
            serviceCollection.AddScoped(x => CreateSitecoreContextService());
            serviceCollection.AddScoped(x => CreateRequestContext());
            serviceCollection.AddScoped(x => CreateGlassHtml());
            serviceCollection.AddScoped(x => CreateMvcContext());

            // For injecting into Configuration Factory types like pipeline processors
            serviceCollection.AddSingleton<Func<ISitecoreService>>(x => Get<ISitecoreService>);
            serviceCollection.AddSingleton<Func<IRequestContext>>(x => Get<IRequestContext>);
            serviceCollection.AddSingleton<Func<IGlassHtml>>(x => Get<IGlassHtml>);
            serviceCollection.AddSingleton<Func<IMvcContext>>(x => Get<IMvcContext>);
        }

        private static ISitecoreService CreateSitecoreService(Database database)
        {
            var config = new Glass.Mapper.Sc.Config();
            var depResolver = new Glass.Mapper.Sc.IoC.DependencyResolver(config);
            var ctx = Context.Create(depResolver);
            return new SitecoreService(database, ctx);
        }

        private static ISitecoreService CreateSitecoreContextService()
        {
            var sitecoreServiceGetter = Get<Func<Database, ISitecoreService>>();
            return sitecoreServiceGetter(Sitecore.Context.Database);
        }

        private static T Get<T>()
        {
            return ServiceLocator.ServiceProvider.GetService<T>();
        }

        private static IRequestContext CreateRequestContext()
        {
            return new RequestContext(Get<ISitecoreService>());
        }

        private static IGlassHtml CreateGlassHtml()
        {
            return new GlassHtml(Get<ISitecoreService>());
        }

        private static IMvcContext CreateMvcContext()
        {
            return new MvcContext(Get<ISitecoreService>(), Get<IGlassHtml>());
        }
    }
}
