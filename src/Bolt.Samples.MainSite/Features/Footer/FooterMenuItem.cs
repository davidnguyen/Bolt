using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bolt.Samples.MainSite.Features.Footer
{
    public class FooterMenuItem
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Link Link { get; set; }
    }
}