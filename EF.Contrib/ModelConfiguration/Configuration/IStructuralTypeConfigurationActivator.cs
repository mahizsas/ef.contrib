namespace EF.Contrib.ModelConfiguration.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// the base contract for structural type configuration activator
    /// </summary>
    public interface IStructuralTypeConfigurationActivator
    {
        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="configurationType">the structural type  configuration type</param>
        /// <returns>A new instance</returns>
        object Create(Type configurationType);
    }
}
