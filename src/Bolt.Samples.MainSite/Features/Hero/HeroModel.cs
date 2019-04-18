using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace Bolt.Samples.MainSite.Features.Hero
{
    public class HeroModel
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string Text { get; set; }

        public virtual Link Link { get; set; }
    }
}