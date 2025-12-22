using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

// 스테이터스 창 
// 화면 - 플레이어 정보 
// name :
// hp : 
// att : 


// 입력받을 수 있다.
// 1. 몬스터와 싸운다. - 몬스터와 싸운다.
// 2. 대기한다 - 대기합니다.
// 3. 다른경우 - 잘못된 입력입니다.

// 1번 무조건 화면에 띄운다.
// 2번 입력을 받아서 결과창이 나와야한다.
// 3번 반복되어야한다.


// 추가 부분 
// 클래스로 만든다
// 싸운다 선택 이후 플레이어는 상단, 중단, 하단을 공격할 수 있다.
// 몬스터는 이 세 부위 상단 중단 하단을 랜덤하게 막고
// 막으면 공격은 무효 못막으면 데미지가 들어온다.
// 몬스터가 죽을때까지.
namespace TestProjectEx
{

    class UnitParent
    {

        protected string name = "";
        protected int hp = 50;
        protected int att = 5;


        public UnitParent(string _name, int _hp, int _att)
        {
            name = _name;
            hp = _hp;
            att = _att;

        }
    }

    class Player : UnitParent
    {

        public Player(string _name, int _hp, int _att) : base(_name, _hp, _att)
        {

        }


        public void StatusTextPrint()
        {
            Console.WriteLine("============================");
            Console.WriteLine($"플레이어의 이름 : {name}");
            Console.WriteLine($"플레이어의 Hp : {hp}");
            Console.WriteLine($"플레이어의 공격력 : {att}");


        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            Player playerA = new Player("플레이어", 50, 5);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("몬스터와 싸운다");
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine("대기한다");
                        break;

                    default:
                        Console.WriteLine("잘못된 입력");
                        break;


                }


            }

        }


        //{

        //    console.writeline("스테이터스 창");
        //    console.writeline("name : " + "플레이어");
        //    console.writeline("hp : " + 30);
        //    console.writeline("att : " + 10);

        //    console.writeline("1, 몬스터와 싸운다");
        //    console.writeline("2. 대기한다");
        //    console.readline();

        //    while (true)
        //    {
        //         consolekeyinfo keyinfo = console.readkey();
        //      switch (keyinfo.key)


        //                        case consolekey.d1:
        //            console.writeline("몬스터와 싸웁니다");
        //                       break;

        //        case consolekey.d2:
        //            console.writeline("대기합니다");
        //            break;
        //        default:
        //            console.writeline("잘못된 입력입니다.");
        //            break;
        //        }

        //    }



    }
}
}
