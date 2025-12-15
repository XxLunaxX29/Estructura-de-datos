using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Estructura_de_datos
{
    internal class NodeList
    {
        private int data;
        private NodeList? next;
        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        public NodeList? Next
        {
            get { return next; }
            set { next = value; }
        }

        public NodeList(int data )
        {
            this.data = data;
            this.next = null;
        }


        public override string ToString()
        {
            return "Contact:" + data.ToString();
        }
    }
}
