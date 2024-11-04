using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Subscription.DistributedCaches
{
   public static class KeyDistributedCacheExtention<TValue> 
    {
        public static readonly TimeSpan Duration = TimeSpan.FromSeconds(60);
        private static readonly TValue HomeKey = (TValue)(object)"HomeKey";

        public static string ItemKeyGenerate<TFilter>(TFilter filter) where TFilter : class
        {
            var keyParts = new List<string>
        {
            typeof(TFilter).Name,
            $"Term-{GetPropertyValue<string>(filter, "Term") ?? "None"}"
        };

            return string.Join(":", keyParts);
        }

        private static TProperty GetPropertyValue<TProperty>(object obj, string propertyName)
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            return propertyInfo != null ? (TProperty)propertyInfo.GetValue(obj) : default;
        }

        public static TValue HomeKeyGenerate()
        {
            if (typeof(TValue) == typeof(string))
            {
                return (TValue)(object) HomeKey;
            }
            return default(TValue);
        }
    }
}
