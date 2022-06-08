using NUnit.Framework;

namespace SinglyLinkedList
{
    [TestFixture]
    public class MySinglyLinkedListTests
    {
        [Test]
        public void ShouldBeEmpty()
        {
            MySinglyLinkedList<int> mySinglyLinkedList = new MySinglyLinkedList<int>();
            Assert.AreEqual(0, mySinglyLinkedList.Count);
        }

        [Test]
        public void AddHead_ShouldAddSuccessfullyItem()
        {
            MySinglyLinkedList<int> mySinglyLinkedList = new MySinglyLinkedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                mySinglyLinkedList.AddToHead(i);
            }

            int expected = 5;
            foreach (int item in mySinglyLinkedList)
            {
                Assert.AreEqual(expected--, item);
            }
            Assert.AreEqual(5, mySinglyLinkedList.Count);
        }

        [Test]
        public void AddTail_ShouldAddSuccessfullyItem()
        {
            MySinglyLinkedList<int> mySinglyLinkedList = new MySinglyLinkedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                mySinglyLinkedList.AddToTail(i);
            }

            int expected = 1;
            foreach (int item in mySinglyLinkedList)
            {
                Assert.AreEqual(expected++, item);
            }
            Assert.AreEqual(5, mySinglyLinkedList.Count);
        }

        [Test]
        public void Remove_ShouldRemoveSuccessfullyItem()
        {
            MySinglyLinkedList<int> mySinglyLinkedList = Create(1, 10);

            for (int i = 1; i <= 10; i++)
            {
                Assert.IsTrue(mySinglyLinkedList.Remove(i));
                Assert.IsFalse(mySinglyLinkedList.Remove(i));
            }

            Assert.AreEqual(0, mySinglyLinkedList.Count);
        }

        [Test]
        public void Contains_ShouldReturnFalse()
        {
            MySinglyLinkedList<int> mySinglyLinkedList = Create(1, 10);

            Assert.IsFalse(mySinglyLinkedList.Contains(0));
            Assert.IsFalse(mySinglyLinkedList.Contains(11));
        }
        
        [Test]
        public void Contains_ShouldReturnTrue()
        {
            MySinglyLinkedList<int> mySinglyLinkedList = Create(1, 10);
            for (int i = 1; i <= 10; i++)
            {
                Assert.IsTrue(mySinglyLinkedList.Contains(i));
            }
        }

        private MySinglyLinkedList<int> Create(int start, int end)
        {
            MySinglyLinkedList<int> ints = new MySinglyLinkedList<int>();
            for (int i = start; i <= end; i++)
            {
                ints.AddToTail(i);
            }

            return ints;
        }
    }
}