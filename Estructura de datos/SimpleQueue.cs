using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos
{
    internal class SimpleQueue
    {
        private QueueNode head;

        public SimpleQueue()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }
        public void Enqueue(int dato)
        {
            QueueNode nuevoNodo = new QueueNode(dato);
            if (IsEmpty())
            {
                head = nuevoNodo;
            }
            else
            {
                QueueNode h = head;
                while (h.Next != null)
                {
                    h = h.Next;
                }
                h.Next = nuevoNodo;
            }
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("La cola está vacía.");
            }
            int dato = head.Dato;
            head = head.Next;
            return dato;
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("La cola está vacía.");
            }
            return head.Dato;
        }

        public override string ToString()
        {
            if (head == null) return "Cola vacía";
            QueueNode h = head;
            var resultado = "";
            while (h != null)
            {
                resultado += h.Dato + " → ";
                h = h.Next;
            }
            return resultado + "null";
        }
    }
}
