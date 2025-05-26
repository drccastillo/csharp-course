using Generics;

namespace Generics.Tests
{
    public class TestPrinter
    {
        private readonly Printer _printer = new();

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        [InlineData(-5, -5)]
        public void GetOrDefault_WithIntValue_ReturnsSameValue(int input, int expected)
        {
            int result = _printer.GetOrDefault(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3.14, 3.14)]
        [InlineData(0.0, 0.0)]
        public void GetOrDefault_WithDoubleValue_ReturnsSameValue(double input, double expected)
        {
            double result = _printer.GetOrDefault(input);
            Assert.Equal(expected, result, 3);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GetOrDefault_WithBoolValue_ReturnsSameValue(bool input)
        {
            bool result = _printer.GetOrDefault(input);
            Assert.Equal(input, result);
        }

        [Theory]
        [InlineData("hello")]
        [InlineData("")]
        public void GetOrDefault_WithNonNullString_ReturnsSameString(string input)
        {
            string result = _printer.GetOrDefault(input);
            Assert.Equal(input, result);
        }

        [Fact]
        public void GetOrDefault_WithNullString_ReturnsNull()
        {
            string result = _printer.GetOrDefault<string>(null);
            Assert.Null(result);
        }

        [Fact]
        public void GetOrDefault_WithNullNullableInt_ReturnsNull()
        {
            int? input = null;
            var result = _printer.GetOrDefault(input);
            Assert.Null(result);
        }

        [Fact]
        public void GetOrDefault_WithNonNullNullableInt_ReturnsSameValue()
        {
            int? input = 99;
            var result = _printer.GetOrDefault(input);
            Assert.Equal(99, result);
        }

        [Fact]
        public void GetOrDefault_WithNullObject_ReturnsNull()
        {
            Person person = null;
            var result = _printer.GetOrDefault(person);
            Assert.Null(result);
        }

        [Fact]
        public void GetOrDefault_WithObject_ReturnsSameObject()
        {
            var person = new Person { Name = "Lucia" };
            var result = _printer.GetOrDefault(person);
            Assert.Same(person, result);
            Assert.Equal("Lucia", result.Name);
        }

        [Fact]
        public void GetOrDefault_WithNullReferenceType_ReturnsNull()
        {
            object result = _printer.GetOrDefault<object>(null);
            Assert.Null(result);
        }

        [Fact]
        public void GetOrDefault_WithStructDefault_ReturnsDefault()
        {
            int result = _printer.GetOrDefault<int>(default);
            Assert.Equal(0, result);
        }

        public class Person
        {
            public string Name { get; set; }
        }
    }
}
