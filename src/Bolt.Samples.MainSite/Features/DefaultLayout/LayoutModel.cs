using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bolt.Samples.MainSite.Features.DefaultLayout
{
    public class LayoutModel
    {
        public virtual string BrowserTitle { get; set; }

        public virtual string Keywords { get; set; }

        public virtual string Description { get; set; }

        [SitecoreIgnore]
        public SiteRoot SiteRoot { get; set; }
    }
}