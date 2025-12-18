using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListEx
{

    public abstract class Character

    {

        public Character()
        {
            Console.WriteLine("1");
        }

        public Character(int a)
        {
            Console.WriteLine("2");
        }

        public abstract void Attack();
    
         protected int att = 3;

        public virtual int GetAtt()
        {


            {
                return att;
            }
        }

        public void Damaged()
        {
              int _att = GetAtt();
              Console.WriteLine(_att);
        }
    }



// 


    public class Player : Character
    {

       public Player(int a) : base(a)
        {
            Console.WriteLine("11");
        }

        public override void Attack()
        {
            throw new NotImplementedException(); // 경고를 하기 위한 객체 

        }

        public override int GetAtt()
        {
            ////this.GetAtt();
            //base.GetAtt(); // 부모 클래스를 의미한다. 
            //return att * 2;

            return base.GetAtt();
        }
    }


    public class Monster : Character
    {
        public override void Attack()
        {
            throw new NotImplementedException(); //89 경고를 하기 위한 객체 

        }

    }
    public class Inven<T>
    {
        public T data;
    }

    public class Program
    {
        static void Main(string[] args)
        
        {
            Dictionary<string, int> players = new Dictionary<string, int>();
            players.Add("Knight",1);
            players.Add("Mage", 2);

            int value = 0;
            string tempKey = "Knight";
            if (players.ContainsKey(tempKey) == true)
                value = players[tempKey];
            else
                Console.WriteLine("그런거 없습니다.");




            Inven<int> invenA = new Inven<int>();
            invenA.data = 0;

            Inven<string> invenB = new Inven<string>();
            invenB.data = "";

            List<int> ints = new List<int>();
            
            for (int i = 0; i < 10; i++)
            {
                ints.Add(i);
                Console.WriteLine("Count : " + ints.Count);
                Console.WriteLine("Capacity : " + ints.Capacity);
            }
            Console.ReadLine();
            LinkedList<int> list = new LinkedList<int>();
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();


        }
    }
}