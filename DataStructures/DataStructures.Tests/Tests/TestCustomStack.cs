namespace DataStructures.Tests
{
    public class TestCustomStack
    {
        [Fact]
        public void Push_ShouldIncreaseCount()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);

            Assert.Equal(2, stack.Count);
        }

        [Theory]
        [InlineData("Andres")]
        [InlineData("Junior")]
        [InlineData("Marcelo")]
        public void Pop_ShouldReturnAndRemoveTopElement(string item)
        {
            var stack = new CustomStack<string>();
            stack.Push("A");
            stack.Push("B");
            stack.Push(item);

            string result = stack.Pop();

            Assert.Equal(item, result);
            Assert.Equal(2, stack.Count);
        }

        [Theory]
        [InlineData('X')]
        [InlineData('Y')]
        [InlineData('Z')]
        public void Peek_ShouldReturnTopWithoutRemoving(char last)
        {
            var stack = new CustomStack<char>();
            stack.Push('a');
            stack.Push(last);

            char result = stack.Peek();

            Assert.Equal(last, result);
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrueWhenStackIsEmpty()
        {
            var stack = new CustomStack<char>();
            stack.Push('a');

            Assert.False(stack.IsEmpty());

            stack.Pop();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void IsEmpty_StackIsEmptyOnCreation()
        {
            var stack = new CustomStack<double>();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void Peek_ShouldThrow_WhenEmpty()
        {
            var stack = new CustomStack<double>();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Pop_ShouldThrow_WhenEmpty()
        {
            var stack = new CustomStack<double>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void ToArray_ShouldReturnElementsFromTopToBottom()
        {
            var stack = new CustomStack<char>();
            stack.Push('1');
            stack.Push('2');
            stack.Push('3');

            var result = stack.ToArray();
            Assert.Equal(new[] { '3', '2', '1' }, result);
        }
    }
}
