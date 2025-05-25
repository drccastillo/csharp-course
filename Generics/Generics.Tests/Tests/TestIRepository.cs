using Generics;

namespace Generics.Tests
{
    public class TestIRepository
    {
        [Fact]
        public void IRepository_ShouldAddAndGetValue()
        {
            var repository = new MemoryRepository<string>();
            repository.Add("Item1");
            var result = repository.Find(1);
            Assert.NotNull(result);
            Assert.Equal("Item1", result);
        }

        [Fact]
        public void Repository_GetInvalidId_ShouldReturnDefault()
        {
            var repository = new MemoryRepository<string>();
            var result = repository.Find(999);
            Assert.Null(result);
        }
    }

    public class MemoryRepository<T> : IRepository<T>
    {
        private readonly Dictionary<int, T> _store = new();
        private int _counter = 0;

        public void Add(T entity)
        {
            _store[++_counter] = entity;
        }

        public T Find(int id)
        {
            return _store.TryGetValue(id, out var item) ? item : default;
        }
    }
}
