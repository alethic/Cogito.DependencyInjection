using System;

using Microsoft.Extensions.DependencyInjection;

namespace Cogito.DependencyInjection
{

    /// <summary>
    /// Registers the decorated implementation type as a singleton service.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class AddSingletonServiceAttribute<TServiceType> : Attribute, IServiceRegistrationAttribute
    {

        /// <inheritdoc />
        public virtual int RegistrationOrder => 0;

        /// <inheritdoc />
        public void Add(IServiceCollection services, Type type)
        {
            services.AddSingleton(typeof(TServiceType), type);
        }

    }

    /// <summary>
    /// Registers the decorated implementation type as a singleton instance.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class AddSingletonServiceAttribute : Attribute, IServiceRegistrationAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AddSingletonServiceAttribute()
        {

        }

        /// <summary>
        /// Optionally sets the service type.
        /// </summary>
        public Type? ServiceType { get; }

        /// <inheritdoc />
        public virtual int RegistrationOrder => 0;

        /// <inheritdoc />
        public void Add(IServiceCollection services, Type type)
        {
            if (ServiceType != null)
                services.AddSingleton(ServiceType, type);
            else
                services.AddSingleton(type);
        }

    }

}
