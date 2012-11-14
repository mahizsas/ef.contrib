namespace UnitTests.ModelConfiguration.Configuration
{
    using EF.Contrib.EntityTypeConfiguration.ModelConfiguartion.Configuration;
    using Moq;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using Xunit;

    /// <summary>
    /// A collection of tests for ConfigurationRegistrarExtensions
    /// </summary>
    public class ConfigurationRegistrarExtensionsTests
    {
        [Fact]
        public void Add_configure_all_structural_type_configurations_using_the_resolved()
        {
            var configurationResolverMock = new Mock<IConfigurationResolver>();
            configurationResolverMock.Setup(cr => cr.SolveStructuralTypeConfigurations())
                                     .Returns(new List<dynamic>());

             
        }

        [Fact]
        public void Add_throw_exception_if_resolver_is_null()
        {
        }

        
    }
    
}
