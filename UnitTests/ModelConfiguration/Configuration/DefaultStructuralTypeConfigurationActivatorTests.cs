namespace UnitTests.ModelConfiguration.Configuration
{
    using EF.Contrib.ModelConfiguration.Configuration;
    using System;
    using Xunit;


    public class DefaultStructuralTypeConfigurationActivatorTests
    {
        [Fact]
        public void Create_throw_exception_if_configuration_dont_have_default_constructor()
        {
            var activator = new DefaultStructuralTypeConfigurationActivator();

            Assert.Throws<InvalidOperationException>(() =>
            {
                activator.Create(typeof(EntityMapWithoutDefaultConstructor));
            });
        }

        [Fact]
        public void Create_return_a_new_instance()
        {
            var activator = new DefaultStructuralTypeConfigurationActivator();

            var instance = activator.Create(typeof(EntityMap));

            Assert.True(typeof(EntityMap).IsInstanceOfType(instance));

        }

        class EntityMap { }

        class EntityMapWithoutDefaultConstructor
        {
            public EntityMapWithoutDefaultConstructor(string param) { }
        }
    }
}
