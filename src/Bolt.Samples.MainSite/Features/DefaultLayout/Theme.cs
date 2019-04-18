using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bolt.Samples.MainSite.Features.DefaultLayout
{
    public class Theme
    {
        public virtual IEnumerable<ThemeItem> Children { get; set; }

        public IEnumerable<string> Styles
        {
            get
            {
                return Children.Where(x => x.Name.ToLower().Equals("css")).SelectMany(x => x.Value.Split('|'));
            }
        }

        public IEnumerable<string> Scripts
        {
            get
            {
                return Children.Where(x => x.Name.ToLower().Equals("js")).SelectMany(x => x.Value.Split('|'));
            }
        }
    }
}