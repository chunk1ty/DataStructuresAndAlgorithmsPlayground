using DataStructures.DoublyLinkedList;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests
{
    [TestClass]
    public class MyDoublyLinkedListTests
    {
        [TestMethod]
        public void Add_ShouldAddElements()
        {
            // Arrange
            MyDoublyLinkedList<int> myDoublyLinkedList = new MyDoublyLinkedList<int>();

            // Act
            myDoublyLinkedList.AddToTail(3);
            myDoublyLinkedList.AddToHead(2);
            myDoublyLinkedList.AddToTail(4);
            myDoublyLinkedList.AddToHead(1);
            myDoublyLinkedList.AddToTail(5);

            // Assert

            myDoublyLinkedList.Count.Should().Be(5);

            int index = 1;
            foreach (var element in myDoublyLinkedList)
            {
                element.Should().Be(index);
                index++;
            }
        }

        [TestMethod]
        public void Clear_ShouldClearCollection()
        {
            // Arrange
            MyDoublyLinkedList<int> myDoublyLinkedList = new MyDoublyLinkedList<int>();

            myDoublyLinkedList.AddToTail(3);
            myDoublyLinkedList.AddToHead(2);
            myDoublyLinkedList.AddToTail(4);
            myDoublyLinkedList.AddToHead(1);
            myDoublyLinkedList.AddToTail(5);

            // Act
            myDoublyLinkedList.Clear();

            // Assert
            myDoublyLinkedList.Count.Should().Be(0);
            myDoublyLinkedList.Head.Should().BeNull();
            myDoublyLinkedList.Tail.Should().BeNull();
        }

        [TestMethod]
        public void Contains_ShouldReturnTrue()
        {
            // Arrange
            MyDoublyLinkedList<int> myDoublyLinkedList = new MyDoublyLinkedList<int>();

            myDoublyLinkedList.AddToTail(3);
            myDoublyLinkedList.AddToHead(2);
            myDoublyLinkedList.AddToTail(4);
            myDoublyLinkedList.AddToHead(1);
            myDoublyLinkedList.AddToTail(5);

            // Act
            var result = myDoublyLinkedList.Contains(5);

            // Assert
            result.Should().Be(true);
        }

        [TestMethod]
        public void Remove_ShouldRemoveSuccessfullyItemInTheMiddle()
        {
            // Arrange
            MyDoublyLinkedList<int> myDoublyLinkedList = new MyDoublyLinkedList<int>();

            myDoublyLinkedList.AddToTail(5);
            myDoublyLinkedList.AddToTail(23);
            myDoublyLinkedList.AddToTail(76);

            // Act
            var result = myDoublyLinkedList.Remove(23);

            // Assert
            result.Should().Be(true);

            myDoublyLinkedList.Count.Should().Be(2);

            myDoublyLinkedList.Head.Value.Should().Be(5);
            myDoublyLinkedList.Head.Next.Value.Should().Be(76);
            myDoublyLinkedList.Head.Previous.Should().BeNull();

            myDoublyLinkedList.Tail.Value.Should().Be(76);
            myDoublyLinkedList.Tail.Next.Should().BeNull();
            myDoublyLinkedList.Tail.Previous.Value.Should().Be(5);
        }

        [TestMethod]
        public void Remove_ShouldRemoveSuccessfullyFirstOccurrence()
        {
            // Arrange
            MyDoublyLinkedList<int> myDoublyLinkedList = new MyDoublyLinkedList<int>();

            myDoublyLinkedList.AddToTail(5);
            myDoublyLinkedList.AddToTail(23);
            myDoublyLinkedList.AddToTail(23);
            myDoublyLinkedList.AddToTail(76);

            // Act
            var result = myDoublyLinkedList.Remove(23);

            // Assert
            result.Should().Be(true);

            myDoublyLinkedList.Count.Should().Be(3);

            myDoublyLinkedList.Head.Value.Should().Be(5);
            myDoublyLinkedList.Head.Next.Value.Should().Be(23);
            myDoublyLinkedList.Head.Previous.Should().BeNull();

            myDoublyLinkedList.Tail.Value.Should().Be(76);
            myDoublyLinkedList.Tail.Next.Should().BeNull();
            myDoublyLinkedList.Tail.Previous.Value.Should().Be(23);
        }

        [TestMethod]
        public void Remove_ShouldRemoveSuccessfullyItemInTheEnd()
        {
            // Arrange
            MyDoublyLinkedList<int> myDoublyLinkedList = new MyDoublyLinkedList<int>();

            myDoublyLinkedList.AddToTail(5);
            myDoublyLinkedList.AddToTail(23);
            myDoublyLinkedList.AddToTail(76);

            // Act
            var result = myDoublyLinkedList.Remove(76);

            // Assert
            result.Should().Be(true);

            myDoublyLinkedList.Count.Should().Be(2);

            myDoublyLinkedList.Head.Value.Should().Be(5);
            myDoublyLinkedList.Head.Next.Value.Should().Be(23);
            myDoublyLinkedList.Head.Previous.Should().BeNull();

            myDoublyLinkedList.Tail.Value.Should().Be(23);
            myDoublyLinkedList.Tail.Next.Should().BeNull();
            myDoublyLinkedList.Tail.Previous.Value.Should().Be(5);
        }

        [TestMethod]
        public void Remove_ShouldRemoveSuccessfullyItemInTheBeginning()
        {
            // Arrange
            MyDoublyLinkedList<int> myDoublyLinkedList = new MyDoublyLinkedList<int>();

            myDoublyLinkedList.AddToTail(5);
            myDoublyLinkedList.AddToTail(23);
            myDoublyLinkedList.AddToTail(76);

            // Act
            var result = myDoublyLinkedList.Remove(5);

            // Assert
            result.Should().Be(true);

            myDoublyLinkedList.Count.Should().Be(2);

            myDoublyLinkedList.Head.Value.Should().Be(23);
            myDoublyLinkedList.Head.Next.Value.Should().Be(76);
            myDoublyLinkedList.Head.Previous.Should().BeNull();

            myDoublyLinkedList.Tail.Value.Should().Be(76);
            myDoublyLinkedList.Tail.Next.Should().BeNull();
            myDoublyLinkedList.Tail.Previous.Value.Should().Be(23);
        }

        [TestMethod]
        public void Remove_ShouldNotRemoveItem()
        {
            // Arrange
            MyDoublyLinkedList<int> myDoublyLinkedList = new MyDoublyLinkedList<int>();

            myDoublyLinkedList.AddToTail(5);
            myDoublyLinkedList.AddToTail(23);
            myDoublyLinkedList.AddToTail(76);

            // Act
            var result = myDoublyLinkedList.Remove(42);

            // Assert
            result.Should().Be(false);

            myDoublyLinkedList.Count.Should().Be(3);

            myDoublyLinkedList.Head.Value.Should().Be(5);
            myDoublyLinkedList.Head.Next.Value.Should().Be(23);
            myDoublyLinkedList.Head.Previous.Should().BeNull();

            myDoublyLinkedList.Tail.Value.Should().Be(76);
            myDoublyLinkedList.Tail.Next.Should().BeNull();
            myDoublyLinkedList.Tail.Previous.Value.Should().Be(23);
        }
    }
}