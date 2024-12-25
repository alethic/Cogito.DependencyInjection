using System;

using Microsoft.Extensions.DependencyInjection;

namespace Cogito.DependencyInjection
{

    /// <summary>
    /// Registers the decorated implementation type as a transient service.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class RegisterTransientAttribute<TServiceType> : Attribute, IRegistrationAttribute
    {

        /// <inheritdoc />
        public virtual int RegistrationOrder => 0;

        /// <inheritdoc />
        public void Register(IServiceCollection services, Type type)
        {
            services.AddTransient(typeof(TServiceType), type);
        }

    }

    /// <summary>
    /// Registers the decorated implementation type as a transient service.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class RegisterTransientAttribute : Attribute, IRegistrationAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public RegisterTransientAttribute()
        {

        }

        /// <summary>
        /// Optionally sets the service type.
        /// </summary>
        public Type? ServiceType { get; }

        /// <inheritdoc />
        public virtual int RegistrationOrder => 0;

        /// <inheritdoc />
        public void Register(IServiceCollection services, Type type)
        {
            if (ServiceType != null)
                services.AddTransient(ServiceType, type);
            else
                services.AddTransient(type);
        }

    }

}
