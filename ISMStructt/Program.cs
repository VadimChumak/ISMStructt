using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISMStruct
{
    class Program
    {
        public struct Item
        {
            public string Name;
            public string Type;
            public string Sort;
            public double Quantity;
            public double Cost;
            public void ShowInfo()
            {
                Console.WriteLine("Назва : {0} Сорт : {1} Ціна за одиницю : {2} Загальна ціна : {3}", Name, Sort, Cost, Quantity * Cost);
            }
            public void SetValue(string info)
            {
                string[] inf = info.Split(' ');
                Name = inf[0];
                Type = inf[1];
                Sort = inf[2];
                Quantity = double.Parse(inf[3]);
                Cost = double.Parse(inf[4]);
            }

        }

        static void PrintInfo(string Item_Name, Item[] mass)
        {
            bool count = false;
            foreach (Item i in mass)
            {
                if (i.Name == Item_Name) { i.ShowInfo(); count = true; }
            }
            if (count == false) Console.WriteLine("Товар відсутній!");
        }

        static Item[] Sort(Item[] mass)
        {
            Item[] arr = mass;
            Item tmp;
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j].Quantity > arr[i].Quantity)
                    {
                        tmp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = tmp;
                    }
                }
            return arr;
        }

        static Item[] SetFromFile()
        {
            int n;
            string FileName = @"Struct.txt";
            string[] inform = File.ReadAllLines(FileName);
            n = int.Parse(inform[0]);
            Item[] mass = new Item[n];
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i].SetValue(inform[i + 1]);
            }
            return mass;
        }

        static void PrintAll(Item[] mass)
        {
            foreach (Item i in mass) i.ShowInfo();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Item[] item = SetFromFile();
            PrintAll(item);
            Console.WriteLine("-----------------------------------------------------");
            Sort(item);
            PrintAll(item);
            string name = Console.ReadLine();
            PrintInfo(name, item);
        }
    }
}