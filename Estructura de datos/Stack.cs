using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Estructura_de_datos
{
    internal class Stack
    {
        private bool esEstatica; // variable para distinguir tipo de pila

        // variables para lógica dinámica
        private NodeStack? topNode; // Tope para la dinámica

        // variables para lógica estática
        private NodeStack[]? array; // Arreglo para la estática
        private int topIndex;  // Índice para la estática
        private int tamañoMax;

        // CONSTRUCTOR 1: Para Pila DINÁMICA (Sin límite)
        public Stack()
        {
            esEstatica = false;
            topNode = null;
        }

        // CONSTRUCTOR 2: Para Pila ESTÁTICA (Con límite)
        public Stack(int tamaño)
        {
            if (tamaño <= 0) throw new ArgumentException("El tamaño debe ser positivo.");

            esEstatica = true;
            tamañoMax = tamaño;
            array = new NodeStack[tamaño];
            topIndex = -1;
        }

        // MÉTODOS  PUSH, POP, PEEK
        public void Push(NodeStack nodo)
        {
            if (esEstatica)
            {
                if (topIndex == tamañoMax - 1)
                    throw new InvalidOperationException("La pila estática está llena (Overflow).");

                topIndex++;
                array![topIndex] = nodo;
            }
            else
            {
                nodo.Prev = topNode;
                topNode = nodo;
            }
        }

        // 🔥 MÉTODO ADAPTADO
        public void Push(int dato)
        {
            NodeStack nodo = new NodeStack(dato);
            Push(nodo);
        }
        public NodeStack Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("La pila está vacía.");

            if (esEstatica)
            {
                // logica estática
                NodeStack val = array![topIndex]; // Guardamos el valor a retornar
                array[topIndex] = null!; // Limpiamos referencia
                topIndex--; // Decrementamos el índice del tope
                return val;
            }
            else
            {
                // logica dinámica
                NodeStack val = topNode!; // Guardamos el valor a retornar
                topNode = topNode!.Prev; // Bajamos el top al nodo anterior
                return val;
            }
        }

        public NodeStack Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("La pila está vacía.");

            if (esEstatica)
            {
                return array![topIndex];
            }
            else
            {
                return topNode!;
            }
        }

        public bool IsEmpty()
        {
            if (esEstatica)
                return topIndex == -1;
            else
                return topNode == null;
        }

        public void Clear()
        {
            if (esEstatica)
            {
                topIndex = -1;
                // Opcional: limpiar el arreglo
                Array.Clear(array!, 0, array!.Length);
            }
            else
            {
                topNode = null;
            }
        }

        public int Count()
        {
            if (esEstatica)
            {
                return topIndex + 1;
            }
            else
            {
                int count = 0;
                NodeStack? t = topNode;
                while (t != null)
                {
                    count++;
                    t = t.Prev;
                }
                return count;
            }
        }

        // Método ToString para ver el contenido
        public override string ToString()
        {
            string result = "";

            if (esEstatica)
            {
                result += "Modo: Estático (Array)\n";
                if (IsEmpty()) return result + "Pila vacía.";

                for (int i = topIndex; i >= 0; i--)
                {
                    result += $"[{array![i].Value}]\n";
                }
            }
            else
            {
                result += "Modo: Dinámico (Nodos)\n";
                if (IsEmpty()) return result + "Pila vacía.";

                NodeStack? t = topNode;
                while (t != null)
                {
                    result += $"[{t.Value}]\n";
                    t = t.Prev;
                }
            }
            return result;
        }
    }
}

