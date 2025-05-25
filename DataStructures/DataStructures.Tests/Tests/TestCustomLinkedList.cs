using System.Linq;
using System.Collections.Generic;

namespace DataStructures.Tests
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

            var array = list.ToArray();

            Assert.NotNull(array);
            Assert.Equal(new[] { "Carlos", "Sergio", "Fabricio" }, array);
        }

        [Fact]
        public void Indexer_ShouldReturnElementAtIndex()
        {
            var list = new CustomLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
            Assert.Equal(3, list[2]);
        }

        [Fact]
        public void Clear_ShouldRemoveAllElements()
        {
            var list = new CustomLinkedList<string>();
            list.AddLast("A");
            list.AddLast("B");

            list.Clear();

            Assert.Equal(0, list.Count);
            Assert.Empty(list);
        }

        [Fact]
        public void Enumeration_ShouldIterateThroughElements()
        {
            var list = new CustomLinkedList<string>();
            list.AddLast("X");
            list.AddLast("Y");
            list.AddLast("Z");

            var result = list.Select(x => x).ToArray();
            Assert.Equal(new[] { "X", "Y", "Z" }, result);
        }
    }
}
