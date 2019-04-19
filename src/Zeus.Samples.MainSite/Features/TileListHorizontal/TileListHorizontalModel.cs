using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace Zeus.Samples.MainSite.Features.TileListHorizontal
{
    public class TileListHorizontalModel
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        public virtual IEnumerable<HorizontalTile> Children { get; set; }
    }
}