namespace EF.Contrib.ModelConfiguration.Configuration
{
    using EF.Contrib.Resources.System;
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Structural type configuration activator 
    /// </summary>
    public class DefaultStructuralTypeConfigurationActivator
        :IStructuralTypeConfigurationActivator
    {
        /// <summary>
        /// <see cref="EF.Contrib.ModelConfiguration.Configuration.IStructuralTypeConfigurationActivator"/>
        /// </summary>
        /// <param name="configurationType"><see cref="EF.Contrib.ModelConfiguration.Configuration.IStructuralTypeConfigurationActivator"/></param>
        /// <returns><see cref="EF.Contrib.ModelConfiguration.Configuration.IStructuralTypeConfigurationActivator"/></returns>
        public object Create(Type configurationType)
        {
            Contract.Requires(configurationType != null);

            var defaultConstructor = configurationType.GetConstructor(Type.EmptyTypes);

            if (defaultConstructor != null)
                return Activator.CreateInstance(configurationType);

            throw new InvalidOperationException(Strings.ConstructorWithArguments(configurationType));
        }
    }
}
