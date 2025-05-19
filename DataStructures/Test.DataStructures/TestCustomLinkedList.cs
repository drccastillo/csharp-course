namespace Test.DataStructures
{
    public class TestCustomLinkedList
    {
        [Fact]
        public void Add_ShouldIncreaseCount()
        {
            var list = new CustomLinkedList<string>();
            list.AddFirst("Carlos");
            list.AddFirst("Sergio");
            list.AddFirst("Fabricio");

            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void AddFirst_ShouldAddElementToHead()
        {
            var list = new CustomLinkedList<string>();
            list.AddFirst("Carlos");
            list.AddFirst("Sergio");
            list.AddFirst("Fabricio");

            var result = list.Get(0);

            Assert.Equal("Fabricio", result);
        }

        [Fact]
        public void AddLast_ShouldAddElementToTail()
        {
            var list = new CustomLinkedList<string>();
            list.AddLast("Carlos");
            list.AddLast("Sergio");
            list.AddLast("Fabricio");

            var result = list.Get(2);

            Assert.Equal("Fabricio", result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(3)]
        public void Get_ShouldThrow_WhenIndexOutOfRange(int index)
        {
            var list = new CustomLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(index));
        }

        [Fact]
        public void Contains_ShouldReturnTrueIfExists()
        {
            var list = new CustomLinkedList<string>();
            list.AddLast("Carlos");
            list.AddLast("Sergio");
            list.AddLast("Fabricio");

            Assert.True(list.Contains("Carlos"));
            Assert.True(list.Contains("Sergio"));
            Assert.True(list.Contains("Fabricio"));
            Assert.False(list.Contains("<random>"));
        }

        [Fact]
        public void TryRemove_ShouldRemoveMatchedElement()
        {
            var list = new CustomLinkedList<string>();
            list.AddLast("Carlos");
            list.AddLast("Sergio");
            list.AddLast("Fabricio");

            bool result = list.TryRemove("Sergio");

            Assert.True(result);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void TryRemove_ShouldNotRemoveMatchedElementIfNotFound()
        {
            var list = new CustomLinkedList<string>();
            list.AddLast("Carlos");
            list.AddLast("Sergio");
            list.AddLast("Fabricio");
            var oldLength = list.Count;

            bool result = list.TryRemove("Melissa");

            Assert.False(result);
            Assert.Equal(oldLength, list.Count);
        }

        [Fact]
        public void ToArray_ShouldReturnArrayWithAllElementInLinkedList()
        {
            var list = new CustomLinkedList<string>();
            list.AddLast("Carlos");
            list.AddLast("Sergio");
            list.AddLast("Fabricio");

            // IMPLEMENTED: Uncomment
            var array = list.ToArray();

            Assert.NotNull(array);
            Assert.Equal(new[] { "Carlos", "Sergio", "Fabricio" }, array);
        }
    }
}
