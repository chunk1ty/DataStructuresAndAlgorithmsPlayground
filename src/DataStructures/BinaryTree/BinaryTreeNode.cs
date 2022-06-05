namespace BinaryTree;

internal class BinaryTreeNode
{
    public BinaryTreeNode(int value)
    {
        Left = null;
        Right = null;
        Value = value;
    }

    public BinaryTreeNode Left { get; set; }

    public BinaryTreeNode Right { get; set; }

    public int Value { get; }
}
