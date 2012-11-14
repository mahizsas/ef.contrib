namespace EF.Contrib.EntityTypeConfiguration.ModelConfiguartion.Configuration
{
    using System;

    /// <summary>
    /// A filter to check if type is a complex or entity type configuration
    /// </summary>
    public interface IStructuralTypeConfigurationFilter
    {
        /// <summary>
        /// Return true if type is a complex or entity type configuration type
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns>Return true is <paramref name="type"/> is a valid complex or entity configuration type</returns>
        bool IsStructuralTypeConfiguration(Type type);
    }

}
