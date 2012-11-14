namespace UnitTests.ModelConfiguration.Configuration
{
    using EF.Contrib.ModelConfiguration.Configuration;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using Xunit;

    /// <summary>
    /// A collection of tests for named assembly resolver
    /// </summary>
    public class NamedAssemblyResolverTests
    {
        [Fact]
        public void SolveStructuralTypeConfigurations_return_the_instances_of_structuraltype_configurations()
        {
            var resolver = new NamedAssemblyResolver("UnitTests");

            var instances = resolver.SolveStructuralTypeConfigurations();

            Assert.NotNull(instances);
            Assert.True(instances.Any((i) => i.GetType() == typeof(NamedAssemblyPublicEntityMap)));
            Assert.True(instances.Any((i) => i.GetType() == typeof(NamedAssemblyPublicComplexMap)));
        }


        public class Entity { }

        public class NamedAssemblyPublicEntityMap : EntityTypeConfiguration<Entity> { }

        public class NamedAssemblyPublicComplexMap : ComplexTypeConfiguration<Entity> { }

    }
}
