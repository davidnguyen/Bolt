using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zeus.Samples.MainSite.Features.Footer
{
    public class FooterMenuGroup
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Title { get; set; }

        public virtual IEnumerable<FooterMenuItem> Children { get; set; }
    }
}