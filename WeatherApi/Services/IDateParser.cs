using WeatherApi.Models;

namespace WeatherApi.Services
{
    /// <summary>
    /// Parses a single date string into a DateParseResult.
    /// </summary>
    public interface IDateParser
    {
        DateParseResult Parse(string input);
    }
}
