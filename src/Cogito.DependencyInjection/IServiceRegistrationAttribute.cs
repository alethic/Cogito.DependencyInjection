using System;

using Microsoft.Extensions.DependencyInjection;

namespace Cogito.DependencyInjection
{

    /// <summary>
    /// Implement this interface in a custom attribute to extend registration.
    /// </summary>
    public interface IServiceRegistrationAttribute
    {

        /// <summary>
        /// Integer to determine sort order of registrations.
        /// </summary>
        int RegistrationOrder { get; }

        /// <summary>
        /// Implement this method to handle registration.
        /// </summary>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        void Add(IServiceCollection services, Type implementationType);

    }

}
