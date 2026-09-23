using System;
using WeatherApi.Services;
using Xunit;

namespace WeatherApi.Tests
{
    public class DateParserTests
    {
        private readonly DateParser _parser = new DateParser();

        [Fact]
        public void Parse_MMddyyyy_ReturnsNormalized()
        {
            // Arrange
            var input = "02/27/2021";

            // Act
            var result = _parser.Parse(input);

            // Assert
            Assert.True(result.IsValid);
            Assert.Equal("2021-02-27", result.Normalized);
        }

        [Fact]
        public void Parse_FullMonth_ReturnsNormalized()
        {
            // Arrange
            var input = "June 2, 2022";

            // Act
            var result = _parser.Parse(input);

            // Assert
            Assert.True(result.IsValid);
            Assert.Equal("2022-06-02", result.Normalized);
        }

        [Fact]
        public void Parse_MonthDate_ReturnsNormalizedDate()
        {
            // Arrange
            var input = "Jul-13-2020";

            // Act
            var result = _parser.Parse(input);

            // Assert
            Assert.True(result.IsValid);
            Assert.Equal("2020-07-13", result.Normalized);
        }

        [Fact]
        public void Parse_InvalidCalendarDate_ReturnsFailure()
        {
            // Arrange
            var input = "April 31, 2022";

            // Act
            var result = _parser.Parse(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.False(string.IsNullOrWhiteSpace(result.ErrorMessage));
        }
    }
}
