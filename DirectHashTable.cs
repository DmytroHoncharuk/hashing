using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashing
{
    public class DirectAddressTable_str
    {
        private string[] table;

        public DirectAddressTable_str(int size)
        {
            table = new string[size];
        }
        public void Insert(string str)
        {
            int index = HashFunction(str);
            table[index] = str;
        }
        public string Max()
        {
            return TableMax(table, 0);
        }

        private string TableMax(string[] table, int index)
        {
            if (index < 0)
            {
                return null;
            }
            else if (table[index] != null)
            {
                return table[index];
            }
            else
            {
                return TableMax(table, index + 1);
            }
        }
        private int HashFunction(string key)
        {
            int index = key[0];
            if (index >= 'A' && index <= 'Z')
            {
                index = index - 'A';
            }
            else if (index >= 'a' && index <= 'z')
            {
                index = index - 'a';
            }
            else
            {
                index = -1;
            }
            return index;
        }   
        public void OutputTable()
        {
            for (int i = 0;i < table.Length;i++ )
                Console.WriteLine($"|{i}|:{table[i]}");
        }
    }
    public class DirectAddressTable_int
    {
        private int[] table;

        public DirectAddressTable_int(int size)
        {
            table = new int[size];
        }
        public void Insert(int key)
        {
            table[key] = key;
        }
        public int Max()
        {
            return TableMax(table, table.Length-1);
        }
        private int TableMax(int[] table, int index)
        {
            if (index < 0)
            {
                return -1;
            }
            else if (table[index] != 0)
            {
                return table[index];
            }
            else
            {
                return TableMax(table, index - 1);
            }
        }
        public void OutputTable()
        {
            for (int i = 0; i < table.Length; i++)
                Console.WriteLine($"|{i}|:{table[i]}");
        }

    }
}
