namespace EF.Contrib.ModelConfiguration.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Reflection;

    /// <summary>
    /// Assembly resolved based on the assembly name to find structural type configuration
    /// </summary>
    public class NamedAssemblyResolver
        :AssemblyResolverBase
    {
        string _assemblyName;

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="assemblyName">the assembly name used to resolve assembly and structural type configurations</param>
        public NamedAssemblyResolver(string assemblyName)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(assemblyName));

            _assemblyName = assemblyName;

        }
        /// <summary>
        /// <see cref="EF.Contrib.ModelConfiguration.Configuration.AssemblyResolverBase"/>
        /// </summary>
        /// <returns><see cref="EF.Contrib.ModelConfiguration.Configuration.AssemblyResolverBase"/></returns>
        public override IEnumerable<dynamic> SolveStructuralTypeConfigurations()
        {
            var configurations = new List<dynamic>();
            var namedAssembly = Assembly.Load(_assemblyName);

            if (namedAssembly != null)
            {
                foreach (var type in namedAssembly.ExportedTypes)
                {
                    if ( this.Filter.IsStructuralTypeConfiguration(type))
                        configurations.Add(this.Activator.Create(type));
                }
            }


            return configurations;

        }
    }
}
