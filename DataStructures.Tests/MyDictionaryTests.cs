using System;
using DataStructures.Dictionary;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests
{
    [TestClass]
    public class MyDictionaryTests
    {
        [TestMethod]
        public void Index_WhenKeyAlreadyExists_ShouldThrowException()
        {
            // Arrange
            var myHashTable = new MyDictionary<int, string>();
            myHashTable.Add(1, "1");

            // Act
            Action sut = () => myHashTable.Add(1, "1");

            // Assert
            sut.Should().Throw<ArgumentException>()
                .WithMessage("An item with the same key has already been added '1'");
        }

        [TestMethod]
        public void Add_WhenKeyAlreadyExists_ShouldThrowException()
        {
            // Arrange
            var myHashTable = new MyDictionary<int, string>();

            // Act
            myHashTable.Add(1, "1");
            myHashTable.Add(2, "2");
            myHashTable.Add(17, "17");

            // Assert
            myHashTable.Count.Should().Be(3);

            myHashTable[1].Should().Be("1");
            myHashTable[2].Should().Be("2");
            myHashTable[17].Should().Be("17");
        }

        [TestMethod]
        public void Add_WithValueKey_ShouldAddElement()
        {
            // Arrange
            var myHashTable = new MyDictionary<int, string>();

            // Act
            myHashTable.Add(1, "1");
            myHashTable.Add(2, "2");
            myHashTable.Add(17, "17");

            // Assert
            myHashTable.Count.Should().Be(3);

            myHashTable[1].Should().Be("1");
            myHashTable[2].Should().Be("2");
            myHashTable[17].Should().Be("17");
        }

        [TestMethod]
        public void Add_WithReferenceKey_ShouldAddElement()
        {
            // Arrange
            var myHashTable = new MyDictionary<string, string>();

            // Act
            myHashTable.Add("1", "1");
            myHashTable.Add("2", "2");

            // Assert
            myHashTable.Count.Should().Be(2);

            myHashTable["1"].Should().Be("1");
            myHashTable["2"].Should().Be("2");
        }

        [TestMethod]
        public void Remove_WithReferenceKey_ShouldRemoveElement()
        {
            // Arrange
            var myHashTable = new MyDictionary<string, string>();
            myHashTable.Add("1", "1");

            // Act
            myHashTable.Remove("1");

            // Assert
            myHashTable.Count.Should().Be(0);
        }

        [TestMethod]
        public void Remove_WithReferenceKey_ShouldRemoveCorrectElement()
        {
            // Arrange
            var myHashTable = new MyDictionary<string, string>();
            myHashTable.Add("1", "1");
            myHashTable.Add("2", "1");
            myHashTable.Add("3", "1");
            myHashTable.Add("4", "1");
            myHashTable.Add("5", "1");

            // Act
            myHashTable.Remove("1");

            // Assert
            myHashTable.Count.Should().Be(4);

            for (int i = 2; i <= 5; i++)
            {
                myHashTable[i.ToString()].Should().Be("1");
            }
        }

        [TestMethod]
        public void Clear_WithReferenceKey_ShouldClearDictionary()
        {
            // Arrange
            var myHashTable = new MyDictionary<string, string>();
            myHashTable.Add("1", "1");
            myHashTable.Add("2", "1");
            myHashTable.Add("3", "1");
            myHashTable.Add("4", "1");
            myHashTable.Add("5", "1");

            // Act
            myHashTable.Clear();

            // Assert
            myHashTable.Count.Should().Be(0);
        }


        [TestMethod]
        public void Index_WhenKeyDoesNotExist_ShouldThrowException()
        {
            // Arrange
            var myHashTable = new MyDictionary<string, string>();

            // Act
            Func<string> sut = () => myHashTable["foo"];

            // Assert
            myHashTable.Count.Should().Be(0);

            sut.Should().Throw<ArgumentException>()
                        .WithMessage("The given key 'foo' was not present in the dictionary");
        }
    }
}
