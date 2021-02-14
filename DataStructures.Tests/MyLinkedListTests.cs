using DataStructures.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests
{
    [TestClass]
    public class MyLinkedListTests
    {
        [TestMethod]
        public void ShouldBeEmpty()
        {
            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
            Assert.AreEqual(0, myLinkedList.Count);
        }

        [TestMethod]
        public void AddHead_ShouldAddSuccessfullyItem()
        {
            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                myLinkedList.AddFirst(i);
            }

            int expected = 5;
            foreach (int item in myLinkedList)
            {
                Assert.AreEqual(expected--, item);
            }
            Assert.AreEqual(5, myLinkedList.Count);
        }

        [TestMethod]
        public void AddTail_ShouldAddSuccessfullyItem()
        {
            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                myLinkedList.AddLast(i);
            }

            int expected = 1;
            foreach (int item in myLinkedList)
            {
                Assert.AreEqual(expected++, item);
            }
            Assert.AreEqual(5, myLinkedList.Count);
        }

        [TestMethod]
        public void Remove_ShouldRemoveSuccessfullyItem()
        {
            MyLinkedList<int> myLinkedList = Create(1, 10);

            for (int i = 1; i <= 10; i++)
            {
                Assert.IsTrue(myLinkedList.Remove(i));
                Assert.IsFalse(myLinkedList.Remove(i));
            }

            Assert.AreEqual(0, myLinkedList.Count);
        }

        [TestMethod]
        public void Contains_ShouldReturnFalse()
        {
            MyLinkedList<int> myLinkedList = Create(1, 10);

            Assert.IsFalse(myLinkedList.Contains(0));
            Assert.IsFalse(myLinkedList.Contains(11));
        }
        
        [TestMethod]
        public void Contains_ShouldReturnTrue()
        {
            MyLinkedList<int> myLinkedList = Create(1, 10);
            for (int i = 1; i <= 10; i++)
            {
                Assert.IsTrue(myLinkedList.Contains(i));
            }
        }

        private MyLinkedList<int> Create(int start, int end)
        {
            MyLinkedList<int> ints = new MyLinkedList<int>();
            for (int i = start; i <= end; i++)
            {
                ints.AddLast(i);
            }

            return ints;
        }
    }
}