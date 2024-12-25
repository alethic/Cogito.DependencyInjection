using System;

using Microsoft.Extensions.DependencyInjection;

namespace Cogito.DependencyInjection
{

    /// <summary>
    /// Registers the decorated implementation type as a transient service.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class AddTransientServiceAttribute<TServiceType> : Attribute, IServiceRegistrationAttribute
    {

        /// <inheritdoc />
        public virtual int RegistrationOrder => 0;

        /// <inheritdoc />
        public void Add(IServiceCollection services, Type type)
        {
            services.AddTransient(typeof(TServiceType), type);
        }

    }

    /// <summary>
    /// Registers the decorated implementation type as a transient service.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class AddTransientServiceAttribute : Attribute, IServiceRegistrationAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AddTransientServiceAttribute()
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
                services.AddTransient(ServiceType, type);
            else
                services.AddTransient(type);
        }

    }

}
