using System;
using WeatherApp.Models;
using Xunit;

namespace WeatherApp.Tests.Models
{
    public class CoordinatesTests
    {
        [Theory]
        [InlineData("1.5,2.5", 1.5, 2.5)]
        [InlineData("-10.0,0.0", -10.0, 0.0)]
        public void Parse_ValidInput_ReturnsCoordinates(string input, double expectedLat, double expectedLon)
        {
            var coord = Coordinates.Parse(input);
            Assert.Equal(expectedLat, coord.Latitude);
            Assert.Equal(expectedLon, coord.Longitude);
        }

        [Theory]
        [InlineData("", typeof(ArgumentException))]
        [InlineData("  ", typeof(ArgumentException))]
        [InlineData("invalid", typeof(FormatException))]
        [InlineData("1.0", typeof(FormatException))]
        [InlineData("1.0,2.0,3.0", typeof(FormatException))]
        public void Parse_InvalidInput_Throws(string input, Type expectedExceptionType)
        {
            Assert.Throws(expectedExceptionType, () => Coordinates.Parse(input));
        }
    }
}