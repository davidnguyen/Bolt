using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bolt.Samples.MainSite.Features.TileListHorizontal
{
    public class HorizontalTile
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        public virtual string Heading { get; set; }

        public virtual string SubHeading { get; set; }

        public virtual Style BackgroundStyle { get; set; }

        public virtual Style ForegroundStyle { get; set; }

        public virtual Style TextColor { get; set; }
    }
}