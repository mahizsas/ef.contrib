namespace UnitTests.ModelConfiguration.Configuration
{
    using EF.Contrib.ModelConfiguration.Configuration;
    using Xunit;

    /// <summary>
    /// A collection of ConfigurationResolver tests
    /// </summary>
    public class ConfigurationSolverTests
    {
        [Fact]
        public void NamedAssembly_set_the_assembly_name()
        {
            string name = "assemblyName";
            var resolver = ConfigurationSolver.FromNamedAssembly(name) as NamedAssemblyConfigurationResolver;

            var assemblyName = resolver.AssemblyName;

            Assert.Equal(name, assemblyName);
        }

        [Fact]
        public void NamedAssembly_return_the_namedassembly_resolver()
        {
            var resolver = ConfigurationSolver.FromNamedAssembly("assemblyName");

            Assert.NotNull(resolver);
            Assert.IsType<NamedAssemblyConfigurationResolver>(resolver);
        }

        [Fact]
        public void ThisAssembly_return_the_thisassembly_resolver()
        {
            var resolver = ConfigurationSolver.FromThisAssembly();

            Assert.NotNull(resolver);
            Assert.IsType<ThisAssemblyConfigurationResolver>(resolver);
        }
        
    }
}
