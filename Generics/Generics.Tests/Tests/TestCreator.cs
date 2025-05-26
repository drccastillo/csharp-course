using Generics;

namespace Generics.Tests
{
    public class TestCreator
    {
        private class ConfigurableStub : IConfigurable
        {
            public bool Configured { get; private set; }
            public void Configure() => Configured = true;
        }

        [Fact]
        public void Create_ShouldReturnNewInstanceOfConfigurable()
        {
            var creator = new Creator<ConfigurableStub>();
            var instance = creator.Create();
            Assert.NotNull(instance);
            Assert.IsType<ConfigurableStub>(instance);
        }

        [Fact]
        public void Create_InstanceShouldBeIndependent()
        {
            var creator = new Creator<ConfigurableStub>();
            var instance1 = creator.Create();
            var instance2 = creator.Create();
            Assert.NotSame(instance1, instance2);
        }

        [Fact]
        public void Create_ShouldCallConfigure_WhenUsedWithConfigurable()
        {
            var creator = new Creator<ConfigurableStub>();
            var instance = creator.Create();
            instance.Configure();
            Assert.True(instance.Configured);
        }
    }
}
