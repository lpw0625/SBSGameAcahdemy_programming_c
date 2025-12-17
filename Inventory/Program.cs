using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{

    public class Inven <T> where T : Item
    {
        T[] arrayItem;
        int selectNum;
        int x;
        int y;

        public Inven(int _length)
        {
            if (_length < 10)
            {
                _length = 10;
            }
            else if (_length > 50)
            {
                _length = 50;
            }
            selectNum = 0;
            arrayItem = new Item[_length];
        }

        public Inven(int _x, int _y)
        {
            x = _x;
            y = _y;
            int _length = _x * _y;
            selectNum = 0;
            arrayItem = new Item[_length];
        }


        public void AddItem(Item _item)
        {
            for (int i = 0; i < arrayItem.Length; i++)
            {
                if (arrayItem[i] == null)
                {
                    arrayItem[i] = _item;
                    break;
                }
            }
        }

        public void AddItemAt(Item _item, int _index)
        {

            if (_index < 0 || _index > arrayItem.Length)
            {
                Console.WriteLine($"입력한 인데스값이 : {_index} 자동으로 들어갑니다.");
                AddItem(_item);
            }
            else
            {
                for (int i = _index; i < arrayItem.Length; i++)
                {
                    if (arrayItem[i] == null)
                    {
                        arrayItem[i] = _item;
                        break;
                    }
                }
            }
        }

        public void RemoveItem()
        {
            arrayItem[selectNum] = null;
        }
        public void RemoveAllItem()
        {
            for (int i = 0; i < arrayItem.Length; i++)
            {
                if (arrayItem[i] != null)
                    arrayItem[i] = null;
            }
        }


        public void ShowInven()
        {
            for (int i = 0; i < arrayItem.Length; i++)
            {
                if (i != 0 && i % x == 0)
                    Console.WriteLine();

                if (i == selectNum)
                {
                    if (arrayItem[i] != null)
                        Console.Write("★");
                    else
                        Console.Write("☆");
                }
                else
                {
                    if (arrayItem[i] != null)
                        Console.Write("●");
                    else
                        Console.Write("○");
                }
            }
            Console.WriteLine();
        }

        public void SelectFunc()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            Console.Clear();

            switch (keyInfo.Key)
            {
                case ConsoleKey.A:
                    if (selectNum > 0)
                        selectNum--;
                    break;

                case ConsoleKey.D:
                    if (selectNum < arrayItem.Length - 1)
                        selectNum++;
                    break;

                case ConsoleKey.R:
                    RemoveItem();
                    break;

                default:
                    break;
            }
        }

        public void ShowItemInfo()
        {
            if (arrayItem[selectNum] != null)
            {
                Console.WriteLine("아이템 이름 : " + arrayItem[selectNum].Name);
                Console.WriteLine("아이템 가격 : " + arrayItem[selectNum].Price);
            }
            else
            {
                Console.WriteLine("빈공간");
            }

        }
        public void ShowAllItmeInfo()
        {
            for (int i = 0; i < arrayItem.Length; i++)
            {

            }
        }

    }

    public class Item
    {
        string name;
        public string Name { get { return name; } }
        int price;
        public int Price { get { return price; } }


        public string GetName()
        {
            return name;
        }


        public Item(string _name, int _price)
        {
            name = _name;
            price = _price;
        }

    }

    public class CashItem
    {

 
        public CashItem(string _name, int _price)
        {
            name = _name;
            price = _price;
        }

    }


    public class Program
    {
        static void Main(string[] args)
        {
           
            Inven inven = new Inven(5, 4);

            Inven<CashItem> cashInven = new Inven<CashItem>(5, 4);

            CashItem itemA = new CashItem("단검", 100);
            CashItem itemB = new CashItem("장창", 500);
            CashItem itemC = new CashItem("지팡이", 1000);
            CashItem itemD = new CashItem("대검", 2500);
            CashItem itemE = new CashItem("방패", 700);


            inven.AddItem(itemA);
            inven.AddItem(itemB);
            inven.AddItem(itemC);
            inven.AddItemAt(itemD, 11);
            inven.AddItemAt(itemE, 11);

            int[,] arrayA = new int[10,10];
            

            //List<Inven> listItem = new List<Inven>();


            listItem[0].AddItem(itemA);
            listItem[1].AddItem(itemB); // 이차원 배열

            //List<Item> listItem = new List<Item>();
            //listItem.Add(itemA);
            //listItem.Add(itemB);
            //listItem.Add(itemC);
            //listItem.Add(itemD);
            //listItem.Add(itemE);

            for (int i = 0; i < listItem.Count i++)
            {
                Console.WriteLine(listItem[i].Name);
            }
            Console.ReadLine();
          
            List<int> ilstA = new List<int>();
            LinkedList<int> i = new LinkedList<int>();
            Dictionary<string, int> d = new Dictionary<string, int>();
           
             




            while (true)
            {
                inven.ShowInven();
                inven.ShowItemInfo();
                inven.SelectFunc();
            }

        }
    }
}