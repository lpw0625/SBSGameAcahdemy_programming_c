using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{

    public class Inven
    {
        public Item[] ItemArr;
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

        public int GetPrice()
        {
            return price;
        }


            

      
       
        public Item(String _name , int _price)
        {
            name = _name;
            price = _price;
        }

        // 생성자의 매개 변수를 메인 함수에 사용하지 않으면 생성이 안된다. 

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] a = new int[10];
            //int[,] a = new int[10,10]; // 이차원 배열 
            Item itemA = new Item("단검", 100);
            Item itemB = new Item("장검", 200);
            Item itemC = new Item("활", 300);

            Console.WriteLine("아이템 목록 : " );
            Console.ReadLine();


        }
    }
}
