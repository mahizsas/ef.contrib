namespace EF.Contrib.ModelConfiguration.Configuration
{
    using EF.Contrib.EntityTypeConfiguration.ModelConfiguartion.Configuration;
    using System.Collections.Generic;

    /// <summary>
    /// The base class for assembly resolvers with the local-default filter
    /// </summary>
    public abstract class AssemblyResolverBase
        :IAssemblyResolver
    {
        IStructuralTypeConfigurationFilter _filter;

        /// <summary>
        /// Get the filter used for check structural type configurations
        /// </summary>
        public IStructuralTypeConfigurationFilter Filter
        {
            get
            {
                if (_filter == null)
                    _filter = new DefaultStructuralTypeConfigurationFilter();

                return _filter;
            }
            set
            {
                _filter = value;
            }
        }

        IStructuralTypeConfigurationActivator _activator;

        /// <summary>
        /// Get the activator used for creating structural type configuration instances
        /// </summary>
        public IStructuralTypeConfigurationActivator Activator
        {
            get
            {
                if (_activator == null)
                    _activator = new DefaultStructuralTypeConfigurationActivator();

                return _activator;
            }
            set
            {
                _activator = value;
            }
        }

        /// <summary>
        /// Solve the struyctural type configurations
        /// </summary>
        /// <returns>A collection of structural type configurations instances</returns>
        public abstract IEnumerable<dynamic> SolveStructuralTypeConfigurations();

    }
}
