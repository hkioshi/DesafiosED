public class Node
{
    public int Key { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    // Construtor
    public Node(int key)
    {
        this.Key = key;
    }
}

// BST é Binary Search Tree
public class BST
{
    public Node Raiz;
    public BST(int key) => Raiz = new(key);

    public void Insert(int value)
    {
        Node NodeAtual = Raiz;
        while (NodeAtual != null)
        {
            if (value < NodeAtual.Key)
            {
                if (NodeAtual.Left == null)
                {
                    NodeAtual.Left = new Node(value);
                    return;
                }
                else
                {
                    NodeAtual = NodeAtual.Left;
                }
            }
            else
            {
                if (NodeAtual.Right == null)
                {
                    NodeAtual.Right = new Node(value);
                    return;
                }
                else
                {
                    NodeAtual = NodeAtual.Right;
                }
            }
        }
    }
    public void Search(int value)
    {
        Node NodeAtual = Raiz;
        while (NodeAtual != null)
        {
            if (value == NodeAtual.Key)
            {
                Console.WriteLine("Valor encontrado: " + value);
                return;
            }
            else if (value < NodeAtual.Key)
            {
                NodeAtual = NodeAtual.Left;
            }
            else
            {
                NodeAtual = NodeAtual.Right;
            }
        }
        Console.WriteLine("Valor não encontrado: " + value);
    }
}

