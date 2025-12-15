using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos
{
    internal class CircularQueue
    {
        private QueueNode head;

        public CircularQueue()
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
                head.Next = head; // apunta a sí mismo
            }
            else
            {
                QueueNode h = head;
                // recorremos hasta el último nodo (que apunta a head)
                while (h.Next != head)
                {
                    h = h.Next;
                }
                h.Next = nuevoNodo;
                nuevoNodo.Next = head; // nuevo nodo apunta a head
            }
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("La cola está vacía");

            int dato = head.Dato;

            if (head.Next == head) // solo un nodo
            {
                head = null;
            }
            else
            {
                // buscamos el último nodo para actualizar su Next
                QueueNode h = head;
                while (h.Next != head)
                {
                    h = h.Next;
                }
                h.Next = head.Next; // último nodo apunta al nuevo head
                head = head.Next;   // movemos head
            }
            return dato;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("La cola está vacía");
            return head.Dato;
        }

        public override string ToString()
        {
            if (head == null) return "Cola circular vacía";
            QueueNode h = head;
            var resultado = "";
            do
            {
                resultado += h.Dato + " → ";
                h = h.Next;
            } while (h != head);
            return resultado + "(vuelve al inicio)";
        }

    }
}
