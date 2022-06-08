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
internal class MyBinaryTree
{
    private readonly MyBinaryTreeNode _root;

    public MyBinaryTree(int value)
    {
        _root = new MyBinaryTreeNode(value);
    }

    public MyBinaryTreeNode Root => _root;
    
    public List<int> TraversePreOrder()
    {
        var elements = new List<int>();
        PreOrder(Root, elements);

        return elements;
    }

    // root > left > right
    private void PreOrder(MyBinaryTreeNode node, List<int> elements)
    {
        if (node is not null)
        {
            elements.Add(node.Value);
            PreOrder(node.Left, elements);
            PreOrder(node.Right, elements);
        }
    }
    
    public List<int> TraverseInOrder()
    {
        var elements = new List<int>();
        InOrder(Root, elements);

        return elements;
    }

    // left > root > right
    private void InOrder(MyBinaryTreeNode node, List<int> elements)
    {
        if (node is not null)
        {
            InOrder(node.Left, elements);
            elements.Add(node.Value);
            InOrder(node.Right, elements);
        }
    }
   
    public List<int> TraversePostOrder()
    {
        var elements = new List<int>();
        PostOrder(Root, elements);

        return elements;
    }

    // left > right > root
    private void PostOrder(MyBinaryTreeNode node, List<int> elements)
    {
        if (node is not null)
        {
            PostOrder(node.Left, elements);
            PostOrder(node.Right, elements);
            elements.Add(node.Value);
        }
    }
}
