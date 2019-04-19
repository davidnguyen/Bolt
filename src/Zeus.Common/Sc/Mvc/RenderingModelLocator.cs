using Sitecore.DependencyInjection;
using Sitecore.Mvc.Helpers;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zeus.Common.Sc.Mvc
{
    public class RenderingModelLocator : ModelLocator
    {
        /// <summary>
        /// Generic type pattern
        /// </summary>
        private const string GenericsTypePattern = @"`\d\[.+\]";

        /// <summary>
        /// Gets model object instance from type name
        /// </summary>
        /// <param name="typeName">Type name</param>
        /// <param name="model">Model reference</param>
        /// <param name="throwOnTypeCreationError">True to throw exception on type creation error, otherwise false</param>
        /// <returns>Model object instance</returns>
        protected override object GetModelFromTypeName(string typeName, string model, bool throwOnTypeCreationError)
        {
            // Resolve model type with generic type support
            var modelType = Regex.IsMatch(typeName, GenericsTypePattern, RegexOptions.Singleline)
                ? Type.GetType(typeName)
                : TypeHelper.GetType(typeName);

            if (modelType == null)
            {
                if (!throwOnTypeCreationError)
                {
                    return null;
                }

                throw new InvalidOperationException(
                    string.Format("Could not locate type '{0}'. Model reference: '{1}'",
                        (object)typeName, (object)model));
            }

            // Get model instance from service locator and resolve the instance's dependencies
            var modelObject = ServiceLocator.ServiceProvider.GetService(modelType);

            if (modelObject != null)
            {
                return modelObject;
            }
            else
            {
                // attempt using TypeHelper for Sitecore's own models 
                modelObject = TypeHelper.CreateObject(modelType);

                if (modelObject != null || !throwOnTypeCreationError)
                {
                    return modelObject;
                }
            }

            throw new InvalidOperationException(
                string.Format("Could not create a model object of type '{0}'. Model reference: '{1}'",
                    (object)typeName, (object)model));
        }
    }
}
