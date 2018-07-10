namespace Tree2List.Models
{
    public class Node
    {
        public Node(Node left, Node right)
        {
            Left = left;
            Right = right;
        }

        public Node Left { get; private set; }
        public Node Right { get; private set; }
    }
}
