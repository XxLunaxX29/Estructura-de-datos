using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos
{
    internal class Graph
    {
        private List<GraphNode> nodos;
        private int[,] matriz;
        private bool dirigido;
        private bool ponderado;
        public Action<string> Output { get; set; }
        public Graph(bool dirigido, bool ponderado)
        {
            nodos = new List<GraphNode>();
            matriz = new int[0, 0];
            this.dirigido = dirigido;
            this.ponderado = ponderado;
        }
        private void Write(string message)
        {
            Output?.Invoke(message);
        }
        public void AddNodo(GraphNode nodo)
        {
            bool existe = nodos.Any(n => n.Data == nodo.Data);
            if (existe)
            {
                Write($"Error: ya existe el vértice '{nodo.Data}'");
                return;
            }

            nodos.Add(nodo);

            int nuevoTam = nodos.Count;
            int[,] nuevaMatriz = new int[nuevoTam, nuevoTam];

            for (int i = 0; i < nuevoTam - 1; i++)
                for (int j = 0; j < nuevoTam - 1; j++)
                    nuevaMatriz[i, j] = matriz[i, j];

            matriz = nuevaMatriz;

            Write($"Nodo '{nodo.Data}' agregado");
        }


        public void AddArista(int src, int dst, int w = 1)
        {
            if (!ponderado) w = 1;
            matriz[src, dst] = w;
            if (!dirigido)
            {
                matriz[dst, src] = w;
            }
        }
        public void AddArista(char origen, char destino)
        {
            int i = nodos.FindIndex(n => n.Data == origen);
            int j = nodos.FindIndex(n => n.Data == destino);

            if (i == -1 || j == -1)
                return;

            matriz[i, j] = 1;

            if (!dirigido)
                matriz[j, i] = 1;
        }


        public bool CheckArista(int src, int dst)
        {
            return matriz[src, dst] != 0;
        }

        public string Print()
        {
            if (nodos.Count == 0)
                return "Grafo vacío";

            string resultado = "  ";

            // Encabezado
            foreach (var n in nodos)
                resultado += n.Data + " ";

            resultado += Environment.NewLine;

            // Filas
            for (int i = 0; i < nodos.Count; i++)
            {
                resultado += nodos[i].Data + " ";

                for (int j = 0; j < nodos.Count; j++)
                    resultado += matriz[i, j] + " ";

                resultado += Environment.NewLine;
            }

            return resultado;
        }

        public void BFS(char start)
        {
            int s = ObtenerIndice(start);
            if (s == -1)
            {
                Write($"Error: el vértice '{s}' no existe.");
                return;
            }
            bool[] visitado = new bool[nodos.Count];
            Queue<int> cola = new Queue<int>();

            visitado[s] = true;
            cola.Enqueue(s);

            while (cola.Count > 0)
            {
                int actual = cola.Dequeue();
                Write(nodos[actual].Data + " ");

                for (int i = 0; i < nodos.Count; i++)
                {
                    if (matriz[actual, i] != 0 && !visitado[i])
                    {
                        visitado[i] = true;
                        cola.Enqueue(i);
                    }
                }
            }
        }

        public void DFS(char start)
        {
            int s = ObtenerIndice(start);
            if (s == -1)
            {
                Write($"Error: el vértice '{s}' no existe.");
                return;
            }
            bool[] visitado = new bool[nodos.Count];
            DFSRecursivo(s, visitado);
        }

        private void DFSRecursivo(int v, bool[] visitado)
        {
            visitado[v] = true;
            Write(nodos[v].Data + " ");

            for (int i = 0; i < nodos.Count; i++)
            {
                if (matriz[v, i] != 0 && !visitado[i])
                {
                    DFSRecursivo(i, visitado);
                }
            }
        }
        public void EliminarArista(int src, int dst)
        {
            matriz[src, dst] = 0;
            if (!dirigido) matriz[dst, src] = 0;
        }
        public void EliminarArista(char src, char dst)
        {
            int i = ObtenerIndice(src);
            int j = ObtenerIndice(dst);
            if (i == -1 || j == -1)
            {
                Write($"Error: alguno de los vértices '{src}' o '{dst}' no existe.");
                return;
            }
            matriz[i, j] = 0;
            if (!dirigido) matriz[j, i] = 0;
            Write("Arista eliminada");
        }
        public void RemoveNodo(char src)
        {
            int s = ObtenerIndice(src);
            if (s == -1)
            {
                Write("Índice inválido");
                return;
            }

            // Eliminar el nodo de la lista
            nodos.RemoveAt(s);

            int size = matriz.GetLength(0);
            int[,] nuevaMatriz = new int[size - 1, size - 1];

            // Copiar todas las filas y columnas excepto la que se elimina
            int filaNueva = 0;
            for (int i = 0; i < size; i++)
            {
                if (i == s) continue; // saltar la fila eliminada
                int colNueva = 0;
                for (int j = 0; j < size; j++)
                {
                    if (j == s) continue; // saltar la columna eliminada
                    nuevaMatriz[filaNueva, colNueva] = matriz[i, j];
                    colNueva++;
                }
                filaNueva++;
            }

            // Reemplazar la matriz antigua
            matriz = nuevaMatriz;
        }
        private int ObtenerIndice(char id)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].Data == id) return i;
            }
            return -1;
        }
    }
}
