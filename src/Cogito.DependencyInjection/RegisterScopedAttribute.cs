using System;

using Microsoft.Extensions.DependencyInjection;

namespace Cogito.DependencyInjection
{

    /// <summary>
    /// Registers the decorated implementation type as a scoped service.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class RegisterScopedAttribute<TServiceType> : Attribute, IRegistrationAttribute
    {

        /// <inheritdoc />
        public virtual int RegistrationOrder => 0;

        /// <inheritdoc />
        public void Register(IServiceCollection services, Type type)
        {
            services.AddScoped(typeof(TServiceType), type);
        }

    }

    /// <summary>
    /// Registers the decorated implementation type as a scoped service.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class RegisterScopedAttribute : Attribute, IRegistrationAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public RegisterScopedAttribute()
        {

        }

        /// <summary>
        /// Optionally sets the service type.
        /// </summary>
        public Type? ServiceType { get; set; }

        /// <inheritdoc />
        public virtual int RegistrationOrder => 0;

        /// <inheritdoc />
        public void Register(IServiceCollection services, Type type)
        {
            if (ServiceType != null)
                services.AddScoped(ServiceType, type);
            else
                services.AddScoped(type);
        }

    }

}
