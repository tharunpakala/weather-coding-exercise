using System;

namespace WeatherApi.Models
{
    /// <summary>
    /// Result of attempting to parse a single date input string.
    /// </summary>
    public record DateParseResult
    {
        public bool IsValid { get; init; }
        public string? Normalized { get; init; }
        public string? ErrorMessage { get; init; }

        public static DateParseResult Success(string original, DateTime date)
        {
            return new DateParseResult
            {
                IsValid = true,
                Normalized = date.ToString("yyyy-MM-dd")
            };
        }

        public static DateParseResult Failure(string original, string errorMessage)
        {
            return new DateParseResult
            {
                IsValid = false,
                Normalized = null,
                ErrorMessage = errorMessage
            };
        }
    }
}
