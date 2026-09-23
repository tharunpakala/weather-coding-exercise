using System;
using System.Globalization;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    /// <summary>
    /// Parses date strings using a set of strict formats. Does not throw on invalid input.
    /// </summary>
    public class DateParser : IDateParser
    {
        private static readonly string[] SupportedFormats = new[]
        {
            "MM/dd/yyyy",      
            "MMMM d, yyyy",
            "MMMM dd, yyyy",   
            "MMM-d-yyyy",      
            "MMM-dd-yyyy"      
        };

        private readonly CultureInfo _culture = CultureInfo.InvariantCulture;

        public DateParseResult Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return DateParseResult.Failure(input ?? string.Empty, "Input was empty or whitespace.");
            }

            var trimmed = input.Trim();

            if (DateTime.TryParseExact(trimmed, SupportedFormats, _culture, DateTimeStyles.None, out var dt))
            {
                return DateParseResult.Success(trimmed, dt);
            }

            return DateParseResult.Failure(trimmed, "Unrecognized or invalid date.");
        }
    }
}
