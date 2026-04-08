// See https://aka.ms/new-console-template for more information
BST bst = new(2);

bst.Insert(15);
bst.Insert(10);
bst.Insert(8);
bst.Insert(12);
bst.Insert(20);
bst.Insert(21);

Console.WriteLine("In-order traversal (Sorted keys):");
bst.PrintInOrder();
Console.WriteLine("Visualização mais legal:");
bst.CoolPrint(); 
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

    public Node Maximo()
    {
        Node nodeAtual = Raiz;
        while (nodeAtual.Right != null)
            nodeAtual = nodeAtual.Right;
        return nodeAtual;

    }
    public Node Minimo()
    {
        Node nodeAtual = Raiz;
        while (nodeAtual.Left != null)
            nodeAtual = nodeAtual.Left;
        return nodeAtual;
    }

    public void PrintInOrder()
    {
        if (Raiz == null) return;

        Stack<Node> pilha = new Stack<Node>();
        Node atual = Raiz;

        while (pilha.Count > 0 || atual != null)
        {
            while (atual != null)
            {
                pilha.Push(atual);
                atual = atual.Left;
            }

            atual = pilha.Pop();
            Console.Write(atual.Key + " ");

            atual = atual.Right;
        }
    }

    public void PrintInOrderRecursivo() =>
        PrintInOrderR(Raiz);
    
    private void PrintInOrderR(Node nodeAtual)
    {
        if (nodeAtual != null)
        {
            PrintInOrderR(nodeAtual.Left);
            Console.WriteLine(nodeAtual.Key);
            PrintInOrderR(nodeAtual.Right);
        }
    }

    public Node MaximoR() =>
        MaxR(Raiz);

    private Node MaxR(Node nodeAtual)
    {
        if (nodeAtual.Right == null)
            return nodeAtual;
        return MaxR(nodeAtual.Right);
    }

    public Node MinimoR() =>
       MinR(Raiz);

    private Node MinR(Node nodeAtual)
    {
        if (nodeAtual.Left == null)
            return nodeAtual;
        return MinR(nodeAtual.Left);
    }
    public void CoolPrint() =>
        CoolPrintR(Raiz, 0);

    private void CoolPrintR(Node nodeAtual, int level)
    {
        if (nodeAtual != null)
        {
            CoolPrintR(nodeAtual.Right, level + 1);
            Console.WriteLine(new string(' ', level * 4) + nodeAtual.Key);
            CoolPrintR(nodeAtual.Left, level + 1);
        }
    }


}

