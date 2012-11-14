using System.Collections.Generic;
namespace EF.Contrib.EntityTypeConfiguration.ModelConfiguartion.Configuration
{

    /// <summary>
    /// The assembly resolver for configuration types
    /// </summary>
    public interface IAssemblyResolver
    {
        /// <summary>
        /// Solve the struyctural type configurations
        /// </summary>
        /// <returns>A collection of structural type configurations instances</returns>
        IEnumerable<dynamic> SolveStructuralTypeConfigurations();
    }
}
