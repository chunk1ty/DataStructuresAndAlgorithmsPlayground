using FluentAssertions;
using NUnit.Framework;

namespace BinarySearchTree;

public class Tests
{

    [Test]
    public void Insert_ShouldAddElementToBSTProperly()
    {
        // Arrange
        var binarySearchTree = new BinarySearchTree();

        // Act
        binarySearchTree.Insert(45);
        binarySearchTree.Insert(15);
        binarySearchTree.Insert(79);
        binarySearchTree.Insert(90);
        binarySearchTree.Insert(10);
        binarySearchTree.Insert(55);
        binarySearchTree.Insert(12);
        binarySearchTree.Insert(20);
        binarySearchTree.Insert(50);

        // Assert
        binarySearchTree.Root.Value.Should().Be(45);

        binarySearchTree.Root.Left.Value.Should().Be(15);
        binarySearchTree.Root.Right.Value.Should().Be(79);

        binarySearchTree.Root.Left.Left.Value.Should().Be(10);
        binarySearchTree.Root.Left.Right.Value.Should().Be(20);
        binarySearchTree.Root.Right.Left.Value.Should().Be(55);
        binarySearchTree.Root.Right.Right.Value.Should().Be(90);

        binarySearchTree.Root.Left.Left.Right.Value.Should().Be(12);
        binarySearchTree.Root.Right.Left.Left.Value.Should().Be(50);
    }

    [Test]
    public void TraverseInOrder_ShouldTraverseBSTProperly()
    {
        // Arrange
        var binarySearchTree = new BinarySearchTree();

        binarySearchTree.Insert(45);
        binarySearchTree.Insert(15);
        binarySearchTree.Insert(79);
        binarySearchTree.Insert(90);
        binarySearchTree.Insert(10);
        binarySearchTree.Insert(55);
        binarySearchTree.Insert(12);
        binarySearchTree.Insert(20);
        binarySearchTree.Insert(50);

        // Act
        var items = binarySearchTree.TraverseInOrder();

        items[0].Should().Be(10);
        items[1].Should().Be(12); 
        items[2].Should().Be(15); 
        items[3].Should().Be(20); 
        items[4].Should().Be(45); 
        items[5].Should().Be(50); 
        items[6].Should().Be(55); 
        items[7].Should().Be(79); 
        items[8].Should().Be(90); 
    }

    [TestCase(45)]
    [TestCase(15)]
    [TestCase(79)]
    [TestCase(90)]
    [TestCase(10)]
    [TestCase(55)]
    [TestCase(12)]
    [TestCase(20)]
    [TestCase(50)]
    public void ContainsValue_ShouldContainsValue(int value)
    {
        // Arrange
        var binarySearchTree = new BinarySearchTree();

        binarySearchTree.Insert(45);
        binarySearchTree.Insert(15);
        binarySearchTree.Insert(79);
        binarySearchTree.Insert(90);
        binarySearchTree.Insert(10);
        binarySearchTree.Insert(55);
        binarySearchTree.Insert(12);
        binarySearchTree.Insert(20);
        binarySearchTree.Insert(50);

        // Act
        var hasValue = binarySearchTree.Contains(value);

        hasValue.Should().BeTrue();
    }

    [TestCase(46)]
    [TestCase(16)]
    [TestCase(78)]
    [TestCase(91)]
    [TestCase(11)]
    [TestCase(56)]
    [TestCase(13)]
    [TestCase(21)]
    [TestCase(51)]
    public void ContainsValue_ShouldNotContainsValue(int value)
    {
        // Arrange
        var binarySearchTree = new BinarySearchTree();

        binarySearchTree.Insert(45);
        binarySearchTree.Insert(15);
        binarySearchTree.Insert(79);
        binarySearchTree.Insert(90);
        binarySearchTree.Insert(10);
        binarySearchTree.Insert(55);
        binarySearchTree.Insert(12);
        binarySearchTree.Insert(20);
        binarySearchTree.Insert(50);

        // Act
        var hasValue = binarySearchTree.Contains(value);

        hasValue.Should().BeFalse();
    }

    [Test]
    public void Delete_ShouldDeleteElementProperly()
    {
        // Arrange
        var binarySearchTree = new BinarySearchTree();
        binarySearchTree.Insert(45);
        binarySearchTree.Insert(15);
        binarySearchTree.Insert(79);
        binarySearchTree.Insert(90);
        binarySearchTree.Insert(10);
        binarySearchTree.Insert(55);
        binarySearchTree.Insert(12);
        binarySearchTree.Insert(20);
        binarySearchTree.Insert(50);

        // Act
        binarySearchTree.Delete(90);

        // Assert
        binarySearchTree.Root.Value.Should().Be(45);

        binarySearchTree.Root.Left.Value.Should().Be(15);
        binarySearchTree.Root.Right.Value.Should().Be(79);

        binarySearchTree.Root.Left.Left.Value.Should().Be(10);
        binarySearchTree.Root.Left.Right.Value.Should().Be(20);
        binarySearchTree.Root.Right.Left.Value.Should().Be(55);
        binarySearchTree.Root.Right.Right.Value.Should().Be(null);

        binarySearchTree.Root.Left.Left.Right.Value.Should().Be(12);
        binarySearchTree.Root.Right.Left.Left.Value.Should().Be(50);
    }
}