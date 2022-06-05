using System;
using System.Collections.Generic;

namespace BinarySearchTree;

internal class BinarySearchTree
{
    private Node _root;

    public BinarySearchTree()
    {
        _root = null;
    }

    public Node Root => _root;

    public void Insert(int value)
    {
        _root = InsertNode(_root, value);
    }

    private Node InsertNode(Node root, int value)
    {
        // bottom of recursion (when right place for insertion is found)
        if (root is null)
        {
            root = new Node(value);
            return root;
        }

        // go to the left
        if (value < root.Value)
        {
            root.Left = InsertNode(root.Left, value);
        }
        // go to the right
        else if (value > root.Value)
        {
            root.Right = InsertNode(root.Right, value);
        }
        else
        {
            // TODO: handle duplicate values
            throw new NotSupportedException("Duplicate values are not supported");
        }

        // return unchanged node pointer
        return root;
    }

    public List<int> TraverseInOrder()
    {
        List<int> items = new List<int>();
        InOrder(_root, items);
        return items;
    }

    private void InOrder(Node currentNode, List<int> items)
    {
        if (currentNode is not null)
        {
            InOrder(currentNode.Left, items);
            items.Add(currentNode.Value);
            InOrder(currentNode.Right, items);
        }
    }

    public bool ContainsValue(int value)
    {
        var node = HasValue(_root, value);

        return node is null ? false : true;
    }

    private Node HasValue(Node currentNode, int value)
    {
        if (currentNode is null)
        {
            return null;
        }

        if (currentNode.Value == value)
        {
            return currentNode;
        }

        if (value < currentNode.Value)
        {
            return HasValue(currentNode.Left, value);
        }

        return HasValue(currentNode.Right, value);
    }
}
