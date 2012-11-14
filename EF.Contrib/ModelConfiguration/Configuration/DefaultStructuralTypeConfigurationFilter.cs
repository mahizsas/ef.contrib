namespace EF.Contrib.EntityTypeConfiguration.ModelConfiguartion.Configuration
{
    using System;
    using System.Data.Entity.ModelConfiguration;
    using System.Diagnostics.Contracts;
    using System.Linq;


    /// <summary>
    /// the local-default for <see cref="EF.Contrib.EntityTypeConfiguration.IStructuralTypeConfigurationFilter"/>
    /// </summary>
    public class DefaultStructuralTypeConfigurationFilter
        :IStructuralTypeConfigurationFilter
    {
        /// <summary>
        /// <see cref="EF.Contrib.EntityTypeConfiguration.IStructuralTypeConfigurationFilter"/>
        /// </summary>
        /// <param name="type"><see cref="EF.Contrib.EntityTypeConfiguration.IStructuralTypeConfigurationFilter"/></param>
        /// <returns><see cref="EF.Contrib.EntityTypeConfiguration.IStructuralTypeConfigurationFilter"/></returns>
        public bool IsStructuralTypeConfiguration(Type type)
        {
            Contract.Requires(type != null);

            if (type.BaseType != null && (type.BaseType.GenericTypeArguments.Length ==1))
            {
                //get the structural type associated with this configuration
                var structuralType = type.BaseType.GenericTypeArguments[0];

                if (structuralType.IsClass)
                {
                    var entityTypeConfiguration = typeof(EntityTypeConfiguration<>).MakeGenericType(structuralType);
                    var complexTypeConfiguration = typeof(ComplexTypeConfiguration<>).MakeGenericType(structuralType);

                    if (type.BaseType == entityTypeConfiguration
                        ||
                        type.BaseType == complexTypeConfiguration)
                    {
                        //ie, if type is a complex or entity type configuration

                        return true;
                    }
                }
            }

            return false;
        }
    }
}
