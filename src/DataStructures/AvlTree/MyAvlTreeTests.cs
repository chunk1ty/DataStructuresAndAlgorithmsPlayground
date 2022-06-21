using FluentAssertions;
using NUnit.Framework;

namespace AvlTree;

public class MyAvlTreeTests
{
    //    30 (this)
    //    /
    //   20
    //  /
    // 10
    //
    // becomes
    //       20
    //      /  \
    //     10  30
    [Test]
    public void Insert_ShouldAutoRebalance_ByRightRotation()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();

        // Act
        myAvlTree.Insert(30);
        myAvlTree.Insert(20);
        myAvlTree.Insert(10);

        // Assert
        myAvlTree.Root.Value.Should().Be(20);
        myAvlTree.Root.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Height.Should().Be(2);

        myAvlTree.Root.Left.Value.Should().Be(10);
        myAvlTree.Root.Left.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Left.Height.Should().Be(1);

        myAvlTree.Root.Right.Value.Should().Be(30);
        myAvlTree.Root.Right.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Right.Height.Should().Be(1);
    }

    //    30 (this)
    //    /
    //   10
    //    \
    //     20
    //
    // becomes
    //       20
    //      /  \
    //     10   30
    [Test]
    public void Insert_ShouldAutoRebalance_ByRightLeftRotation()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();

        // Act
        myAvlTree.Insert(30);
        myAvlTree.Insert(10);
        myAvlTree.Insert(20);

        // Assert
        myAvlTree.Root.Value.Should().Be(20);
        myAvlTree.Root.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Height.Should().Be(2);

        myAvlTree.Root.Left.Value.Should().Be(10);
        myAvlTree.Root.Left.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Left.Height.Should().Be(1);

        myAvlTree.Root.Right.Value.Should().Be(30);
        myAvlTree.Root.Right.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Right.Height.Should().Be(1);
    }

    //     10
    //      \
    //       20
    //        \
    //         30
    //
    // becomes
    //       20
    //      /  \
    //     10   30
    [Test]
    public void Insert_ShouldAutoRebalance_ByLeftRotation()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();

        // Act
        myAvlTree.Insert(10);
        myAvlTree.Insert(20);
        myAvlTree.Insert(30);

        // Assert
        myAvlTree.Root.Value.Should().Be(20);
        myAvlTree.Root.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Height.Should().Be(2);

        myAvlTree.Root.Left.Value.Should().Be(10);
        myAvlTree.Root.Left.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Left.Height.Should().Be(1);

        myAvlTree.Root.Right.Value.Should().Be(30);
        myAvlTree.Root.Right.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Right.Height.Should().Be(1);
    }

    //     10
    //      \
    //       30
    //      /  
    //     20   
    //
    // becomes
    //       20
    //      /  \
    //     10   30
    [Test]
    public void Insert_ShouldAutoRebalance_ByLeftRightRotation()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();

        // Act
        myAvlTree.Insert(30);
        myAvlTree.Insert(10);
        myAvlTree.Insert(20);

        // Assert
        myAvlTree.Root.Value.Should().Be(20);
        myAvlTree.Root.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Height.Should().Be(2);

        myAvlTree.Root.Left.Value.Should().Be(10);
        myAvlTree.Root.Left.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Left.Height.Should().Be(1);

        myAvlTree.Root.Right.Value.Should().Be(30);
        myAvlTree.Root.Right.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Right.Height.Should().Be(1);
    }

    [Test]
    public void Insert_ShouldAutoRebalance_ByRightLeftRotationX()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();

        // Act
        myAvlTree.Insert(42);
        myAvlTree.Insert(17);
        myAvlTree.Insert(29);
        myAvlTree.Insert(13);
        myAvlTree.Insert(20);
        myAvlTree.Insert(6);
        myAvlTree.Insert(100);
        myAvlTree.Insert(155);

        // Assert
       
    }

    [Test]
    public void Delete_WithSingleElement_ShouldDeleteRoot()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();
        myAvlTree.Insert(42);

        // Act
        myAvlTree.Delete(42);

        // Assert
        myAvlTree.Root.Should().BeNull();
    }

    [Test]
    public void Delete_WithTwoElements_ShouldDeleteLeaf()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();
        myAvlTree.Insert(42);
        myAvlTree.Insert(17);

        // Act
        myAvlTree.Delete(17);

        // Assert
        myAvlTree.Root.Value.Should().Be(42);
        myAvlTree.Root.Left.Should().BeNull();
        myAvlTree.Root.Right.Should().BeNull();
    }

    [Test]
    public void Delete_WithTwoElements_ShouldDeleteNodeWithSingleLeftChild()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();
        myAvlTree.Insert(42);
        myAvlTree.Insert(17);

        // Act
        myAvlTree.Delete(42);

        // Assert
        myAvlTree.Root.Value.Should().Be(17);
        myAvlTree.Root.Left.Should().BeNull();
        myAvlTree.Root.Right.Should().BeNull();
    }

    [Test]
    public void Delete_WithTwoElements_ShouldDeleteNodeWithSingleRightChild()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();
        myAvlTree.Insert(42);
        myAvlTree.Insert(52);

        // Act
        myAvlTree.Delete(42);

        // Assert
        myAvlTree.Root.Value.Should().Be(52);
        myAvlTree.Root.Left.Should().BeNull();
        myAvlTree.Root.Right.Should().BeNull();
    }

    [Test]
    public void Delete_WithTwoElements_ShouldDeleteNodeTwoChild()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();
        myAvlTree.Insert(42);
        myAvlTree.Insert(17);
        myAvlTree.Insert(52);

        // Act
        myAvlTree.Delete(42);

        // Assert
        myAvlTree.Root.Value.Should().Be(52);
        myAvlTree.Root.Left.Value.Should().Be(17);
        myAvlTree.Root.Right.Should().BeNull();
    }
}