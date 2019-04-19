using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace Zeus.Samples.SubSite.Features.ProductList
{
    public class ProductListModel
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        public virtual string TopHeading { get; set; }

        public virtual string TopDescription { get; set; }

        public virtual IEnumerable<Product> Children { get; set; }
    }
}