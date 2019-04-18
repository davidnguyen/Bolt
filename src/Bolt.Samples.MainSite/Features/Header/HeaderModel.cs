using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace Bolt.Samples.MainSite.Features.Header
{
    public class HeaderModel
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        public virtual Image LogoImage { get; set; }

        public virtual Link LogoLink { get; set; }

        public virtual IEnumerable<HeaderMenuItem> Children { get; set; }
    }
}