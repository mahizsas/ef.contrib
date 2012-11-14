namespace UnitTests.ModelConfiguration.Configuration
{
    using EF.Contrib.ModelConfiguration.Configuration;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using Xunit;

    /// <summary>
    /// A collection of tests for named assembly resolver
    /// </summary>
    public class NamedAssemblyConfigurationResolverTests
    {
        [Fact]
        public void SolveStructuralTypeConfigurations_return_the_instances_of_structuraltype_configurations()
        {
            var resolver = new NamedAssemblyConfigurationResolver("UnitTests");

            var instances = resolver.SolveStructuralTypeConfigurations();

            Assert.NotNull(instances);
            Assert.True(instances.Any((i) => i.GetType() == typeof(NamedAssemblyPublicEntityMap)));
            Assert.True(instances.Any((i) => i.GetType() == typeof(NamedAssemblyPublicComplexMap)));
        }

        [Fact]
        public void AssemblyName_got_the_assemblyname()
        {
            var name = "UnitTests";
            var resolver = new NamedAssemblyConfigurationResolver(name);

            Assert.Equal(name,resolver.AssemblyName);
        }


        public class Entity { }

        public class NamedAssemblyPublicEntityMap : EntityTypeConfiguration<Entity> { }

        public class NamedAssemblyPublicComplexMap : ComplexTypeConfiguration<Entity> { }

    }
}
