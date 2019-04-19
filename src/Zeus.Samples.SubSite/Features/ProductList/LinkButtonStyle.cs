using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zeus.Samples.SubSite.Features.ProductList
{
    public class LinkButtonStyle
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        public virtual string Value { get; set; }
    }
}