using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zeus.Samples.MainSite.Features.TileListHorizontal
{
    public class Style
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        public virtual string Value { get; set; }
    }
}