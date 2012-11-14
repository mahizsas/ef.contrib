namespace EF.Contrib.ModelConfiguration.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class ThisAssemblyResolver
        :AssemblyResolverBase
    {
        /// <summary>
        /// <see cref="EF.Contrib.ModelConfiguration.Configuration.AssemblyResolverBase"/>
        /// </summary>
        /// <returns><see cref="EF.Contrib.ModelConfiguration.Configuration.AssemblyResolverBase"/></returns>
        public override IEnumerable<dynamic> SolveStructuralTypeConfigurations()
        {
            var configurations = new List<dynamic>();
            var thisAssembly = Assembly.GetCallingAssembly();

            if (thisAssembly != null)
            {
                foreach (var type in thisAssembly.ExportedTypes)
                {
                    if (this.Filter.IsStructuralTypeConfiguration(type))
                        configurations.Add(this.Activator.Create(type));
                }
            }

            return configurations;
        }
    }
}
