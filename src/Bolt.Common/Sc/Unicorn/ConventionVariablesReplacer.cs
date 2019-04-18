using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicorn.Pipelines.UnicornExpandConfigurationVariables;
using Configy.Parsing;

namespace Bolt.Common.Sc.Unicorn
{
    /// <summary>
	/// Enables the use of $(project), $(site) and $(feature) in configurations according to the conguration naming convention of
    /// $(project).$(site).$(feature)
	/// E.g. Samples.MainSite.Header
    ///         $(project) = Samples
    ///         $(site) = MainSite
    ///         $(feature) = Header
	/// </summary>
    public class ConventionVariablesReplacer : ContainerDefinitionVariablesReplacer, IUnicornExpandConfigurationVariablesProcessor
    {
        public void Process(UnicornExpandConfigurationVariablesPipelineArgs args)
        {
            ReplaceVariables(args.Configuration);
        }

        public override void ReplaceVariables(ContainerDefinition definition)
        {
            if (definition.Name == null) throw new ArgumentException("Configuration without a name was used. Add a name attribute to all configurations.", nameof(definition));

            var variables = GetVariables(definition.Name);

            ApplyVariables(definition.Definition, variables);
        }

        public virtual Dictionary<string, string> GetVariables(string name)
        {
            var pieces = name.Split('.');

            if (pieces.Length < 3) return new Dictionary<string, string>();

            var vars = new Dictionary<string, string>
            {
                { "project", pieces[0] },
                { "site", pieces[1] },
                { "feature", pieces[2] }
            };

            return vars;
        }
    }
}
