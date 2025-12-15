using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos
{
    internal class PriorityQueue
    {
        private readonly SimpleQueue cola1; // Mayor prioridad
        private readonly SimpleQueue cola2;
        private readonly SimpleQueue cola3; // Menor prioridad

        public PriorityQueue()
        {
            cola1 = new SimpleQueue();
            cola2 = new SimpleQueue();
            cola3 = new SimpleQueue();
        }

        public void Enqueue(int dato, int prioridad) // prioridad 1, 2 o 3
        {
            if (prioridad == 1) cola1.Enqueue(dato);
            else if (prioridad == 2) cola2.Enqueue(dato);
            else if (prioridad == 3) cola3.Enqueue(dato);
            else throw new ArgumentException("Prioridad debe ser 1, 2 o 3");
        }

        public int Dequeue()
        {
            if (!cola1.IsEmpty()) return cola1.Dequeue();
            if (!cola2.IsEmpty()) return cola2.Dequeue();
            if (!cola3.IsEmpty()) return cola3.Dequeue();
            throw new InvalidOperationException("Todas las colas están vacías");
        }

        public int Peek()
        {
            if (!cola1.IsEmpty()) return cola1.Peek();
            if (!cola2.IsEmpty()) return cola2.Peek();
            if (!cola3.IsEmpty()) return cola3.Peek();
            throw new InvalidOperationException("Todas las colas están vacías");
        }

        public override string ToString()
        {
            return $"P1: {cola1}\n P2: {cola2}\n P3: {cola3}";
        }
    }
}

