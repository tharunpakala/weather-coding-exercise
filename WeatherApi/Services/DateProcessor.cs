using WeatherApi.Models;

namespace WeatherApi.Services
{
    /// <summary>
    /// Reads date lines from a file and parses them using an IDateParser.
    /// </summary>
    public class DateProcessor
    {
        private readonly IDateParser _dateParser;

        public DateProcessor(IDateParser dateParser)
        {
            _dateParser = dateParser ?? throw new ArgumentNullException(nameof(dateParser));
        }

        /// <summary>
        /// Read all non-empty lines from the specified file and parse each line.
        /// </summary>
        /// <param name="filePath">Path to the dates file (e.g., "dates.txt").</param>
        public async Task<IEnumerable<DateParseResult>> ProcessFileAsync(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException(nameof(filePath));

            var inputDates = await File.ReadAllLinesAsync(filePath);

            var results = inputDates    
                .Where(date => !string.IsNullOrWhiteSpace(date))
                .Select(date => _dateParser.Parse(date.Trim()))
                .ToList();

            return results;
        }
    }
}
