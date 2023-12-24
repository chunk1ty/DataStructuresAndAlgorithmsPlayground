using FluentAssertions;
using NUnit.Framework;

namespace BinarySearchTree;

public class MyBinarySearchTreeTests
{
    [Test]
    public void Insert_ShouldAddElementToBSTProperly()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();

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
    public void InOrder_ShouldTraverseRecursiveBSTy()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();

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
        var items = binarySearchTree.DfsInOrderRecursive();

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
    
    [Test]
    public void InOrder_ShouldTraverseIterativeBSTProperly()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();

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
        var items = binarySearchTree.DfsInOrderIterative();

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
    
    [Test]
    public void PreOrder_ShouldTraverseRecursiveBST()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();

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
        var items = binarySearchTree.DfsPreOrderRecursive();

        items[0].Should().Be(45);
        items[1].Should().Be(15); 
        items[2].Should().Be(10); 
        items[3].Should().Be(12); 
        items[4].Should().Be(20); 
        items[5].Should().Be(79); 
        items[6].Should().Be(55); 
        items[7].Should().Be(50); 
        items[8].Should().Be(90); 
    }
    
    [Test]
    public void PreOrder_ShouldTraverseIterativeBST()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();

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
        var items = binarySearchTree.DfsPreOrderIterative();

        items[0].Should().Be(45);
        items[1].Should().Be(15); 
        items[2].Should().Be(10); 
        items[3].Should().Be(12); 
        items[4].Should().Be(20); 
        items[5].Should().Be(79); 
        items[6].Should().Be(55); 
        items[7].Should().Be(50); 
        items[8].Should().Be(90); 
    }
    
    [Test]
    public void PostOrder_ShouldTraverseRecursiveBST()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();

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
        var items = binarySearchTree.DfsPostOrderRecursive();

        items[0].Should().Be(12);
        items[1].Should().Be(10); 
        items[2].Should().Be(20); 
        items[3].Should().Be(15); 
        items[4].Should().Be(50); 
        items[5].Should().Be(55); 
        items[6].Should().Be(90); 
        items[7].Should().Be(79); 
        items[8].Should().Be(45); 
    }
    
    [Test]
    public void PostOrder_ShouldTraverseIterativeBST()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();

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
        var items = binarySearchTree.DfsPostOrderIterative();

        items[0].Should().Be(12);
        items[1].Should().Be(10); 
        items[2].Should().Be(20); 
        items[3].Should().Be(15); 
        items[4].Should().Be(50); 
        items[5].Should().Be(55); 
        items[6].Should().Be(90); 
        items[7].Should().Be(79); 
        items[8].Should().Be(45); 
    }
    
    [Test]
    public void Bfs_ShouldTraverseBST()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();

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
        var items = binarySearchTree.Bfs();

        items.Count.Should().Be(4);
        items[0][0].Should().Be(45);
        items[1][0].Should().Be(15);
        items[1][1].Should().Be(79);
        items[2][0].Should().Be(10);
        items[2][1].Should().Be(20);
        items[2][2].Should().Be(55);
        items[2][3].Should().Be(90);
        items[3][0].Should().Be(12);
        items[3][1].Should().Be(50);
    }

    [Test]
    public void Enumerable_ShouldEnumerateTree()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();

        binarySearchTree.Insert(45);
        binarySearchTree.Insert(15);
        binarySearchTree.Insert(79);
        binarySearchTree.Insert(90);
        binarySearchTree.Insert(10);
        binarySearchTree.Insert(55);
        binarySearchTree.Insert(12);
        binarySearchTree.Insert(20);
        binarySearchTree.Insert(50);

        // Act & Assert
        var expected = new[] { 10, 12, 15, 20, 45, 50, 55, 79, 90 };
        int index = 0;
        foreach (var nodeValue in binarySearchTree)
        {
            nodeValue.Should().Be(expected[index]);
            index++;
        }
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
        var binarySearchTree = new MyBinarySearchTree();

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
        var binarySearchTree = new MyBinarySearchTree();

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
    public void Delete_ShouldNotDeleteElement()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();
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
        binarySearchTree.Delete(17);

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
    public void Delete_ShouldDeleteLeafNode()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();
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
        binarySearchTree.Root.Right.Right.Should().BeNull();

        binarySearchTree.Root.Left.Left.Right.Value.Should().Be(12);
        binarySearchTree.Root.Right.Left.Left.Value.Should().Be(50);
    }

    [Test]
    public void Delete_ShouldDeleteRootNode()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();
        binarySearchTree.Insert(45);        

        // Act
        binarySearchTree.Delete(45);

        // Assert
        binarySearchTree.Root.Should().BeNull();
    }

    [Test]
    public void Delete_ShouldDeleteRootNodeWithSingleChild()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();
        binarySearchTree.Insert(45);
        binarySearchTree.Insert(15);      
        binarySearchTree.Insert(10);

        // Act
        binarySearchTree.Delete(45);

        // Assert
        binarySearchTree.Root.Value.Should().Be(15);

        binarySearchTree.Root.Left.Value.Should().Be(10);
        binarySearchTree.Root.Right.Should().BeNull();

        binarySearchTree.Root.Left.Left.Should().BeNull();
        binarySearchTree.Root.Left.Right.Should().BeNull();
    }

    [Test]
    public void Delete_ShouldDeleteNodeWithOneChild()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();
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
        binarySearchTree.Delete(10);

        // Assert
        binarySearchTree.Root.Value.Should().Be(45);

        binarySearchTree.Root.Left.Value.Should().Be(15);
        binarySearchTree.Root.Right.Value.Should().Be(79);

        binarySearchTree.Root.Left.Left.Value.Should().Be(12);
        binarySearchTree.Root.Left.Right.Value.Should().Be(20);
        binarySearchTree.Root.Right.Left.Value.Should().Be(55); 
        binarySearchTree.Root.Right.Right.Value.Should().Be(90);

        binarySearchTree.Root.Right.Left.Left.Value.Should().Be(50);
    }

    [Test]
    public void Delete_ShouldDeleteRootNodeWithTwoChildren()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();
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
        binarySearchTree.Delete(45);

        // Assert
        binarySearchTree.Root.Value.Should().Be(50);

        binarySearchTree.Root.Left.Value.Should().Be(15);
        binarySearchTree.Root.Right.Value.Should().Be(79);

        binarySearchTree.Root.Left.Left.Value.Should().Be(10);
        binarySearchTree.Root.Left.Right.Value.Should().Be(20);
        binarySearchTree.Root.Right.Left.Value.Should().Be(55);
        binarySearchTree.Root.Right.Right.Value.Should().Be(90);

        binarySearchTree.Root.Left.Left.Right.Value.Should().Be(12);
    }
    
    [Test]
    public void IsValid_ShouldValidateBST()
    {
        // Arrange
        var binarySearchTree = new MyBinarySearchTree();
        
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
        var isValid = binarySearchTree.IsValid();
       
        // Assert
        isValid.Should().BeTrue();
    }
}