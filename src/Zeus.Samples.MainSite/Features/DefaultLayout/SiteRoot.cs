using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zeus.Samples.MainSite.Features.DefaultLayout
{
    public class SiteRoot
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        public virtual Theme Theme { get; set; }
    }
}