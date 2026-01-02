using DelegateEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEx
{
    public class Button
    {
        public delegate void Button();

        public void OnButton(Button button)
        {
            button();
        }
    }

  
    public class Item
    {
        private string m_name;

        private int m_price;
        public int Price { get { return m_price; } }
        private int m_att;
        private int m_range;


        public delegate int ItemDelegate();
        public void TestDelegate(ItemDelegate dele)
        {
            dele();
        }
        // 딜리게이트를 통해서 만들어진 친구들
        // 리턴을 안한다 - 액션 
        public Action<int, int> TestAction;
        // 리턴을 한다 - 펑션
        public Func<int> TestFunc;


        public void TestConsoleWrite()
        {
            Console.WriteLine("그냥 메서드");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Item> listInt = new List<Item>();
            listInt.Add(new Item());
            listInt.Add(new Item());
            listInt.Add(new Item());

            listInt[0].TestDelegate(() =>
            {
                Console.WriteLine(" 딜리게이트 ");
                return 0;
            });
            listInt[0].TestConsoleWrite();

            listInt[0].TestAction = (a, b) => { Console.WriteLine($"{a} + {b} = {a + b}"); };
            listInt[0].TestAction.Invoke(1, 5);
            listInt[0].TestAction.Invoke(2, 7);
            listInt[0].TestAction = (a, b) => { Console.WriteLine($"{a} - {b} = {a - b}"); };
            listInt[0].TestAction.Invoke(1, 5);
            listInt[0].TestAction.Invoke(2, 7);

            Console.ReadKey();


            listInt.Sort((a, b) => { return a.Price.CompareTo(b.Price); });
        }
    }
}

