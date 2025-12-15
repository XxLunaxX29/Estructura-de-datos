using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos
{
        internal class NodeStack
        {
            public int Value { get; set; }

            // Referencia para stack linked list (apunta al nodo anterior/abajo)
            public NodeStack? Prev { get; set; }

            public NodeStack(int value)
            {
                Value = value;
                Prev = null;
            }

            public override string ToString()
            {
                return Value.ToString();
            }
        }
    
}
