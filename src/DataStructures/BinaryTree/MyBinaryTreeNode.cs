namespace BinaryTree;

internal class MyBinaryTreeNode
{
    public MyBinaryTreeNode(int value)
    {
        Left = null;
        Right = null;
        Value = value;
    }

    public MyBinaryTreeNode Left { get; set; }

    public MyBinaryTreeNode Right { get; set; }

    public int Value { get; }
}
