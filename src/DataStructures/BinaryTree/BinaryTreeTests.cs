using FluentAssertions;
using NUnit.Framework;

namespace BinaryTree;

[TestFixture]
public class BinaryTreeTests
{
    private MyBinaryTree _myBinaryTree;

    [SetUp]
    public void SetUp()
    {
        //     12
        //    /  \
        //   7    14
        //  / \    \
        // 3   7    18
        _myBinaryTree = new MyBinaryTree(12);

        _myBinaryTree.Root.Left = new MyBinaryTreeNode(7);
        _myBinaryTree.Root.Right = new MyBinaryTreeNode(14);
        _myBinaryTree.Root.Left.Left = new MyBinaryTreeNode(3);
        _myBinaryTree.Root.Left.Right = new MyBinaryTreeNode(7);
        _myBinaryTree.Root.Right.Right = new MyBinaryTreeNode(18);
    }

    [Test]
    public void TraverseInOrder_ShouldTraverseBinaryTree()
    {
        // Arrange & Act
        var elements = _myBinaryTree.TraverseInOrder();

        // Assert
        elements[0].Should().Be(3);
        elements[1].Should().Be(7);
        elements[2].Should().Be(7);
        elements[3].Should().Be(12);
        elements[4].Should().Be(14);
        elements[5].Should().Be(18);
    }

    [Test]
    public void TraversePostOrder_ShouldTraverseBinaryTree()
    {
        // Arrange & Act
        var elements = _myBinaryTree.TraversePostOrder();

        // Assert
        elements[0].Should().Be(3);
        elements[1].Should().Be(7);
        elements[2].Should().Be(7);
        elements[3].Should().Be(18);
        elements[4].Should().Be(14);
        elements[5].Should().Be(12);
    }

    [Test]
    public void TraversePreOrder_ShouldTraverseBinaryTree()
    {
        // Arrange & Act
        var elements = _myBinaryTree.TraversePreOrder();

        // Assert
        elements[0].Should().Be(12);
        elements[1].Should().Be(7);
        elements[2].Should().Be(3);
        elements[3].Should().Be(7);
        elements[4].Should().Be(14);
        elements[5].Should().Be(18);
    }
}