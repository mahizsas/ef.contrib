namespace EF.Contrib.ModelConfiguration.Configuration
{
    using EF.Contrib.EntityTypeConfiguration.ModelConfiguartion.Configuration;

    public static class AssemblyResolver
    {
        /// <summary>
        /// Get  assembly resolver for this assembly
        /// </summary>
        /// <returns>the assembly resolver</returns>
        public static IAssemblyResolver This() { return new ThisAssemblyResolver(); }

        /// <summary>
        /// Get a new assembly resolver for assembly with name <paramref name="assemblyName"/>
        /// </summary>
        /// <param name="assemblyName">The assembly name</param>
        /// <returns>the assembly resolver</returns>
        public static IAssemblyResolver Named(string assemblyName) { return new NamedAssemblyResolver(assemblyName); }
    }
}
