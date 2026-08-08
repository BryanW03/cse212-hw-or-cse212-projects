public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1: Insert Unique Values Only
        if (value == Data)
        {
            return; // Ignore duplicate values to maintain a unique set
        }
        else if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Problem 2: Contains
        if (value == Data)
            return true;
        else if (value < Data)
            return Left?.Contains(value) ?? false;
        else
            return Right?.Contains(value) ?? false;
    }

    public int GetHeight()
    {
        // Problem 4: Tree Height
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        
        return 1 + System.Math.Max(leftHeight, rightHeight);
    }
}