using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Linked List
    /// </summary>
    public class Node
    {
        public Node Prev;
        public string Property;
        public string Value;
        public Node next;
        public Node(string str1, string str2)
        {
            Prev = null;
            Property = str1;
            Value = str2;
            next = null;
        }
    }
    public class LinkedList1
    {

        public Node Head;
        public Node Tail;

        public LinkedList1()
        {
            Head = null;
            Tail = null;
        }
        public void Add(string str1, string str2)
        {
            ///////////////////////////////////////////////////////////////////
            //
            //  Name:        Add
            //  Input:       String,String
            //  Output:      Void
            //  Description: Used To add Node to last Position of linked List
            //
            ////////////////////////////////////////////////////////////////////
            Node temp = Head;
            Node newn = new Node(str1, str2);
            if (Head == null)
            {
                Head = newn;
                Tail = newn;
            }
            else
            {
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = newn;
                newn.Prev = temp;
                Tail = newn;
            }
        }
        public string Traverse()
        {
            /////////////////////////////////////////////////////////////////////////////
            //
            //  Name:        Add
            //  Input:       String,String
            //  Output:      string
            //  Description: Used To Traverse last Position of linked List
            //               And return string which contains all the linkedlist data   
            //
            //////////////////////////////////////////////////////////////////////////////
            string PropertyValue = null;
            Node temp = Head;
            while (temp != null)
            {
                PropertyValue = PropertyValue + "|" + temp.Property + "->" + temp.Value;
                temp = temp.next;
            }
            return PropertyValue;
        }
    }
}
