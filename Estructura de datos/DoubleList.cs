using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Estructura_de_datos
{
    internal class DoubleList
    {
        private NodeDoubleList? head;
        public NodeDoubleList? Head
        {
            get { return head; }
            set { head = value; }
        }

        public DoubleList()
        {
            this.head = null;
        }

        public void Add(NodeDoubleList n)
        {

            if (head == null)
            {
                head = n;
                return;
            }

            if (n.Data < head.Data)
            {
                n.Next = head;
                head.Back = n;
                head = n;
                return;
            }

            NodeDoubleList? h = head;
            while (h.Next != null)
            {
                if (n.Data < h.Next.Data)
                {
                    n.Next = h.Next;
                    n.Back = h;
                    h.Next = n;
                    n.Next.Back = n;
                    return;
                }
                h = h.Next;

            }
            h.Next = n;
            n.Back = h;
        }
        public void Remove(int data)
        {
            if (head == null)
            {
                return;
            }
            if (data < head.Data)
            {
                return;
            }
            if (head.Data == data)
            {
                if (head.Next != null)
                {
                    head.Next.Back = null;
                    head = head.Next;
                }
                else
                {
                    head = null;
                }
                    return;
            }


            NodeDoubleList? h = head;
            while (h.Next != null)
            {
                if (data < h.Next.Data)
                {
                    return;
                }
                if (h.Next.Data == data)
                {
                    h.Next = h.Next.Next;
                    if (h.Next != null)
                        h.Next.Back = h;
                    return;
                }


                h = h.Next;
            }
            return;

        }

        public bool Exists(int data)
        {
            if (head == null)
            {
                return false;
            }
            if (data < head.Data)
            {
                return false;
            }
            if (head.Data == data)
            {
                return true;
            }

            NodeDoubleList? h = head;
            while (h != null)
            {
                if (data < h.Data)
                {
                    return false;
                }
                if (h.Data == data)
                {
                    return true;
                }
                h = h.Next;
            }
            return false;
        }

        public int Count()
        {
            int i = 0;
            NodeDoubleList? h = head;
            while (h != null)
            {
                i++;
                h = h.Next;
            }
            return i;
        }

        public string Show()
        {
            if (head == null)
            {
                return "Empty List";
            }
            int i = 0;
            NodeDoubleList? h = head;
            string datas = "";
            while (h != null)
            {
                datas += $"Node [{i}] and: " + h + Environment.NewLine;
                h = h.Next;
                i++;

            }
            return datas;

        }
        public string ReverseShow()
        {
            if (head == null)
            {
                return "Empty List";
            }
            NodeDoubleList? h = head;
            NodeDoubleList? last = null;
            int i = 0;
            string datas = "";
            while (h != null)
            {
                last = h;
                h = h.Next;
                i++;
            }
            h = last;
            i--;
            while (h != null)
            {
                datas += $"Node [{i}] {h} " + Environment.NewLine;
                h = h.Back;
                i--;
            }

            return datas;
        }

        public void Clear()
        {
            head = null;
        }

        public override string ToString()
        {
            string i = "";
            NodeDoubleList? h = head;
            while (h != null)
            {
                i += h.ToString() + Environment.NewLine;
                h = h.Next;
            }
            return i;
        }
    }
}

