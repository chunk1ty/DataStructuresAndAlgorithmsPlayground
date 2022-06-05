using FluentAssertions;
using NUnit.Framework;

namespace BinaryTree;

[TestFixture]
public class BinaryTreeTests
{

    private BinaryTree _binaryTree;

    [SetUp]
    public void SetUp()
    {
        //     12
        //    /  \
        //   7    14
        //  / \    \
        // 3   7    18
        _binaryTree = new BinaryTree(12);

        _binaryTree.Root.Left = new BinaryTreeNode(7);
        _binaryTree.Root.Right = new BinaryTreeNode(14);
        _binaryTree.Root.Left.Left = new BinaryTreeNode(3);
        _binaryTree.Root.Left.Right = new BinaryTreeNode(7);
        _binaryTree.Root.Right.Right = new BinaryTreeNode(18);
    }

    [Test]
    public void TraverseInOrder_ShouldTraverseBinaryTree()
    {
        var elements = _binaryTree.TraverseInOrder();

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
        var elements = _binaryTree.TraversePostOrder();

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
        var elements = _binaryTree.TraversePreOrder();

        elements[0].Should().Be(12);
        elements[1].Should().Be(7);
        elements[2].Should().Be(3);
        elements[3].Should().Be(7);
        elements[4].Should().Be(14);
        elements[5].Should().Be(18);
    }
}