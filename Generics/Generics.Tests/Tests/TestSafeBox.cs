using Generics;

namespace Generics.Tests
{
    public class TestSafeBox
    {
        [Fact]
        public void SafeBox_ShouldStoreValue()
        {
            var box = new SafeBox<string>("hello");
            Assert.Equal("hello", box.Value);
        }

        [Fact]
        public void SafeBox_ShouldThrowIfNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SafeBox<string>(null));
        }

        [Fact]
        public void SafeBox_ShouldStoreValue_TypeInt()
        {
            var box = new SafeBox<int>(42);
            Assert.Equal(42, box.Value);
        }

        [Fact]
        public void SafeBox_ShouldThrowIfNullReferenceType()
        {
            Assert.Throws<ArgumentNullException>(() => new SafeBox<object>(null));
        }

        [Fact]
        public void SafeBox_ShouldAllowDefaultForValueType()
        {
            var box = new SafeBox<int>(default);
            Assert.Equal(0, box.Value);
        }
    }
}
