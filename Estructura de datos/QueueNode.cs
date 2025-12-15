using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos
{
    internal class QueueNode
    {
        private int dato;
        private QueueNode next;

        public int Dato
        {
            get { return dato; }
            set { dato = value; }
        }
        public QueueNode Next
        {
            get { return next; }
            set { next = value; }
        }
        public QueueNode(int dato)
        {
            this.dato = dato;
            this.next = null;
        }

        public override string ToString()
        {
            return dato.ToString();
        }
    }
}
