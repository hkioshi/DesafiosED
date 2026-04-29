using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Aula7
{
    public class Menu
    {
        AVL avl = new AVL();
        BST bst = new BST();
        public Menu() { }

        public void ImprimirMenu()
        {
            bool flag = false;
            string? escolha = null; 
            do
            {
                Console.Clear();
                Console.WriteLine("EP2 - Exemplo de interação");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Menu: \n1) nova simulação \n2) sair\r\n");
                Console.WriteLine("Escolha: ");
                try
                {
                    escolha = Console.ReadLine();
                    switch (escolha)
                    {
                        case "1":
                            Tarefa1();
                            break;
                        case "2":
                            Console.WriteLine("Saindo");
                            flag = true;
                            break;
                        default:
                            break;

                    }
                }
                catch (Exception e) 
                {
                    continue;
                }
                
               
            }
            while (flag);

           

        }

        public void Tarefa1()
        {
            
            Console.Write("Digite a quantidade de amostras: ");
            int qtdAmostras = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a quantidade de elementos para cada amostra: ");
            int qtdElementos = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine($"Experimento com A = {qtdAmostras} e N = {qtdElementos}");

            int totalAlturaBst = 0;
            int totalAlturaAVL = 0;

            for (int i = 0; i < qtdAmostras; i++)
            {
                BST bst = new BST();
                AVL avl = new AVL();
                for (int j = 0; j < qtdElementos; j++)
                {
                    int num = new Random().Next(1, 100);
                    bst.Insert(num);
                    avl.Insert(num);
                    Console.Write(num + " ");

                }
                Console.WriteLine("");
                totalAlturaBst += bst.Altura();
                totalAlturaAVL += avl.Altura();
                
            }



            float mediaAVL = totalAlturaAVL / qtdAmostras, mediaBST = totalAlturaBst/qtdAmostras, media = (mediaAVL + mediaBST) /2;


            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Altura média geral:     {media}");
            Console.WriteLine($"Altura média BST comum: {mediaBST}");
            Console.WriteLine($"Altura média AVL:       {mediaAVL}");
            Console.WriteLine("--------------------------------");
            Console.ReadKey();

        }

        public void Iniciar()
        {
            ImprimirMenu();

        }
    }
}
