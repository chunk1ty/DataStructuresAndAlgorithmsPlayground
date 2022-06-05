using System.Collections.Generic;

namespace BinaryTree;

// A binary tree is a tree data structure in which each parent node
// can have at most two children.Each node of a binary tree consists of three items:
// + data item
// + address of left child
// + address of right child

//   1
//  / \
// 2   3
internal class BinaryTree
{
    private readonly BinaryTreeNode _root;

    public BinaryTree(int value)
    {
        _root = new BinaryTreeNode(value);
    }

    public BinaryTreeNode Root => _root;

    // root > left > right
    public List<int> TraversePreOrder()
    {
        var elements = new List<int>();
        PreOrder(Root, elements);

        return elements;
    }

    private void PreOrder(BinaryTreeNode node, List<int> elements)
    {
        if (node is not null)
        {
            elements.Add(node.Value);
            PreOrder(node.Left, elements);
            PreOrder(node.Right, elements);
        }
    }

    // left > root > right
    public List<int> TraverseInOrder()
    {
        var elements = new List<int>();
        InOrder(Root, elements);

        return elements;
    }

    private void InOrder(BinaryTreeNode node, List<int> elements)
    {
        if (node is not null)
        {
            InOrder(node.Left, elements);
            elements.Add(node.Value);
            InOrder(node.Right, elements);
        }
    }

    // left > right > root
    public List<int> TraversePostOrder()
    {
        var elements = new List<int>();
        PostOrder(Root, elements);

        return elements;
    }

    private void PostOrder(BinaryTreeNode node, List<int> elements)
    {
        if (node is not null)
        {
            PostOrder(node.Left, elements);
            PostOrder(node.Right, elements);
            elements.Add(node.Value);
        }
    }
}
