using FluentAssertions;
using Xunit;

namespace BinarySearch;

public class BinarySearcherTests
{
    [Theory]
    [InlineData(9, 4)]
    [InlineData(-1, 0)]
    [InlineData(12, 5)]
    [InlineData(-2, -1)]
    [InlineData(13, -1)]
    [InlineData(4, -1)]
    public void SearchByIteration_ShouldFindElement(int target, int targetIndex)
    {
        // Arrange
        var binarySearcher = new BinarySearcher();
        
        // Act
        var index = binarySearcher.SearchByIteration(new[] { -1, 0, 3, 5, 9, 12 }, target);
        
        // Assert
        index.Should().Be(targetIndex);
    }
    
    [Theory]
    [InlineData(9, 4)]
    [InlineData(-1, 0)]
    [InlineData(12, 5)]
    [InlineData(-2, -1)]
    [InlineData(13, -1)]
    [InlineData(4, -1)]
    public void SearchByRecursion_ShouldFindElement(int target, int targetIndex)
    {
        // Arrange
        var binarySearcher = new BinarySearcher();
        
        // Act
        var index = binarySearcher.SearchByRecursion(new[] { -1, 0, 3, 5, 9, 12 }, target);
        
        // Assert
        index.Should().Be(targetIndex);
    }
}