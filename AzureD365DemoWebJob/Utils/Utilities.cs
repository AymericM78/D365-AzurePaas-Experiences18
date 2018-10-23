using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureD365DemoWebJob
{
    public static class Constants
    {
        /// <summary>
        /// Default value for missing property in JSON
        /// </summary>
        public const string MissingPropertyValue = "{MissingValue}";
    }
    public static class JsonExtensions
    {
        /// <summary>
        /// Indicates if JSON property string is not missing after serialization
        /// </summary>
        /// <param name="property">Property to evaluate</param>
        /// <returns>If <code>true</code>, then the property is not missing. Otherwise <code>false</code></returns>
        public static bool IsJsonPropertyDefined(this string property)
        {
            return (property != Constants.MissingPropertyValue);
        }

        /// <summary>
        /// Indicates if JSON property integer is not missing after serialization
        /// </summary>
        /// <param name="property">Property to evaluate</param>
        /// <returns>If <code>true</code>, then the property is not missing. Otherwise <code>false</code></returns>
        public static bool IsJsonPropertyDefined(this int? property)
        {
            if (!property.HasValue)
            {
                return true;
            }

            return (property.Value != int.MinValue);
        }

    }
    public static class JsonHelper
    {
        /// <summary>
        /// Transform json message to target object type
        /// </summary>
        /// <typeparam name="T">Target type</typeparam>
        /// <param name="message">Json message</param>
        /// <returns></returns>
        public static T ConvertTo<T>(string message)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
            };

            return JsonConvert.DeserializeObject<T>(message, jsonSerializerSettings);
        }
    }

    public static class Utilities
    {
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        public static List<List<T>> ChunkBy<T>(this IEnumerable<T> source, Func<T, long> metric, long maxChunkSize)
        {
            return source.Aggregate(
                    new
                    {
                        Sum = 0L,
                        Current = (List<T>)null,
                        Result = new List<List<T>>()
                    },
                    (agg, item) =>
                    {
                        var value = metric(item);
                        if (agg.Current == null || agg.Sum + value > maxChunkSize)
                        {
                            var current = new List<T> { item };
                            agg.Result.Add(current);
                            return new { Sum = value, Current = current, agg.Result };
                        }

                        agg.Current.Add(item);
                        return new { Sum = agg.Sum + value, agg.Current, agg.Result };
                    })
                .Result;
        }

        /// <summary>
        /// Extract record per second speed
        /// </summary>
        /// <returns></returns>
        public static string GetSpeed(long elapsedMilliseconds, int numberOfOperations)
        {
            return Math.Round((numberOfOperations * 1.0 / elapsedMilliseconds * 1000), 2).ToString() + " rec/sec";
        }
    }
}
