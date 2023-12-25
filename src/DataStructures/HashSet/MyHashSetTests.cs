using FluentAssertions;
using NUnit.Framework;

namespace HashSet;

[TestFixture]
public class MyHashSetTests
{
    [Test]
    public void Add_WithMultipleSameValues_ShouldAddOnlyOneValueType()
    {
        // Arrange
        var myHashSet = new MyHashSet<int>();
        
        // Act
        myHashSet.Add(1);
        myHashSet.Add(1);
        myHashSet.Add(1);
        
        // Assert
        myHashSet.Count.Should().Be(1);
        myHashSet.Contains(1).Should().BeTrue();
    }
    
    [Test]
    public void Add_WithMultipleSameValues_ShouldAddOnlyOneReferenceType()
    {
        // Arrange
        var myHashSet = new MyHashSet<string>();
        
        // Act
        myHashSet.Add("ank");
        myHashSet.Add("ank");
        myHashSet.Add("ank");
        
        // Assert
        myHashSet.Count.Should().Be(1);
        myHashSet.Contains("ank").Should().BeTrue();
    }
    
    [Test]
    public void Add_WithMultipleValues_ShouldRehash()
    {
        // Arrange
        int items = 100;
        var myHashSet = new MyHashSet<int>();
        
        // Act
        for (int i = 1; i <= items; i++)
        {
            myHashSet.Add(i);
        }
        
        // Assert
        myHashSet.Count.Should().Be(items);
        for (int i = 1; i <= items; i++)
        {
            myHashSet.Contains(i).Should().BeTrue();
        }
    }
    
    [Test]
    public void Remove_WhenValueExist_ShouldRemoveIt()
    {
        // Arrange
        var myHashSet = new MyHashSet<int>();
        myHashSet.Add(1);
        
        // Act
        myHashSet.Remove(1);
        
        // Assert
        myHashSet.Count.Should().Be(0);
        myHashSet.Contains(1).Should().BeFalse();
    }
    
    [Test]
    public void Remove_WhenValueDoesNotExist_ShouldNotRemoveIt()
    {
        // Arrange
        var myHashSet = new MyHashSet<int>();
        myHashSet.Add(1);
        
        // Act
        myHashSet.Remove(2);
        
        // Assert
        myHashSet.Count.Should().Be(1);
        myHashSet.Contains(1).Should().BeTrue();
    }
    
    [Test]
    public void Contains_WhenValueExist_ShouldReturnTrue()
    {
        // Arrange
        var myHashSet = new MyHashSet<int>();
        myHashSet.Add(1);
        
        // Act
        bool result = myHashSet.Contains(1);
        
        // Assert
        myHashSet.Count.Should().Be(1);
        result.Should().BeTrue();
    }
    
    [Test]
    public void Contains_WhenValueDoesNotExist_ShouldReturnFalse()
    {
        // Arrange
        var myHashSet = new MyHashSet<int>();
        myHashSet.Add(1);
        
        // Act
        bool result = myHashSet.Contains(2);
        
        // Assert
        myHashSet.Count.Should().Be(1);
        result.Should().BeFalse();
    }
}