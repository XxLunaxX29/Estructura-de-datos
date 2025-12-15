using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Estructura_de_datos
{
    internal class List
    {
        private NodeList? head;

        public NodeList? Head
        {
            get { return head; }
            set { head = value; }
        }

        public List()
        {
            this.head = null;
        }

        public void Add(NodeList n)
        {
            // Empty list
            if (head == null)
            {
                head = n;
                return;
            }
            // Insert in order
            if (n.Data < head.Data)
            {
                //Insert at the beginning
                n.Next = head;
                head = n;
                return;
            }
            NodeList? h = head;
            while (h.Next != null)
            {
                if (n.Data < h.Next.Data)
                {
                    // Insert in the middle
                    n.Next = h.Next;
                    h.Next = n;
                    return;
                }
                h = h.Next;
            }
            // Insert at the end
            h.Next = n;

        }
        // Remove Method
        public void Remove(int id)
        {
            // Empty list
            if (head == null)
            {
                return;
            }
            // If dato is less than head, it cannot be in the list
            if (id < head.Data)
            {
                return;
            }
            // If dato is equal to head, remove head
            if (head.Data == id)
            {
                head = head.Next;
                return;
            }
            NodeList? h = head;
            // Move through the list
            while (h.Next != null)
            {
                // If dato is less than current node, it cannot be in the list
                if (id < h.Next.Data)
                {
                    return;
                }
                if (h.Next.Data == id)
                {
                    // Remove node
                    h.Next = h.Next.Next;
                    return;
                }
                h = h.Next;
            }
            // If we reach here, dato is not in the list
            return;
        }

        //Method Exists
        public bool Exists(int id)
        {
            // Empty list
            if (head == null)
            {
                return false;
            }
            // If dato is less than head, it cannot be in the list
            if (id < head.Data)
            {
                return false;
            }
            // If dato is equal to head, it is in the list
            if (head.Data == id)
            {
                return true;
            }

            NodeList? h = head;
            // Move through the list
            while (h != null)
            {
                // If dato is less than current node, it cannot be in the list
                if (id < h.Data)
                {
                    return false;
                }
                if (h.Data == id)
                {
                    return true;
                }
                h = h.Next;
            }
            // If we reach here, dato is not in the list
            return false;
        }
        //Count method
        public int Count()
        {
            int count = 0;
            NodeList? h = head;
            while (h != null)
            {
                count++;
                h = h.Next;
            }
            return count;
        }

        public override string ToString()
        {
            string s = "";
            NodeList? h = head;
            while (h != null)
            {
                s += h.ToString() + Environment.NewLine;
                h = h.Next;
            }
            return s;
        }
    }
}

