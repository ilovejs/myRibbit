using System;

namespace RibbitMVC.Models
{
    public static class RibbitExtensions
    {
        public static string FriendlyTimestamp(this Ribbit ribbit)
        {
            var now = DateTime.Now;
            var date = ribbit.DateCreated;
            var span = now - date;

            // > 24hours
            if (span > TimeSpan.FromHours(24))
            {
                return date.ToString("MM dd");
            }

            if (span > TimeSpan.FromMinutes(60))
            {
                return string.Format("{0}h", span.Hours);
            }

            if (span > TimeSpan.FromSeconds(60))
            {
                return string.Format("{0}m", span.Minutes);
            }
            return "now";
        }
    }
}