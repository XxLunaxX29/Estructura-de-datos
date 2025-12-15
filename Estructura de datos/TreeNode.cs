using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos
{
    internal class TreeNode
    {
        public int Valor;
        private TreeNode? izquierda;
        private TreeNode? derecha;

        public TreeNode? Izquierda
        {
            get { return izquierda; }
            set { izquierda = value; }
        }

        public TreeNode? Derecha
        {
            get { return derecha; }
            set { derecha = value; }
        }

        public TreeNode(int valor)
        {
            Valor = valor;
        }
    }
}
