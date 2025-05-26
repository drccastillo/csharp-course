using Generics;

namespace Generics.Tests
{
    public class TestBox
    {
        [Fact]
        public void Box_ShouldStoreIntValue()
        {
            var intBox = new Box<int> { Value = 10 };

            Assert.Equal(10, intBox.Value);
        }

        [Fact]
        public void Box_ShouldStoreStringValue()
        {
            var intBox = new Box<string> { Value = "Hello" };

            Assert.Equal("Hello", intBox.Value);
        }

        [Fact]
        public void Box_DefaultValueShouldBeZeroForIntegerValueType()
        {
            var box = new Box<int>();
            Assert.Equal(0, box.Value);
        }

        [Fact]
        public void Box_DefaultValueShouldBeZeroForBooleanValueType()
        {
            var box = new Box<bool>();
            Assert.False(box.Value);
        }

        [Fact]
        public void Box_ShouldStoreAndRetrieveReferenceType()
        {
            var obj = new object();
            var box = new Box<object> { Value = obj };
            Assert.Same(obj, box.Value);
        }

        [Fact]
        public void Box_ShouldAllowNullForReferenceType()
        {
            var box = new Box<object> { Value = null };
            Assert.Null(box.Value);
        }
    }
}