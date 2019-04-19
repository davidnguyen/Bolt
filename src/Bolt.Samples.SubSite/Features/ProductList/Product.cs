using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zeus.Samples.SubSite.Features.ProductList
{
    public class Product
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        [SitecoreField("Name")]
        public virtual string Name { get; set; }

        public virtual string Price { get; set; }

        public virtual string Features { get; set; }

        public virtual Link Link { get; set; }

        public virtual LinkButtonStyle LinkButtonStyle { get; set; }
    }
}