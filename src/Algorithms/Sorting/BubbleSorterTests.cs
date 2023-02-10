using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorting
{
    [TestClass]
    public class BubbleSorterTests
    {
        [TestMethod]
        public void Sort_WithRandomNumbers_ShouldSortCollection()
        {
            // Arrange
            var bubbleSorter = new BubbleSorter();

            // Act
            var collection = new List<int>() { 4, 5, 3, 8, 2, 6, 10, 7, 9, 1 };
            bubbleSorter.Sort(collection);

            // Act
            collection.Count.Should().Be(10);

            for (int i = 1; i <= 10; i++)
            {
                collection[i - 1].Should().Be(i);
            }
        }

        [TestMethod]
        public void Sort_WithOneNumber_ShouldSortCollection()
        {
            // Arrange
            var bubbleSorter = new BubbleSorter();

            // Act
            var collection = new List<int>() { 4 };
            bubbleSorter.Sort(collection);

            // Act
            collection.Count.Should().Be(1);
            collection.First().Should().Be(4);
        }
    }
}
