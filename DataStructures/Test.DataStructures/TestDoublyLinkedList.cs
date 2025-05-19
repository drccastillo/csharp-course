namespace Test.DataStructures
{
    public class TestDoublyLinkedList
    {
        [Fact]
        public void AddFirst_ShouldInsertAtFront()
        {
            var list = new DoublyLinkedList<string>();
            list.AddFirst("Carlos");
            list.AddFirst("Sergio");
            list.AddFirst("Fabricio");

            var result = list.Get(0);

            Assert.Equal("Fabricio", result);
        }

        [Fact]
        public void AddLast_ShouldInsertAtEnd()
        {
            var list = new DoublyLinkedList<string>();
            list.AddLast("Carlos");
            list.AddLast("Sergio");
            list.AddLast("Fabricio");

            var result = list.Get(2);

            Assert.Equal("Fabricio", result);
        }

        [Fact]
        public void ToReversedArray_ShouldReturnCorrectReverseOrder()
        {
            // IMPLEMENTED: Complete the test
            var list = new DoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.Equal(new[] { 3, 2, 1 }, list.ToReversedArray());
        }

        [Fact]
        public void Get_ShouldReturnCorrectElement()
        {
            // IMPLEMENTED: Complete the test
            var list = new DoublyLinkedList<char>();
            list.AddLast('A');
            list.AddLast('B');
            list.AddLast('C');

            Assert.Equal('A', list.Get(0));
            Assert.Equal('B', list.Get(1));
            Assert.Equal('C', list.Get(2));
        }

        [Fact]
        public void Get_ShouldThrow_WhenIndexInvalid()
        {
            // IMPLEMENTED: Complete test
            var list = new DoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(3));
        }

        [Fact]
        public void Contains_ShouldReturnTrueIfValueExists()
        {
            // IMPLEMENTED: Complete test
            var list = new DoublyLinkedList<string>();
            list.AddLast("Carlos");
            list.AddLast("Sergio");
            list.AddLast("Fabricio");

            Assert.True(list.Contains("Carlos"));
            Assert.False(list.Contains("Melissa"));
        }

        [Fact]
        public void Remove_ShouldRemoveExistingValue()
        {
            // IMPLEMENTED: Complete test
            var list = new DoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            bool result = list.TryRemove(2);

            Assert.True(result);
            Assert.Equal(2, list.Count);
            Assert.Equal(new[] { 1, 3 }, list.ToArray());
        }

        [Fact]
        public void Remove_ShouldReturnFalseIfNotFound()
        {
            // IMPLEMENTED: Complete test
            var list = new DoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            var oldCount = list.Count;
            bool result = list.TryRemove(4);

            Assert.False(result);
            Assert.Equal(oldCount, list.Count);
            Assert.Equal(new[] { 1, 2, 3 }, list.ToArray());
        }

        // OPTIONAL: Add more tests if wanted
    }
}
