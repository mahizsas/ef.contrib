namespace UnitTests.ModelConfiguration.Configuration
{
    using EF.Contrib.EntityTypeConfiguration.ModelConfiguartion.Configuration;
    using System.Data.Entity.ModelConfiguration;
    using Xunit;

    /// <summary>
    /// A collection of tests for DefaultStructuralTypeConfigurationFilter
    /// </summary>
    public class DefaultStructuralTypeConfigurationFilterTests
    {
       
        [Fact()]
        public void IsStructuralTypeConfiguration_return_true_for_entity_type_configurations()
        {
            var filter = new DefaultStructuralTypeConfigurationFilter();

            var result = filter.IsStructuralTypeConfiguration(typeof(EntityMap));

            Assert.True(result);
        }

        [Fact()]
        public void IsStructuralTypeConfiguration_return_true_for_complex_type_configurations()
        {
            var filter = new DefaultStructuralTypeConfigurationFilter();

            var result = filter.IsStructuralTypeConfiguration(typeof(ComplexMap));

            Assert.True(result);
        }

        [Fact()]
        public void IsStructuralTypeConfiguration_return_false_for_types_without_base_type()
        {
            var filter = new DefaultStructuralTypeConfigurationFilter();

            var result = filter.IsStructuralTypeConfiguration(typeof(ConfigurationWithoutBaseType));

            Assert.False(result);
        }

        [Fact()]
        public void IsStructuralTypeConfiguration_return_false_for_non_class_generic_arguments()
        {
            var filter = new DefaultStructuralTypeConfigurationFilter();

            var result = filter.IsStructuralTypeConfiguration(typeof(ConfigurationWithBaseType));

            Assert.False(result);
        }

        private class ConfigurationWithoutBaseType { }

        private class ConfigurationWithBaseType : ConfigurationWithoutBaseType { }

        private class Entity { }

        private class EntityMap : EntityTypeConfiguration<Entity> { }

        private class ComplexMap : ComplexTypeConfiguration<Entity> { }
    }

}
