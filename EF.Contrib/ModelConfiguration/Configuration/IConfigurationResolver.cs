
namespace EF.Contrib.EntityTypeConfiguration.ModelConfiguartion.Configuration
{
    using System.Collections.Generic;

    /// <summary>
    /// The configuration resolver base contract
    /// </summary>
    public interface IConfigurationResolver
    {
        /// <summary>
        /// Solve the structural types configurations
        /// </summary>
        /// <returns>A collection of structural type configurations instances</returns>
        IEnumerable<dynamic> SolveStructuralTypeConfigurations();
    }
}
