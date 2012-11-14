namespace EF.Contrib.ModelConfiguration.Configuration
{
    using EF.Contrib.EntityTypeConfiguration.ModelConfiguartion.Configuration;

    public static class ConfigurationSolver
    {
        /// <summary>
        /// Get  assembly resolver for this assembly
        /// </summary>
        /// <returns>the assembly resolver</returns>
        public static IConfigurationResolver FromThisAssembly() { return new ThisAssemblyConfigurationResolver(); }

        /// <summary>
        /// Get a new assembly resolver for assembly with name <paramref name="assemblyName"/>
        /// </summary>
        /// <param name="assemblyName">The assembly name</param>
        /// <returns>the assembly resolver</returns>
        public static IConfigurationResolver FromNamedAssembly(string assemblyName) { return new NamedAssemblyConfigurationResolver(assemblyName); }
    }
}
