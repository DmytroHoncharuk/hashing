using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace hashing
{
    public class DirectAddressTable
    {
        private static DoublyLinkedList[] table;
        private static int N;
        private static float A = 0.61803398875F;
        public static int GetCount()
        {
            Console.WriteLine("Оберіть розмірність таблиці");
            N = int.Parse(Console.ReadLine());
            return N;
        }
        public DirectAddressTable(int N)
        {
            table = new DoublyLinkedList[N];

            for (int i = 0; i < N; i++)
            {
                table[i] = new DoublyLinkedList();
            }
        }
        public void Insert(int value)
        {
            int key = HashFunct(value);
            Console.WriteLine($"За ключем {key} вставлено значення {value}");
            var newNode = new DoublyLinkedList_Node(key, value);
            table[key].Insert(newNode);
        }
        public void Delete(int value)
        {
            int index_delete = HashFunct(value); 
            table[index_delete] = null;       
        }
        public void Special_Delete(int value)
        {
            for (int i = 0; i < table.Length; i++)
            {
                DoublyLinkedList_Node currentNode = table[i].first;
                while (currentNode != null)
                {
                    if (currentNode.Value == value)
                    {
                        table[i].Delete(currentNode);
                        return;
                    }
                    currentNode = currentNode.Next;
                }
            }
        }
        public static List<DoublyLinkedList_Node> Search(int value)
        {
            List<DoublyLinkedList_Node> result = new List<DoublyLinkedList_Node>();
            int key = HashFunct(value);
            result = new List<DoublyLinkedList_Node>();
            try
            {
                var current = table[key].first;
                while (current != null)
                {
                    if (current.Key == key)
                    {
                        result.Add(current);
                    }
                    current = current.Next;
                }
            } catch (Exception e)
            {
               
            }
            return result;
        }
        public static int HashFunct(int key)
        {
            int index = (int)Math.Floor(N * (key * A % 1));
            return index;
        }
        public static int HashFunct(int key, int n)
        {
            int index = (int)Math.Floor(n * (key * A % 1));
            return index;
        }
    }

    public class DoublyLinkedList_Node
    {
        public int Key;
        public int Value;
        public DoublyLinkedList_Node Previous; 
        public DoublyLinkedList_Node Next; 

        public DoublyLinkedList_Node(int key, int value)
        {
            Key = key;
            Value = value;
        }
        public DoublyLinkedList_Node( int value)
        {
            Value = value;
        }
    }

    public class DoublyLinkedList
    {
        public DoublyLinkedList_Node first; 
        public DoublyLinkedList_Node last;

        public void Insert(DoublyLinkedList_Node newNode)
        {
            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.Next = newNode;
                newNode.Previous = last;
                last = newNode;
            }
        }

        public void Delete(DoublyLinkedList_Node node)
        {
            if (node == first)
            {
                first = node.Next;
            }
            else
            {
                node.Previous.Next = node.Next;
            }

            if (node == last)
            {
                last = node.Previous;
            }
            else
            {
                node.Next.Previous = node.Previous;
            }
        }
    }
}
