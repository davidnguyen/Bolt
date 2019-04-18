using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace Bolt.Samples.MainSite.Features.Footer
{
    public class FooterModel
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        public virtual Image FooterLogo { get; set; }

        public virtual string CopyrightText { get; set; }

        public virtual IEnumerable<FooterMenuGroup> Children { get; set; }
    }
}