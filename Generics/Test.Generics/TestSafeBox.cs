using Generics;

namespace Test.Generics
{
    public class TestSafeBox
    {
        // IMPLEMENTED: Add positive scenario
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
