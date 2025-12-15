using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos
{
    internal class DoubleQueue
    {
        private QueueDoubleNode head;

        public DoubleQueue()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Enqueue(int dato)
        {
            QueueDoubleNode nuevoNodo = new QueueDoubleNode(dato);
            if (IsEmpty())
            {
                head = nuevoNodo;
            }
            else
            {
                QueueDoubleNode h = head;
                while (h.Next != null)
                {
                    h = h.Next;
                }
                h.Next = nuevoNodo;
                nuevoNodo.Prev = h;
            }
        }

        public void EnqueueFront(int dato)
        {
            QueueDoubleNode nuevoNodo = new QueueDoubleNode(dato);
            if (IsEmpty())
            {
                head = nuevoNodo;
                return;
            }
            else
            {
                nuevoNodo.Next = head;
                head.Prev = nuevoNodo;
                head = nuevoNodo;
            }
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("La cola está vacía.");
            }
            int dato = head.Dato;
            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                head = head.Next;
                head.Prev = null;
            }
            return dato;


        }

        public int DequeueBack()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("La cola está vacía.");
            }
            QueueDoubleNode h = head;
            while (h.Next != null)
            {
                h = h.Next;
            }
            int dato = h.Dato;
            if (h.Prev == null)
            {
                head = null;
            }
            else
            {
                h.Prev.Next = null;
            }

            return dato;
        }
        public int Peek()
        {
            if (head == null) throw new InvalidOperationException("Cola vacía");
            return head.Dato;
        }

        public override string ToString()
        {
            if (head == null) return "Cola doble vacía";
            QueueDoubleNode h = head;
            var resultado = "";
            while (h != null)
            {
                resultado += h.Dato + " ↔ ";
                h = h.Next;
            }
            return resultado + "null";
        }

    }
}

