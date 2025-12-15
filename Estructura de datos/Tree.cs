using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos
{
    internal class Tree
    {
        private TreeNode? raiz;

        private TreeNode? Raiz
        {
            get { return raiz; }
            set { raiz = value; }
        }

        public int Numero { get; private set; }

        public Tree()
        {
            raiz = null;
        }

        public void Agregar(int valor)
        {
            raiz = AgregarRecursivo(raiz, valor);
        }

        private TreeNode AgregarRecursivo(TreeNode? actual, int numero)
        {
            if (actual == null)
            {
                return new TreeNode(numero);
            }
            if (numero == actual.Valor)
            {
                Console.WriteLine("El número ya existe en el árbol");
                return actual;
            }
            if (numero < actual.Valor)
            {
                actual.Izquierda = AgregarRecursivo(actual.Izquierda, numero);
            }
            else
            {
                actual.Derecha = AgregarRecursivo(actual.Derecha, numero);
            }
            return actual;
        }

        public void Eliminar(int valor)
        {
            raiz = EliminarRecursivo(raiz, valor);
        }

        private TreeNode? EliminarRecursivo(TreeNode? actual, int? numero)
        {
            if (actual == null)
            {
                Console.WriteLine("El número no se encuentra en el árbol.");
                return null;
            }
            // Buscar el nodo
            if (numero < actual.Valor)
            {
                actual.Izquierda = EliminarRecursivo(actual.Izquierda, numero);
            }
            else if (numero > actual.Valor)
            {
                actual.Derecha = EliminarRecursivo(actual.Derecha, numero);
            }
            else
            {
                // Nodo encontrado
                // Caso 1: sin hijos
                if (actual.Izquierda == null && actual.Derecha == null)
                {
                    return null;
                }
                // Caso 2: un hijo
                if (actual.Izquierda == null)
                {
                    return actual.Derecha;
                }
                if (actual.Derecha == null)
                {
                    return actual.Izquierda;
                }
                // Caso 3: dos hijos
                // Encuentra el sucesor mínimo (menor de la derecha)
                TreeNode sucesor = EncontrarMinimo(actual.Derecha);
                actual.Valor = sucesor.Valor;
                actual.Derecha = EliminarRecursivo(actual.Derecha, sucesor.Valor);
            }
            return actual;
        }

        // Método auxiliar para encontrar el nodo con el valor mínimo
        private TreeNode EncontrarMinimo(TreeNode nodo)
        {
            while (nodo.Izquierda != null)
            {
                nodo = nodo.Izquierda;
            }
            return nodo;
        }

        public void MostrarPreOrden()
        {
            MostrarPreOrdenRecursivo(raiz);
            Console.WriteLine();
        }

        private void MostrarPreOrdenRecursivo(TreeNode? nodo)
        {
            if (nodo == null)
                return;

            // Paso 1: mostrar nodo
            Console.Write(nodo.Valor + " ");

            // Paso 2: recorrer izquierda
            MostrarPreOrdenRecursivo(nodo.Izquierda);

            // Paso 3: recorrer derecha
            MostrarPreOrdenRecursivo(nodo.Derecha);
        }

        public void MostrarInOrden()
        {
            MostrarInOrdenRecursivo(raiz);
            Console.WriteLine(); // Salto de línea al final
        }

        private void MostrarInOrdenRecursivo(TreeNode? nodo)
        {
            if (nodo == null)
                return;

            // Paso 1: recorrer izquierda
            MostrarInOrdenRecursivo(nodo.Izquierda);

            // Paso 2: mostrar el valor
            Console.Write(nodo.Valor + " ");

            // Paso 3: recorrer derecha
            MostrarInOrdenRecursivo(nodo.Derecha);
        }

        public void MostrarPostOrden()
        {
            MostrarPostOrdenRecursivo(raiz);
            Console.WriteLine();
        }

        private void MostrarPostOrdenRecursivo(TreeNode? nodo)
        {
            if (nodo == null)
                return;

            // Paso 1: recorrer izquierda
            MostrarPostOrdenRecursivo(nodo.Izquierda);

            // Paso 2: recorrer derecha
            MostrarPostOrdenRecursivo(nodo.Derecha);

            // Paso 3: mostrar nodo
            Console.Write(nodo.Valor + " ");
        }

    }
}
