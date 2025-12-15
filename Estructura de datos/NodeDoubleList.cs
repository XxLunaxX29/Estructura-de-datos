using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos
{
    internal class NodeDoubleList
    {
            private int data;
            private NodeDoubleList? next;
            private NodeDoubleList? back;

            public int Data
            {
                get { return data; }
                set { data = value; }
            }

            public NodeDoubleList? Next
            {
                get { return next; }
                set { next = value; }
            }
            public NodeDoubleList? Back
            {
                get { return back; }
                set { back = value; }
            }

            public NodeDoubleList(int data)
            {
                this.data = data;
                this.next = null;
                this.back = null;
            }

        public override string ToString()
        {
            return "Data: " + data;
        }
    }
}

