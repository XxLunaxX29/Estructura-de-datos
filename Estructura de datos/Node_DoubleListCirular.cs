using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos
{
    internal class NodoDoubleCircularList
    {
        private int data { get; set; }
        private NodoDoubleCircularList next { get; set; }
        private NodoDoubleCircularList back { get; set; }

        public int Data
        {
            get { return data; }
            set { data = value; }

        }
        public NodoDoubleCircularList Next
        {
            get { return next; }
            set { next = value; }
        }
        public NodoDoubleCircularList Back
        {
            get { return back; }
            set { back = value; }
        }
        public NodoDoubleCircularList(int dato)
        {
            this.Data = dato;
            this.Next = null;
            this.Back = null;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
