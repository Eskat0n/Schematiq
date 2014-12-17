namespace Schematiq.Extensions
{
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using JetBrains.Annotations;

    internal static class PropertyInfoExtensions
    {
        [CanBeNull]
        public static string GetConfigurationPropertyName([NotNull] this PropertyInfo propertyInfo)
        {
            var attribute = propertyInfo.GetCustomAttributes(typeof (ConfigurationPropertyAttribute), true)
                .Cast<ConfigurationPropertyAttribute>()
                .SingleOrDefault();

            return attribute?.Name;
        }
    }
}