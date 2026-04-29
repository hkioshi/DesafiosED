using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aula7
{
    public class NodeAVL
    {
        public int Key { get; set; }
        public int Altura { get; set; }
        public int Balanceamento {
            get
            {
                int hEsq = Left is null ? 0 : Left.Altura;
                int hDir = Right is null ? 0 : Right.Altura;
                return hEsq - hDir;
            }
        }

        public NodeAVL Left { get; set; }
        public NodeAVL Right { get; set; }


        public NodeAVL(int Valor) 
        {
            Altura = 1;
            Key = Valor;

        }

        public void RedefinirAltura()
        {
            int hEsq = Left is null ? 0 : Left.Altura;
            int hDir = Right is null ? 0 : Right.Altura;
            Altura = Math.Max(hEsq, hDir) + 1;
        }

       
    }
}
