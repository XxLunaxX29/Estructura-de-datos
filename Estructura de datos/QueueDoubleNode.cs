using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos
{
    internal class QueueDoubleNode
    {
        private int dato;
        private QueueDoubleNode next;
        private QueueDoubleNode prev;
        public int Dato
        {
            get { return dato; }
            set { dato = value; }
        }
        public QueueDoubleNode Next
        {
            get { return next; }
            set { next = value; }
        }
        public QueueDoubleNode Prev
        {
            get { return prev; }
            set { prev = value; }
        }
        public QueueDoubleNode(int dato)
        {
            this.dato = dato;
            this.next = null;
            this.prev = null;
        }
        public override string ToString()
        {
            return dato.ToString();
        }
    }
}
