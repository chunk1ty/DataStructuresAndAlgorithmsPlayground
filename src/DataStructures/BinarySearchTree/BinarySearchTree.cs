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

    /// <summary>
    /// Adds integer value to binary search tree
    /// </summary>
    /// <param name="value"></param>
    public void Insert(int value)
    {
        if (_root == null)
        {
            _root = new Node(value);
        }
        else
        {
            InsertNode(_root, value);
        }
    }

    // Recursive add algorithm
    private void InsertNode(Node node, int value)
    {
        // Case 1: Go to the left (value is less than the current node value)
        if (value < node.Value)
        {
            // if there is no left child make this the new leaf
            if (node.Left is null)
            {
                node.Left = new Node(value);
                return;
            }

            InsertNode(node.Left, value);
        }
        // Case 2: Go to the right (value is equal to or greater than the current value)
        else
        {
            // if there is no right child make this the new leaf
            if (node.Right is null)
            {
                node.Right = new Node(value);
                return;
            }

            InsertNode(node.Right, value);
        }
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

    /// <summary>
    /// Determines if the specified value exists in the binary tree.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Contains(int value)
    {
        var result = Find(value);

        return result.Node is null ? false : true;
    }

    private (Node Node, Node Parent) Find(int value)
    {
        Node current = _root;
        Node parent = null;

        while (current is not null)
        {
            // we have a match! (bottom of recursion)
            if (value == current.Value)
            {
                break;
            }
            // if value is less than current node value go to the left
            else if (value < current.Value)
            {
                parent = current;
                current = current.Left;
            }
            // if value is greater or equal to current node value go to the right
            else
            {
                parent = current;
                current = current.Right;
            }
        }

        return (current, parent);
    }

    /// <summary>
    /// Deletes the first occurance of the specified value from the tree.
    /// </summary>
    /// <param name="value"></param>
    public void Delete(int value)
    {
        var result = Find(value);
        var nodeToBeDeleted = result.Node;
        var nodeToBeDeletedParent = result.Parent;

        // nothing to be deleted
        if (nodeToBeDeleted is null)
        {
            return;
        }

        // Case 1: node to be deleted is the leaf node.
        if (nodeToBeDeleted.Left is null && nodeToBeDeleted.Right is null)
        {
            // edge case: we have a tree with single row
            if (nodeToBeDeleted == _root)
            {
                _root = null;
                return;
            }

            // nodeToBeDeleted is on the left from his parent
            if (nodeToBeDeleted == nodeToBeDeletedParent.Left)
            {
                nodeToBeDeletedParent.Left = null;
                return;
            }

            // nodeToBeDeleted is on the right from his parent
            if (nodeToBeDeleted == nodeToBeDeletedParent.Right)
            {
                nodeToBeDeletedParent.Right = null;
                return;
            }
        }

        // Case 2: node to be deleted has a single child node
        if (nodeToBeDeleted.Left is not null || nodeToBeDeleted.Right is not null)
        {
            Node nodeToBeDeletedChild = nodeToBeDeleted.Left is null ? nodeToBeDeleted.Right : nodeToBeDeleted.Left;

            // edge case: we have a tree with only 1 root child
            if (nodeToBeDeleted == _root)
            {
                _root = nodeToBeDeletedChild;
                return;
            }

            // nodeToBeDeleted is on the left from his parent
            if (nodeToBeDeleted == nodeToBeDeletedParent.Left)
            {
                nodeToBeDeletedParent.Left = nodeToBeDeletedChild;
                return;
            }

            // nodeToBeDeleted is on the right from his parent
            if (nodeToBeDeleted == nodeToBeDeletedParent.Right)
            {
                nodeToBeDeletedParent.Right = nodeToBeDeletedChild;
                return;
            }
        }

        // Case 3: node to be deleted has two children nodes
    }
}
