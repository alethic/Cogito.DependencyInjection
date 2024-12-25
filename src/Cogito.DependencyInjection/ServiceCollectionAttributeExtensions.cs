using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace Cogito.DependencyInjection
{

    /// <summary>
    /// Provides extension methods against <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {

        /// <summary>s
        /// Registers all types by their decorated registration attributes.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="assemblies"></param>
        public static void AddFromAttributes(this IServiceCollection builder, params Assembly[] assemblies)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (assemblies == null)
                throw new ArgumentNullException(nameof(assemblies));

            builder.AddFromAttributes((IEnumerable<Assembly>)assemblies);
        }

        /// <summary>s
        /// Registers all types by their decorated registration attributes.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="assemblies"></param>
        public static void AddFromAttributes(this IServiceCollection builder, IEnumerable<Assembly> assemblies)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (assemblies == null)
                throw new ArgumentNullException(nameof(assemblies));

            builder.AddFromAttributes(assemblies.SelectMany(i => GetAssemblyTypesSafe(i)));
        }

        /// <summary>
        /// Registers all specified types by their decorated registration attributes.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="types"></param>
        public static void AddFromAttributes(this IServiceCollection builder, params Type[] types)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (types == null)
                throw new ArgumentNullException(nameof(types));

            AddFromAttributes(builder, (IEnumerable<Type>)types);
        }

        /// <summary>
        /// Registers all specified types by their decorated registration attributes.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="types"></param>
        public static void AddFromAttributes(this IServiceCollection builder, IEnumerable<Type> types)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (types == null)
                throw new ArgumentNullException(nameof(types));

            // group by unique registration handler types
            var items = types
                .Select(i => i.GetTypeInfo())
                .Select(i => new { ImplementationType = i, Attributes = i.GetCustomAttributes(typeof(IRegistrationAttribute), true).Cast<IRegistrationAttribute>() })
                .SelectMany(i => i.Attributes.Select(j => new { i.ImplementationType, Attribute = j }))
                .OrderBy(i => i.Attribute.RegistrationOrder);

            // dispatch to associated handler
            foreach (var item in items)
                item.Attribute.Register(builder, item.ImplementationType);
        }

        /// <summary>
        /// Registers the specified type by it's decorated registration attributes.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="type"></param>
        public static void AddFromAttributes(this IServiceCollection builder, Type type)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            // group by unique registration handler types
            var items = type.GetTypeInfo()
                .GetCustomAttributes(typeof(IRegistrationAttribute), true)
                .Cast<IRegistrationAttribute>()
                .OrderBy(i => i.RegistrationOrder);

            // dispatch to associated handler
            foreach (var item in items)
                item.Register(builder, type);
        }

        /// <summary>
        /// Catch exceptions when loading types.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        static ICollection<Type> GetAssemblyTypesSafe(this Assembly assembly)
        {
            var l = new List<Type>();

            try
            {
                l.AddRange(assembly.GetTypes().Where(i => i != null));
            }
            catch (ReflectionTypeLoadException e)
            {
                foreach (var t in e.Types)
                {
                    try
                    {
                        if (t != null)
                            l.Add(t);
                    }
                    catch (BadImageFormatException)
                    {
                        // ignore
                    }
                }
            }

            return l;
        }

    }

}
