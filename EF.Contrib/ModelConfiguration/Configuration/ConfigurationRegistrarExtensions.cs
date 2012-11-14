
namespace EF.Contrib.ModelConfiguration.Configuration
{
    using EF.Contrib.EntityTypeConfiguration.ModelConfiguartion.Configuration;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Extensions methods for configurations registrar
    /// </summary>
    public static class ConfigurationRegistrarExtensions
    {
        /// <summary>
        /// Add new structural type configuration instance using the specific assembly resolver
        /// </summary>
        /// <param name="configurationRegistrar">ConfigurationRegistrar instance</param>
        /// <param name="assemblyResolver">The assembly resolver to use</param>
        public static void AddFrom(this ConfigurationRegistrar configurationRegistrar, IAssemblyResolver assemblyResolver)
        {
            Contract.Requires(assemblyResolver != null);

            //solve configurations using the specific resolver....
            var configurations = assemblyResolver.SolveStructuralTypeConfigurations();

            //add all configurations
            foreach (var item in configurations)
                configurationRegistrar.Add(item);
        }
    }
}
