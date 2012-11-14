namespace UnitTests.ModelConfiguration.Configuration
{
    using EF.Contrib.ModelConfiguration.Configuration;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using Xunit;

    /// <summary>
    /// A collection of tests for this assembly resolver
    /// </summary>
    public class ThisAssemblyConfigurationResolverTests
    {
        [Fact]
        public void SolveStructuralTypeConfigurations_return_the_instances_of_structuraltype_configurations()
        {
            var resolver = new ThisAssemblyConfigurationResolver();

            var instances = resolver.SolveStructuralTypeConfigurations();

            Assert.NotNull(instances);
            Assert.True(instances.Any((i)=>i.GetType()==typeof(PublicEntityMap)));
            Assert.True(instances.Any((i) => i.GetType() == typeof(PublicComplexMap)));
        }

        public class Entity { }

        public class PublicEntityMap : EntityTypeConfiguration<Entity> { }

        public class PublicComplexMap : ComplexTypeConfiguration<Entity> { }

        class InternalEntityMap : EntityTypeConfiguration<Entity> { }

        class InternalComplexMap : ComplexTypeConfiguration<Entity> { }
    }
}

