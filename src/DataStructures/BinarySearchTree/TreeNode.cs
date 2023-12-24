namespace BinarySearchTree;

internal class TreeNode
{
    public TreeNode(int value)
    {
        Left = null;
        Right = null;
        Value = value;
    }

    public TreeNode Left { get; set; }

    public TreeNode Right { get; set; }

    public int Value { get; set; }

    public override string ToString()
    {
        return $"{Value}";
    }
}