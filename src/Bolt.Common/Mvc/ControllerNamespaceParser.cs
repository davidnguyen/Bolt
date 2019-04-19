using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeus.Common.Mvc
{
    public class ControllerNamespaceParser
    {
        /// <summary>
        /// Parses controller namespace and return parts that are according to the project naming convention
        /// E.g.    Zeus.Samples.MainSite.Features.Header
        ///         should returns a collection of {"Samples", "MainSite", "Features", "Header"}
        ///             
        /// E.g.    Zeus.Samples.MainSite.Features.Accounts.Login
        ///         should returns a collection of {"Samples", "MainSite", "Features", "Accounts", "Login"}
        /// </summary>
        /// <param name="controllerNamespace">Controller namespace</param>
        /// <returns></returns>
        public IEnumerable<string> Parse(string controllerNamespace)
        {
            if (string.IsNullOrEmpty(controllerNamespace))
            {
                throw new ArgumentException("Controller namespace cannot be null or empty", "controllerNamespace");
            }

            var namespaceParts = controllerNamespace.Split('.');

            if (namespaceParts.Length < 2)
            {
                throw new ArgumentException("Controller namespace must have at least 2 parts", "controllerNamespace");
            }

            return namespaceParts.Except(new[] { namespaceParts[0] });
        }
    }
}
