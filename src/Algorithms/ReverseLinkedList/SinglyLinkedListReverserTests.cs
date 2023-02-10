using FluentAssertions;
using Xunit;

namespace ReverseLinkedList;

public class SinglyLinkedListReverserTests
{
    [Fact]
    public void Reverse_ShouldReverseList()
    {
        // Arrange
        var singlyLinkedListReverser = new SinglyLinkedListReverser();
        
        // Act
        var newHead = singlyLinkedListReverser.Reverse(new Node(1, new Node(2, new Node(3, new Node(4, new Node(5))))));

        int expectedValue = 5;
        while (newHead != null)
        {
            newHead.Value.Should().Be(expectedValue);

            newHead = newHead.Next;
            expectedValue--;
        }
    }
}