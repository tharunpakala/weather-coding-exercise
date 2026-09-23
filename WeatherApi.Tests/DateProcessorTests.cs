using WeatherApi.Services;
using Xunit;

namespace WeatherApi.Tests;

public class DateProcessorTests : IDisposable
{
    private readonly string _tempFilePath =
        Path.Combine(Path.GetTempPath(), $"dates_test.txt");

    private static DateProcessor CreateProcessor()
    {
        return new DateProcessor(new DateParser());
    }

    [Fact]
    public async Task ProcessFileAsync_ReturnsThreeValidAndOneInvalidResult()
    {
        // Arrange
        var lines = new[]
        {
            "02/27/2021",
            "June 2, 2022",
            "Jul-13-2020",
            "April 31, 2022"
        };

        await File.WriteAllLinesAsync(_tempFilePath, lines);
        var processor = CreateProcessor();

        // Act
        var results = (await processor.ProcessFileAsync(_tempFilePath)).ToList();

        // Assert
        Assert.Equal(4, results.Count);
        Assert.Equal(3, results.Count(r => r.IsValid));
        Assert.Single(results.Where(r => !r.IsValid));

        var invalidResult = results.Single(r => !r.IsValid);

        Assert.Null(invalidResult.Normalized);
        Assert.NotNull(invalidResult.ErrorMessage);
    }

    [Fact]
    public async Task ProcessFileAsync_IgnoresEmptyLines()
    {
        // Arrange
        var lines = new[]
        {
            "02/27/2021",
            "",
            "   ",
            "Jul-13-2020"
        };

        await File.WriteAllLinesAsync(_tempFilePath, lines);
        var processor = CreateProcessor();

        // Act
        var results = (await processor.ProcessFileAsync(_tempFilePath)).ToList();

        // Assert
        Assert.Equal(2, results.Count);
        Assert.All(results, result => Assert.True(result.IsValid));
    }

    [Fact]
    public async Task ProcessFileAsync_NullPath_ThrowsArgumentNullException()
    {
        var processor = CreateProcessor();

        await Assert.ThrowsAsync<ArgumentNullException>(
            () => processor.ProcessFileAsync(null!));
    }

    public void Dispose()
    {
        if (File.Exists(_tempFilePath))
        {
            File.Delete(_tempFilePath);
        }
    }
}