using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos
{
    internal class ListaDobleCircular
    {
        private NodoDoubleCircularList head;

        public ListaDobleCircular()
        {
            head = null;
        }

        public bool EstaVacia()
        {
            return head == null;
        }

        // --- MÉTODO: AGREGAR (Al final) ---
        public void Add(int data)
        {
            NodoDoubleCircularList newNode = new NodoDoubleCircularList(data);

            // Case 1: empty list (CORRECTO)
            if (head == null)
            {
                head = newNode;
                head.Next = head;
                head.Back = head;
                return;
            }

            // Case 2: insert before head
            if (data < head.Data)
            {
                NodoDoubleCircularList last = head.Back;

                newNode.Next = head;
                newNode.Back = last;

                last.Next = newNode;
                head.Back = newNode;

                head = newNode;
                return;
            }

            // Case 3: insert in middle or end
            NodoDoubleCircularList h = head;

            do
            {
                if (h.Next == head || h.Next.Data > data)
                {
                    newNode.Next = h.Next;
                    newNode.Back = h;

                    h.Next.Back = newNode;
                    h.Next = newNode;
                    return;
                }
                h = h.Next;
            } while (h != head);
        }


        // --- MÉTODO: BUSCAR ---
        // Retorna el Nodo si existe, o null si no existe
        public NodoDoubleCircularList Buscar(int dato)
        {
            if (EstaVacia()) return null;

            NodoDoubleCircularList actual = head;
            do
            {
                if (actual.Data == dato) return actual;
                actual = actual.Next;
            } while (actual != head);

            return null; // No encontrado tras dar la vuelta completa
        }

        // --- MÉTODO: ELIMINAR ---
        // Retorna true si eliminó, false si no lo encontró
        public bool Eliminar(int dato)
        {
            // Usamos el método buscar para ubicar el nodo primero
            NodoDoubleCircularList nodoAEliminar = Buscar(dato);

            if (nodoAEliminar == null) return false; // No existe

            // Si es el único nodo de la lista
            if (nodoAEliminar.Next == nodoAEliminar)
            {
                head = null;
            }
            else
            {
                NodoDoubleCircularList anterior = nodoAEliminar.Back;
                NodoDoubleCircularList siguiente = nodoAEliminar.Next;

                // "Saltamos" el nodo a eliminar
                anterior.Next = siguiente;
                siguiente.Back = anterior;

                // Si borramos la cabeza, debemos mover el puntero al siguiente
                if (nodoAEliminar == head)
                {
                    head = siguiente;
                }
            }
            return true;
        }

        // --- MÉTODO: CONTAR (Count) ---
        public int Contar()
        {
            if (EstaVacia()) return 0;

            int contador = 0;
            NodoDoubleCircularList actual = head;
            do
            {
                contador++;
                actual = actual.Next;
            } while (actual != head);

            return contador;
        }

        // --- MÉTODO: LIMPIAR TODO ---
        public void Limpiar()
        {
            head = null; // El Garbage Collector de C# se encarga del resto
        }

        // --- MÉTODO: OBTENER LISTADO (Flexible para Console/Forms) ---
        public string ObtenerListado()
        {
            if (EstaVacia()) return "La lista está vacía.";

            StringBuilder sb = new StringBuilder();
            NodoDoubleCircularList actual = head;

            do
            {
                sb.Append($"[{actual.Data}] <-> ");
                actual = actual.Next;
            }
            while (actual != head);

            sb.Append("(Inicio)");
            return sb.ToString();
        }

    }
}

