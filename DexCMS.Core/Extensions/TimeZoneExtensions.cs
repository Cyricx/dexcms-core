using System;

namespace DexCMS.Core.Extensions
{
    public static class TimeZoneExtensions
    {
        public static string TimeZoneAbbreviation(this TimeZoneInfo zone)
        {
            var zoneName = zone.Id;
            var zoneAbbr = zoneName.CapitalLetters();
            return zoneAbbr;
        }
    }
}
