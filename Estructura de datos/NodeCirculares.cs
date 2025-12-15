using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Estructura_de_datos
{
    internal class NodeCirculares
    {
        private int data;
        private NodeCirculares next;

        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        public NodeCirculares Next
        {
            get { return next; }
            set { next = value; }
        }

        public NodeCirculares(int data)
        {
            this.data = data;
            this.next = null;
        }
        public override string ToString()
        {
            // Usando el nombre de la variable de instancia 'data'
            return "Dato:" + data;
        }
    }
}
