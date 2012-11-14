
namespace UnitTests.ModelConfiguration.Configuration
{
    using EF.Contrib.ModelConfiguration.Configuration;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using Xunit;

    public class ThisAssemblyResolverTests
    {
        [Fact]
        public void SolveStructuralTypeConfigurations_return_the_instances_of_structuraltype_configurations()
        {
            var resolver = new ThisAssemblyResolver();

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

