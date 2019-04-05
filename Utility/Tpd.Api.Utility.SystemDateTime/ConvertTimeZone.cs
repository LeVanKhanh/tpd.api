using System;
using System.Collections;
using System.Linq;

namespace Tpd.Api.Utility.SystemDateTime
{
    public static class ConvertTimeZone
    {
        public const string utcTimeZonId = "UTC";

        public static DateTime Convert(this DateTime source, string sourceTimeZone, string destinationTimeZone)
        {
            if (string.IsNullOrEmpty(sourceTimeZone) || string.IsNullOrEmpty(destinationTimeZone) || sourceTimeZone.Equals(destinationTimeZone))
            {
                return DateTime.MinValue;
            }

            TimeZoneInfo srcTimeZoneInfo;
            TimeZoneInfo desTimeZoneInfor;

            if (sourceTimeZone == utcTimeZonId)
            {
                srcTimeZoneInfo = TimeZoneInfo.Utc;
            }
            else
            {
                srcTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sourceTimeZone);
            }

            if (destinationTimeZone == utcTimeZonId)
            {
                desTimeZoneInfor = TimeZoneInfo.Utc;
            }
            else
            {
                desTimeZoneInfor = TimeZoneInfo.FindSystemTimeZoneById(destinationTimeZone);
            }

            source = DateTime.SpecifyKind(source, DateTimeKind.Unspecified);

            return TimeZoneInfo.ConvertTime(source, srcTimeZoneInfo, desTimeZoneInfor);
        }

        public static DateTime? Convert(this DateTime? source, string sourceTimeZone, string destinationTimeZone)
        {
            if (source != null)
            {
                return source.Value.Convert(sourceTimeZone, destinationTimeZone);
            }
            return null;
        }

        public static object Convert(object obj, string sourceTimeZone, string destinationTimeZone)
        {
            if (obj == null)
            {
                return null;
            }

            if (obj is DateTime)
            {
                return ((DateTime)obj).Convert(sourceTimeZone, destinationTimeZone);
            }

            if (obj is DateTime?)
            {
                return ((DateTime?)obj).Convert(sourceTimeZone, destinationTimeZone);
            }

            var properties = obj.GetType().GetProperties();

            var propertyDateTimes = properties.Where(w => w.PropertyType == typeof(DateTime) || w.GetType() == typeof(DateTime?));

            var propertyObjects = properties.Except(propertyDateTimes).Where(w => !w.PropertyType.IsValueType
                                            && w.PropertyType != typeof(string));

            foreach (var propertyDateTime in propertyDateTimes)
            {
                var sourceValue = propertyDateTime.GetValue(obj);
                var converted = Convert(sourceValue, sourceTimeZone, destinationTimeZone);
                propertyDateTime.SetValue(obj, converted, null);
            }

            foreach (var propertyInfo in propertyObjects)
            {
                var propertyType = propertyInfo.PropertyType;
                var propValue = propertyInfo.GetValue(obj);

                if (propValue is IEnumerable)
                {
                    var enumerable = (IEnumerable)propValue;
                    foreach (var item in enumerable)
                    {
                        var converted = Convert(item, sourceTimeZone, destinationTimeZone);
                        propertyInfo.SetValue(obj, converted, null);
                    }
                }
                else
                {
                    var converted = Convert(propValue, sourceTimeZone, destinationTimeZone);
                    propertyInfo.SetValue(obj, converted, null);
                }
            }

            return obj;
        }

        public static void Globalize(this IConvertTimeZone obj, string localTimeZone, string globalTimeZone = utcTimeZonId)
        {
            Convert(obj, localTimeZone, globalTimeZone);
        }

        public static void Localize(this IConvertTimeZone obj, string localTimeZone, string globalTimeZone = utcTimeZonId)
        {
            Convert(obj, globalTimeZone, localTimeZone);
        }

        public static DateTime Globalize(this DateTime source, string localTimeZone, string globalTimeZone = utcTimeZonId)
        {
            return source.Convert(localTimeZone, globalTimeZone);
        }

        public static DateTime Localize(this DateTime source, string localTimeZone, string globalTimeZone = utcTimeZonId)
        {
            return source.Convert(globalTimeZone, localTimeZone);
        }

        public static DateTime? Globalize(this DateTime? source, string localTimeZone, string globalTimeZone = utcTimeZonId)
        {
            return source.Convert(localTimeZone, globalTimeZone);
        }

        public static DateTime? Localize(this DateTime? source, string localTimeZone, string globalTimeZone = utcTimeZonId)
        {
            return source.Convert(globalTimeZone, localTimeZone);
        }
    }
}
