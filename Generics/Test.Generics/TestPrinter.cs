using Generics;

namespace Test.Generics
{
    public class TestPrinter
    {
        // IMPLEMENTED: Add more tests for Printer

        [Fact]
        public void GetOrDefault_SHouldReturnDefaultIfNull()
        {
            var printer = new Printer();
            string result = printer.GetOrDefault<string>(null);
            Assert.Null(result);
        }

        [Fact]
        public void GetOrDefault_SHouldReturnGivenValue()
        {
            var printer = new Printer();
            int result = printer.GetOrDefault(10);
            Assert.Equal(10, result);
        }
    }
}
