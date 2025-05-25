using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Tests
{
    public class TestDynamicArray
    {
        [Fact]
        public void Add_ShouldIncreaseCount()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(10);
            dynamicArray.Add(20);
            dynamicArray.Add(30);

            Assert.Equal(3, dynamicArray.Count);
            Assert.Equal(10, dynamicArray.Get(0));
            Assert.Equal(20, dynamicArray.Get(1));
            Assert.Equal(30, dynamicArray.Get(2));
        }

        [Fact]
        public void Get_ShouldThrow_WhenIndexOutOfBound()
        {
            var dynamicArray = new DynamicArray<string>(10);
            dynamicArray.Add("hello");

            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicArray.Get(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicArray.Get(1));
        }

        [Fact]
        public void Set_ShouldUpdateValue()
        {
            var dynamicArray = new DynamicArray<string>();
            dynamicArray.Add("Jose");
            var oldCount = dynamicArray.Count;
            
            dynamicArray.Set(0, "Cristian");
            var newCount = dynamicArray.Count;

            Assert.Equal(oldCount, newCount);
            Assert.Equal("Cristian", dynamicArray.Get(0));
        }

        [Fact]
        public void InsertAt_ShouldInsertCorrectly()
        {
            var dynamicArray = new DynamicArray<string>();
            dynamicArray.Add("Jose");
            dynamicArray.Add("Jessica");

            dynamicArray.InsertAt(1, "Cristian");

            Assert.Equal(3, dynamicArray.Count);
            Assert.Equal("Jose", dynamicArray.Get(0));
            Assert.Equal("Cristian", dynamicArray.Get(1));
            Assert.Equal("Jessica", dynamicArray.Get(2));
        }

        [Fact]
        public void InsertAt_ShouldThrow_WhenOutOfRange()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);

            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicArray.InsertAt(-1, 23));
            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicArray.InsertAt(3, 23));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void RemoveAt_ShouldThrow_WhenOutOfRange(int index)
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicArray.RemoveAt(index));
        }

        [Fact]
        public void RemoveAt_ShouldShiftElementsAndDecreaseCount()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);

            dynamicArray.RemoveAt(1);

            Assert.Equal(2, dynamicArray.Count);
            Assert.Equal(1, dynamicArray.Get(0));
            Assert.Equal(3, dynamicArray.Get(1));
        }

        [Fact]
        public void Add_WhenCapacityExceeded_ShouldDoubleCapacity()
        {
            var dynamicArray = new DynamicArray<int>(2);
            Assert.Equal(2, dynamicArray.Capacity);

            dynamicArray.Add(1);
            dynamicArray.Add(2);
            // capacity should remain same
            Assert.Equal(2, dynamicArray.Capacity);

            dynamicArray.Add(3);
            // capacity should double to 4
            Assert.Equal(4, dynamicArray.Capacity);

            // ensure elements are correctly stored
            Assert.Equal(3, dynamicArray.Count);
            Assert.Equal(1, dynamicArray.Get(0));
            Assert.Equal(2, dynamicArray.Get(1));
            Assert.Equal(3, dynamicArray.Get(2));
        }

        [Fact]
        public void Indexer_GetAndSet_ShouldWorkAsExpected()
        {
            var dynamicArray = new DynamicArray<string>();
            dynamicArray.Add("A");
            dynamicArray.Add("B");
            dynamicArray.Add("C");

            Assert.Equal("A", dynamicArray[0]);
            Assert.Equal("B", dynamicArray[1]);
            Assert.Equal("C", dynamicArray[2]);

            dynamicArray[1] = "BB";
            Assert.Equal("BB", dynamicArray[1]);
        }

        [Fact]
        public void Contains_ShouldReturnTrueIfExists()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(10);
            dynamicArray.Add(20);
            Assert.True(dynamicArray.Contains(20));
            Assert.False(dynamicArray.Contains(30));
        }

        [Fact]
        public void IndexOf_ShouldReturnCorrectIndexOrMinusOne()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);
            Assert.Equal(0, dynamicArray.IndexOf(1));
            Assert.Equal(2, dynamicArray.IndexOf(3));
            Assert.Equal(-1, dynamicArray.IndexOf(4));
        }

        [Fact]
        public void Clear_ShouldResetArray()
        {
            var dynamicArray = new DynamicArray<string>();
            dynamicArray.Add("A");
            dynamicArray.Add("B");
            dynamicArray.Clear();
            Assert.Equal(0, dynamicArray.Count);
            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicArray.Get(0));
        }

        [Fact]
        public void Enumeration_ShouldIterateThroughElements()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);
            var list = new List<int>();
            foreach (var item in dynamicArray)
                list.Add(item);
            Assert.Equal(new[] { 1, 2, 3 }, list.ToArray());
        }
    }
}