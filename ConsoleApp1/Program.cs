using ConsoleApp1;
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
namespace ConsoleApp1
{

    enum State
    {
        none,
        Battle
    }


    public class Charactor
    {
        protected string name;

        public string Name { get { return name; } }
        protected int hp;

        public int HP { get { return hp; } }
        protected int att;

        public int Att { get { return att; } }
    }


    public class Player : Charactor
    {
        public Player(strint _name, int _hp, int _att)
        {
            name = _name;
            hp = _hp;
            att = _att; 
        }
    }
    internal class Program
    {

        static void ShowStatusScreen(Player player)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("스테이터스 창");
            Console.WriteLine("name : " + player.Name ;
            Console.WriteLine("hp : " + player.HP;
            Console.WriteLine("att : " + player.Att);

            Console.WriteLine("----------------------------");
        }

            while (true)
            {
                Console.WriteLine("\n1. 몬스터와 싸운다");
                Console.WriteLine("2. 대기한다");

                // ReadKey(true)를 사용하면 입력한 키가 화면에 보이지 않아 깔끔합니다.
                ConsoleKeyInfo keyinfo = Console.ReadKey(true);

                // switch문 뒤에는 반드시 { 가 있어야 합니다.
                switch (keyinfo.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("-> [결과] 몬스터와 싸웁니다!");
                        return State.Battle;

                    case ConsoleKey.D2:
                        Console.WriteLine("-> [결과] 대기합니다.");
                        return State.none;


                    default:
                        Console.WriteLine("-> [에러] 잘못된 입력입니다. 숫자 1 또는 2를 누르세요.");
                        return State.none;
                }
            }
        }

        static void Main(string[] args)
    {
        Player player = new Player("테스트 플레이어", 10, 3);
        Player monA = new Player("몬스터", 10, 2);

        State state = State.none;

        ShowStatusScreen(player);

        // 초기 스테이터스 출력
    }
}


