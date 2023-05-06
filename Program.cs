namespace hashing
{

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int var;
            bool b = true;
            do
            {
                Console.Write("Оберіть завдання:");
                var = int.Parse(Console.ReadLine());
                switch (var)
                {
                    case 1:
                        task1();
                        break;
                    case 2:
                        task2();
                        break;
                    case 3:
                        task3();
                        break;
                    case 4:
                        b = false;
                        break;
                    default:
                        throw new Exception("Некоректна відповідь. Будь ласка, введіть 'yes' або 'no'.");
                }
                Console.ReadKey();
                Console.Clear();
            } while (b);
        }
        private static void task1()
        {
            Console.WriteLine("Завдання 1:\n");
            var table_2 = new DirectAddressTable_int(10);

            table_2.Insert(5);
            table_2.Insert(3);
            table_2.Insert(8);
            table_2.Insert(9);
            table_2.OutputTable();

            Console.WriteLine("Mаксимальне число: " + table_2.Max());


            var table_1 = new DirectAddressTable_str(26);

            table_1.Insert("grid");
            table_1.Insert("bag");
            table_1.Insert("apple");
            table_1.Insert("hit");
            table_1.OutputTable();

            Console.WriteLine("Перше слово за алфавітом: " + table_1.Max());
        }
        private static void task2()
        {
            Console.WriteLine("\nЗавдання 2\n");
            int n = DirectAddressTable.GetCount();
            DirectAddressTable d = new DirectAddressTable(n);
            bool a = true;
            do
            {
                Console.WriteLine("Виберіть пункт меню:\n1 - Вставити\n2 - Видалити\n3 - Пошук ");
                int punct = int.Parse(Console.ReadLine());
                switch (punct)
                {
                    case 1:
                        for (int i = 1; i < 8; i++)
                            d.Insert(i);
                        break;
                    case 2:
                        Console.Write("Видалити значення : ");
                        int value2 = int.Parse(Console.ReadLine());
                        d.Delete(value2);
                        Console.Write($"Список за обрахованим ключем за {value2} видалено !");
                        break;
                    case 3:
                        Console.Write("Пошук за значенням : ");
                        int key2 = int.Parse(Console.ReadLine());
                        var nodes = DirectAddressTable.Search(key2);
                        if (nodes.Count == 0)
                            Console.WriteLine("Значення не знайдено!");
                        else
                        {
                            foreach (var node in nodes)
                            {
                                Console.Write(node.Value + " -> ");
                            }
                        }
                        break;
                    default:
                        a = false;
                        break;
                }
                Console.WriteLine("\n------");
            } while (a);

        }
        private static void task3()
        {
            Console.WriteLine("\nЗавдання 3:\n");
            int N = 1000;
            Console.WriteLine("Ключ 61: " + DirectAddressTable.HashFunct(61, N));
            Console.WriteLine("Ключ 62: " + DirectAddressTable.HashFunct(62, N));
            Console.WriteLine("Ключ 63: " + DirectAddressTable.HashFunct(63, N));
            Console.WriteLine("Ключ 64: " + DirectAddressTable.HashFunct(64, N));
            Console.WriteLine("Ключ 65: " + DirectAddressTable.HashFunct(65, N));
        }

    }

}