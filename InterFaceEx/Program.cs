using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceEx
{

    public interface IBattle
    {

        int Att { get; set; }
        void Damaged(UnitParent unit);
       

    }
    public class UnitParent
    {

        public int hp;
        public int att;
        public void Damaged(UnitParent unit)
        {
            Console.WriteLine("상대방의 공격 : " + unit.att);
        }

    }

    public class Player : UnitParent, IBattle
    {

        public int Att

        {
            get
            {
                return att;
            }

            set

            {
                att = value;
            }
        }
    }

    // 인터페이스를 사용을 하면 인터페이스 맴버를 무조건 구현을 해야한다.

    public class Monster : UnitParent, IBattle
    
    {

        public int Att

        {
            get
            {
                return att;
            }

            set

            {
                att = value;
            }
        }
    }

    //public class TestFunc(att)

    //{
    //    Console.WriteLine(att);
    //}



    internal class Program
    {
        static void Main(string[] args)
        {

            Player player = new Player();
            Monster monA = new Monster();
           
            player.Att = 10;
            monA.Att = 10;
            player.Damaged(monA);
            monA.Damaged(player);


            //null

            //Player player2 = new Player();
            //player2 = null;
            //player2.TestFunc();
            Console.ReadLine();
        }
    }
}
