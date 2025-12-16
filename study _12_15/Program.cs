using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileEx
{
    enum Place
    {
        start,
        town,
        river,
        plain
    }


    class Player
    {
        int lv = 3;
        int hp = 30;
        int att = 3;

        int maxHp = 30;

        public void StatusTextPrint()
        {
            Console.WriteLine("-----------------------------------------------");
            //Console.WriteLine("플레이어의 lv : " + lv);
            //Console.WriteLine("플레이어의 Hp : " + hp + " / " + maxHp);
            //Console.WriteLine("플레이어의 att : " + att);
            Console.WriteLine($"플레이어의 lv : {lv}");
            Console.WriteLine($"플레이어의 Hp : {hp} / {maxHp}");
            Console.WriteLine($"플레이어의 att : {att}");
            Console.WriteLine("-----------------------------------------------");
        }
    }


    internal class Program
    {

        static void StartTextPrint(Player _player)
        {
            Console.Clear();
            _player.StatusTextPrint();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("어디로 가시겠습니까?");
            Console.WriteLine("1 마을");
            Console.WriteLine("2 강");
            Console.WriteLine("3 평원");
            Console.WriteLine("-----------------------------");
        }

        static Place StartPoint()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("마을로 향합니다.");
                    Console.ReadKey();
                    return Place.town;

                case ConsoleKey.D2:
                    Console.WriteLine("강으로 향합니다.");
                    Console.ReadKey();
                    return Place.start;

                case ConsoleKey.D3:
                    Console.WriteLine("평원으로 향합니다.");
                    Console.ReadKey();
                    return Place.start;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                    return Place.start;
            }
        }

        static Place Town(Player _player)
        {
            while (true)
            {
                Console.Clear();
                _player.StatusTextPrint();
                Console.WriteLine("-----------------------");
                Console.WriteLine("마을에 왔습니다. 무엇을 하시겠습니까?");
                Console.WriteLine("1 휴식");
                Console.WriteLine("2 트레이닝");
                Console.WriteLine("3 떠나기");
                Console.WriteLine("-----------------------");


                ConsoleKeyInfo keyInfo = Console.ReadKey();


                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("휴식을 했습니다.");
                        Console.ReadKey();
                        return Place.town;

                    case ConsoleKey.D2:
                        Console.WriteLine("트레이닝을 했습니다.");
                        Console.ReadKey();
                        return Place.town;

                    case ConsoleKey.D3:
                        Console.WriteLine("마을을 떠납니다.");
                        Console.ReadKey();
                        return Place.start;
                }
            }
        }

        static void Main(string[] args)
        {
            Place place = Place.start;
            Player playerA = new Player();

            while (true)
            {

                if (place == Place.start)
                {
                    StartTextPrint(playerA);
                    place = StartPoint();
                }


                switch (place)
                {
                    case Place.start:
                        break;
                    case Place.town:
                        place = Town(playerA);
                        break;
                    case Place.river:
                        break;
                    case Place.plain:
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }

            }


        }
    }
}
