using Stack;
using System.Collections;

namespace BinarySearchTree;

internal partial class MyBinarySearchTree : IEnumerable
{
    private TreeNode _root;

    public MyBinarySearchTree()
    {
        _root = null;
    }

    public TreeNode Root => _root;

    public void Insert(int value)
    {
        if (_root == null)
        {
            _root = new TreeNode(value);
            return;
        }

        _Insert(_root, value);

        TreeNode _Insert(TreeNode root, int value)
        {
            if (root is null)
            {
                return new TreeNode(value);
            }

            if (root.Value < value)
            {
                root.Right = _Insert(root.Right, value);
            }
            else
            {
                root.Left = _Insert(root.Left, value);
            }

            return root;
        }
    }

    public bool Contains(int value)
    {
        return Find(value).Node is not null;
    }

    private (TreeNode Node, TreeNode Parent) Find(int value)
    {
        TreeNode current = _root;
        TreeNode parent = null;

        while (current is not null)
        {
            if (value == current.Value)
            {
                break;
            }

            if (value < current.Value)
            {
                parent = current;
                current = current.Left;
            }
            // if value is greater or equal to current node value - go to the right
            else
            {
                parent = current;
                current = current.Right;
            }
        }

        return (current, parent);
    }

    public void Delete(int value)
    {
        _root = DeleteNode(_root, value);

        TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root is null)
            {
                return null;
            }

            if (root.Value < key)
            {
                root.Right = DeleteNode(root.Right, key);
            }
            else if (root.Value > key)
            {
                root.Left = DeleteNode(root.Left, key);
            }
            else
            {
                if (root.Left is null)
                {
                    return root.Right;
                }

                if (root.Right is null)
                {
                    return root.Left;
                }

                TreeNode minTreeNode = FindMinValue(root.Right);

                root.Value = minTreeNode.Value;
                root.Right = DeleteNode(root.Right, minTreeNode.Value);
            }

            return root;
        }
        
        TreeNode FindMinValue(TreeNode treeNode)
        {
            while (treeNode.Left is not null)
            {
                treeNode = treeNode.Left;
            }

            return treeNode;
        }
    }

    public bool IsValid()
    {
        return IsValid(_root, long.MinValue, long.MaxValue);
        
        bool IsValid(TreeNode treeNode, long lowerBound, long upperBound)
        {
            if (treeNode is null)
            {
                return true;
            }

            if (treeNode.Value <= lowerBound || treeNode.Value >= upperBound)
            {
                return false;
            }

            var isLeftSubTreeValid = IsValid(treeNode.Left, lowerBound, treeNode.Value);
            var isRightSubTreeValid = IsValid(treeNode.Right, treeNode.Value, upperBound);

            return isLeftSubTreeValid && isRightSubTreeValid;
        }
    }

    public IEnumerator GetEnumerator()
    {
        MyStack<TreeNode> elements = new MyStack<TreeNode>();

        TreeNode current = _root;
        elements.Push(current);

        bool goToTheLeft = true;
        while (elements.Count > 0)
        {
            if (goToTheLeft)
            {
                while (current.Left is not null)
                {
                    elements.Push(current);
                    current = current.Left;
                }
            }

            yield return current.Value;

            if (current.Right is not null)
            {
                current = current.Right;
                goToTheLeft = true;
            }
            else
            {
                current = elements.Pop();
                goToTheLeft = false;
            }
        }
    }
}