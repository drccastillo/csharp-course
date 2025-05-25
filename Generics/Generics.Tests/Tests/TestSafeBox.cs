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
    }
}
