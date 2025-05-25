using Generics;

namespace Generics.Tests
{
    public class TestCalculator
    {
        [Fact]
        public void Calculator_Add_ShouldReturnSum()
        {
            var calc = new Calculator<int>();
            Assert.Equal(5, calc.Add(2, 3));
        }

        [Fact]
        public void Calculator_Substract_ShouldReturnDifference()
        {
            var calc = new Calculator<int>();
            Assert.Equal(2, calc.Substract(5, 3));
        }

        [Fact]
        public void Calculator_Multiply_ShouldReturnProduct()
        {
            var calc = new Calculator<int>();
            Assert.Equal(6, calc.Multiply(2, 3));
        }

        [Fact]
        public void Calculator_Divide_ShouldReturnQuotient()
        {
            var calc = new Calculator<int>();
            Assert.Equal(2, calc.Divide(6, 3));
        }

        [Fact]
        public void Calculator_Divide_ByZero_ShouldThrow()
        {
            var calc = new Calculator<int>();
            Assert.Throws<DivideByZeroException>(() => calc.Divide(6, 0));
        }
    }
}
