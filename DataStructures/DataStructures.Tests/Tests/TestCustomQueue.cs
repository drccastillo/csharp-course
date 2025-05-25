namespace DataStructures.Tests
{
    public class TestCustomQueue
    {
        [Fact]
        public void Enqueue_ShouldIncreaseCountAndMaintainOrder()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Equal(3, queue.Count);
            Assert.Equal(new[] { 1, 2, 3 }, queue.ToArray());
        }

        [Fact]
        public void Dequeue_ShouldReturnAndRemoveFrontElement()
        {
            var queue = new CustomQueue<char>();
            queue.Enqueue('A');
            queue.Enqueue('B');

            char result = queue.Dequeue();

            Assert.Equal(1, queue.Count);
            Assert.Equal('A', result);
        }

        [Fact]
        public void Dequeue_ShouldThrow_WhenQueueIsEmpty()
        {
            var queue = new CustomQueue<char>();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Peek_ShouldReturnFrontWithoutRemoving()
        {
            var queue = new CustomQueue<char>();
            queue.Enqueue('A');
            queue.Enqueue('B');

            char result = queue.Peek();

            Assert.Equal(2, queue.Count);
            Assert.Equal('A', result);
        }

        [Fact]
        public void Peek_ShouldThrow_WhenQueueIsEmpty()
        {
            var queue = new CustomQueue<char>();

            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrueOnlyWhenEmpty()
        {
            var queue = new CustomQueue<int>();

            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void ToArray_ShouldReturnElementsInOrder()
        {
            var queue = new CustomQueue<string>();
            queue.Enqueue("Cristian");
            queue.Enqueue("Darwin");
            queue.Enqueue("Jose");

            Assert.Equal(new[] { "Cristian", "Darwin", "Jose" }, queue.ToArray());
        }
    }
}
