using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula7
{
    

    // BST é Binary Search Tree
    public  class BST 
    {
        private Node Raiz { get; set; }

        public void Insert(int value) => 
            Raiz = InsertRecursivo(Raiz, value);
        public void Insert(params int[] values)
        {
            foreach (var value in values)
            {
                Raiz = InsertRecursivo(Raiz, value);
            }
        }
        private Node InsertRecursivo(Node node, int value) 
        {
            if (node is null)
            {
                node = new Node(value);
                return node;
            }
            if (value <= node.Key)
                node.Left = InsertRecursivo(node.Left, value);
            else
                node.Right = InsertRecursivo(node.Right, value);
            return node;
        }



        public void CoolPrint()
        {
            CoolPrint(Raiz, 0);
        }
        private void CoolPrint(Node node, int level)
        {
            if (node != null)
            {
                CoolPrint(node.Right, level + 1);
                Console.WriteLine(new string(' ', level * 4) + node.Key);
                CoolPrint(node.Left, level + 1);
            }
        }

        public void Maximo() =>
            Console.WriteLine(MaximoRecursivo(Raiz).Key);
        private Node MaximoRecursivo(Node node)
        {
            if (node is null || node.Right is null)
                return node;
            return MaximoRecursivo(node.Right);
        }

        public void Minimo() =>
            Console.WriteLine(MinimoRecursivo(Raiz).Key);
        private Node MinimoRecursivo(Node node)
        {
            if (node is null || node.Left is null)
                return node;
            return MinimoRecursivo(node.Left);
        }

        public void PrintInOrder() => PrintInOrderR(Raiz);
        private void PrintInOrderR(Node nodeAtual)
        {
            if (nodeAtual != null)
            {
                PrintInOrderR(nodeAtual.Left);
                Console.WriteLine(nodeAtual.Key);
                PrintInOrderR(nodeAtual.Right);
            }
        }

        public int Altura() => AlturaRecursiva(Raiz);
        public int AlturaRecursiva(Node nodeAtual)
        {
            if(nodeAtual is null)
                return 0;

            return Math.Max(AlturaRecursiva(nodeAtual.Left), AlturaRecursiva(nodeAtual.Right)) + 1; 

        }

        public void Search(int value)
        {
            Node? resulado = SearchRecursivo(Raiz, value);
            Console.WriteLine(resulado is null ? "Não encontrado" : resulado.Key.ToString());
        }
        private Node? SearchRecursivo(Node node, int value)
        {
            return node is null || node.Key == value ?
                 node :
                 value < node.Key ?
                    SearchRecursivo(node.Left, value) :
                    SearchRecursivo(node.Right, value);

        }

    }

   

}
