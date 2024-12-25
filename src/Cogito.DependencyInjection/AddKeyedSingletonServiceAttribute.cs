using System;

using Microsoft.Extensions.DependencyInjection;

namespace Cogito.DependencyInjection
{

    /// <summary>
    /// Registers the decorated implementation type as a singleton service.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class AddKeyedSingletonServiceAttribute<TServiceType> : Attribute, IServiceRegistrationAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="serviceKey"></param>
        public AddKeyedSingletonServiceAttribute(object? serviceKey)
        {
            ServiceKey = serviceKey;
        }

        /// <summary>
        /// Gets the service key.
        /// </summary>
        public object? ServiceKey { get; set; }

        /// <inheritdoc />
        public virtual int RegistrationOrder => 0;

        /// <inheritdoc />
        public void Add(IServiceCollection services, Type type)
        {
            services.AddKeyedSingleton(typeof(TServiceType), ServiceKey, type);
        }

    }

    /// <summary>
    /// Registers the decorated implementation type as a singleton service.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class AddKeyedSingletonServiceAttribute : Attribute, IServiceRegistrationAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="serviceKey"></param>
        public AddKeyedSingletonServiceAttribute(object? serviceKey)
        {
            ServiceKey = serviceKey;
        }

        /// <summary>
        /// Gets the service key.
        /// </summary>
        public object? ServiceKey { get; set; }

        /// <summary>
        /// Optionally sets the service type.
        /// </summary>
        public Type? ServiceType { get; set; }

        /// <inheritdoc />
        public virtual int RegistrationOrder => 0;

        /// <inheritdoc />
        public void Add(IServiceCollection services, Type type)
        {
            services.AddKeyedSingleton(ServiceType ?? type, ServiceKey, type);
        }

    }

}
