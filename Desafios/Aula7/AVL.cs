using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula7
{
    public class AVL
    {
        NodeAVL Raiz;

        public void Insert(int valor) =>
            Raiz = InsertRecursivo(Raiz, valor);

        public NodeAVL InsertRecursivo(NodeAVL nodeAtual,int valor)
        {
            if(nodeAtual is null) return new NodeAVL(valor);

            if(nodeAtual.Key >  valor)
                nodeAtual.Right = InsertRecursivo(nodeAtual.Right, valor);
            else
                nodeAtual.Left = InsertRecursivo(nodeAtual.Left, valor);


            nodeAtual.RedefinirAltura();
            

            if(nodeAtual.Balanceamento == 2)
            {
                if(nodeAtual.Left?.Balanceamento < 0)
                    nodeAtual.Left = RotacaoEsquerda(nodeAtual.Left);
                nodeAtual = RotacaoDireita(nodeAtual);
            }
            if (nodeAtual.Balanceamento == -2)
            {
                if (nodeAtual.Right.Balanceamento > 0)
                    nodeAtual.Right = RotacaoDireita(nodeAtual.Right);
                nodeAtual = RotacaoEsquerda(nodeAtual);
            }

            return nodeAtual;


        }

        public NodeAVL RotacaoDireita(NodeAVL node)
        {
            if (node is null) return node;

            NodeAVL NovoNode = node.Left;
            node.Left = NovoNode.Right;
            NovoNode.Right = node;
            NovoNode.RedefinirAltura();
            node.RedefinirAltura();
            return NovoNode;
        }

        public int Altura() => Raiz.Altura;

        public NodeAVL RotacaoEsquerda(NodeAVL node)
        {
            if (node is null) return node;

            NodeAVL NovoNode = node.Right;
            node.Right = NovoNode.Left;
            NovoNode.Left = node;
            NovoNode.RedefinirAltura();
            node.RedefinirAltura();
            return NovoNode;
        }

        public void ArvoreAleatoria(int n)
        {
            if(n <= 0) return;
            Insert(new Random().Next(1, 100));
            ArvoreAleatoria(n - 1);
        }
        public void CoolPrint()
        {
            CoolPrint(Raiz, 0);
        }
        private void CoolPrint(NodeAVL node, int level)
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
        private NodeAVL MaximoRecursivo(NodeAVL node)
        {
            if (node is null || node.Right is null)
                return node;
            return MaximoRecursivo(node.Right);
        }

        public void Minimo() =>
            Console.WriteLine(MinimoRecursivo(Raiz).Key);
        private NodeAVL MinimoRecursivo(NodeAVL node)
        {
            if (node is null || node.Left is null)
                return node;
            return MinimoRecursivo(node.Left);
        }

        public void PrintInOrder() => PrintInOrderR(Raiz);
        private void PrintInOrderR(NodeAVL nodeAtual)
        {
            if (nodeAtual != null)
            {
                PrintInOrderR(nodeAtual.Left);
                Console.WriteLine(nodeAtual.Key);
                PrintInOrderR(nodeAtual.Right);
            }
        }

        public void Search(int value)
        {
            NodeAVL? resulado = SearchRecursivo(Raiz, value);
            Console.WriteLine(resulado is null ? "Não encontrado" : resulado.Key.ToString());
        }
        private NodeAVL? SearchRecursivo(NodeAVL node, int value)
        {
            return node is null || node.Key == value ?
                 node :
                 value < node.Key ?
                    SearchRecursivo(node.Left, value) :
                    SearchRecursivo(node.Right, value);

        }


    }
}
