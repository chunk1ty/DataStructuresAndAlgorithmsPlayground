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
        myAvlTree.Root.Value.Should().Be(17);

        myAvlTree.Root.Left.Value.Should().Be(13);
        myAvlTree.Root.Left.Left.Value.Should().Be(6);

        myAvlTree.Root.Right.Value.Should().Be(29);
        myAvlTree.Root.Right.Left.Value.Should().Be(20);
        myAvlTree.Root.Right.Right.Value.Should().Be(100);
        myAvlTree.Root.Right.Right.Left.Value.Should().Be(42);
        myAvlTree.Root.Right.Right.Right.Value.Should().Be(155);
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

    // https://www.guru99.com/avl-tree.html
    // case 1a
    [Test]
    public void Delete_WithFourElements_ShouldDeleteLeafNodeAndRebalaneTreeByRightRotation()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();
        myAvlTree.Insert(30);
        myAvlTree.Insert(20);
        myAvlTree.Insert(40);
        myAvlTree.Insert(10);

        // Act
        myAvlTree.Delete(40);

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

    // case 1b
    [Test]
    public void Delete_WithFourElements_ShouldDeleteLeafNodeAndRebalaneTreeByRightLeftRotation()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();
        myAvlTree.Insert(30);
        myAvlTree.Insert(10);
        myAvlTree.Insert(40);
        myAvlTree.Insert(20);

        // Act
        myAvlTree.Delete(40);

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

    // case 1c
    [Test]
    public void Delete_WithFiveElements_ShouldDeleteLeafNodeAndRebalaneTreeByRightRotation()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();
        myAvlTree.Insert(30);
        myAvlTree.Insert(10);
        myAvlTree.Insert(40);
        myAvlTree.Insert(20);
        myAvlTree.Insert(5);

        // Act
        myAvlTree.Delete(40);

        // Assert
        myAvlTree.Root.Value.Should().Be(10);
        myAvlTree.Root.BalanceFactor.Should().Be(-1);
        myAvlTree.Root.Height.Should().Be(3);

        myAvlTree.Root.Left.Value.Should().Be(5);
        myAvlTree.Root.Left.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Left.Height.Should().Be(1);

        myAvlTree.Root.Right.Value.Should().Be(30);
        myAvlTree.Root.Right.BalanceFactor.Should().Be(1);
        myAvlTree.Root.Right.Height.Should().Be(2);

        myAvlTree.Root.Right.Left.Value.Should().Be(20);
        myAvlTree.Root.Right.Left.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Right.Left.Height.Should().Be(1);
    }    

    // case 2a
    [Test]
    public void Delete_WithFourElements_ShouldDeleteLeafNodeAndRebalaneTreeByLeftRotation()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();
        myAvlTree.Insert(20);
        myAvlTree.Insert(10);
        myAvlTree.Insert(30);
        myAvlTree.Insert(40);

        // Act
        myAvlTree.Delete(10);

        // Assert
        myAvlTree.Root.Value.Should().Be(30);
        myAvlTree.Root.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Height.Should().Be(2);

        myAvlTree.Root.Left.Value.Should().Be(20);
        myAvlTree.Root.Left.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Left.Height.Should().Be(1);

        myAvlTree.Root.Right.Value.Should().Be(40);
        myAvlTree.Root.Right.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Right.Height.Should().Be(1);
    }

    // case 2b
    [Test]
    public void Delete_WithFourElements_ShouldDeleteLeafNodeAndRebalaneTreeByLeftRightRotation()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();
        myAvlTree.Insert(20);
        myAvlTree.Insert(10);
        myAvlTree.Insert(40);
        myAvlTree.Insert(30);

        // Act
        myAvlTree.Delete(10);

        // Assert
        myAvlTree.Root.Value.Should().Be(30);
        myAvlTree.Root.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Height.Should().Be(2);

        myAvlTree.Root.Left.Value.Should().Be(20);
        myAvlTree.Root.Left.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Left.Height.Should().Be(1);

        myAvlTree.Root.Right.Value.Should().Be(40);
        myAvlTree.Root.Right.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Right.Height.Should().Be(1);
    }

    // case 2c
    [Test]
    public void Delete_WithFiveElements_ShouldDeleteLeafNodeAndRebalaneTreeByLeftRotation()
    {
        // Arrange
        var myAvlTree = new MyAvlTree();
        myAvlTree.Insert(20);
        myAvlTree.Insert(10);
        myAvlTree.Insert(30);
        myAvlTree.Insert(40);
        myAvlTree.Insert(25);

        // Act
        myAvlTree.Delete(10);

        // Assert
        myAvlTree.Root.Value.Should().Be(30);
        myAvlTree.Root.BalanceFactor.Should().Be(1);
        myAvlTree.Root.Height.Should().Be(3);

        myAvlTree.Root.Left.Value.Should().Be(20);
        myAvlTree.Root.Left.BalanceFactor.Should().Be(-1);
        myAvlTree.Root.Left.Height.Should().Be(2);

        myAvlTree.Root.Left.Right.Value.Should().Be(25);
        myAvlTree.Root.Left.Right.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Left.Right.Height.Should().Be(1);

        myAvlTree.Root.Right.Value.Should().Be(40);
        myAvlTree.Root.Right.BalanceFactor.Should().Be(0);
        myAvlTree.Root.Right.Height.Should().Be(1);
    }
}