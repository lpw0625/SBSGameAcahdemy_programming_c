using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace WhileEx
{
    enum Place
    {
        start,
        town,
        river,
        plain,
        fight
    }




    class UnitParent
    {
        public static int dieHp = 0;

        protected string name = "";
        protected int lv = 3;
        protected int hp = 30;
        protected int att = 3;

        protected int maxHp = 30;


        public UnitParent(string _name, int _lv, int _hp, int _att, int _maxHp)
        {
            if (_maxHp < _hp)
                _hp = _maxHp;

            name = _name;
            lv = _lv;
            hp = _hp;
            att = _att;
            maxHp = _maxHp;
        }



        //같은 이름 가지고 있는 매서드가 안에 매개변수가 다를경우 사용이가능하다.
        public void Damaged(UnitParent _player)
        {
            hp -= _player.att;

            Console.WriteLine($"{_player.name} 가 공격했습니다.");
            Console.WriteLine($"{name} 의 체력 : {hp} / {maxHp}");

        }
        public void SetName(string str)
        {
            name = str;
        }
        public string GetName()
        {
            return name;
        }

        public int GetAtt()
        {
            return att;
        }

        public int GetHp()
        {
            return hp;
        }


        public bool IsLife()
        {
            if (0 < hp)
                return true;
            else
                return false;
        }

    }

    class Monster : UnitParent
    {
        public Monster(string _name, int _lv, int _hp, int _att, int _maxHp) : base(_name, _lv, _hp, _att, _maxHp)
        {
        }

    }

    class Player : UnitParent
    {
        public static Place preStaticPlace;
        public Player(string _name, int _lv, int _hp, int _att, int _maxHp) : base(_name, _lv, _hp, _att, _maxHp)
        {
        }

        public void StatusTextPrint()
        {
            Console.WriteLine("-----------------------------------------------");
            //Console.WriteLine("플레이어의 lv : " + lv);
            //Console.WriteLine("플레이어의 Hp : " + hp + " / " + maxHp);
            //Console.WriteLine("플레이어의 att : " + att);
            Console.WriteLine($"플레이어의 Lv : {lv}");
            Console.WriteLine($"플레이어의 Hp : {hp} / {maxHp}");
            Console.WriteLine($"플레이어의 Att : {att}");
            Console.WriteLine("-----------------------------------------------");
        }

        public void FightPrePlace()
        {

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
                    return Place.river;

                case ConsoleKey.D3:
                    Console.WriteLine("평원으로 향합니다.");
                    Console.ReadKey();
                    return Place.plain;

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


                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        return Place.town;
                }
            }
        }

        static Place River(Player _player)
        {
            while (true)
            {
                Console.Clear();
                _player.StatusTextPrint();
                Console.WriteLine("-----------------------");
                Console.WriteLine("강에 도착했습니다. 무엇을 하시겠습니까?");
                Console.WriteLine("1 구경");
                Console.WriteLine("2 낚시");
                Console.WriteLine("3 떠나기");
                Console.WriteLine("-----------------------");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("강을 구경 했습니다.");
                        Console.ReadKey();
                        return Place.river;

                    case ConsoleKey.D2:
                        Console.WriteLine("낚시를 했습니다.");
                        Console.ReadKey();
                        return Place.river;

                    case ConsoleKey.D3:
                        Console.WriteLine("강을 떠납니다.");
                        Console.ReadKey();
                        return Place.start;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        return Place.river;
                }
            }

        }

        static Place Plain(Player _player)
        {
            while (true)
            {
                Console.Clear();
                _player.StatusTextPrint();
                Console.WriteLine("-----------------------");
                Console.WriteLine("평원에 도착했습니다.");
                Console.WriteLine("1 싸운다. - 파이트로 이동");
                Console.WriteLine("2 평원에 서있는다.");
                Console.WriteLine("3 떠나기.");
                Console.WriteLine("-----------------------");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("파이트 필드에서 싸운다.");
                        Console.ReadKey();
                        Player.preStaticPlace = Place.plain;
                        return Place.fight;

                    case ConsoleKey.D2:
                        Console.WriteLine("그냥 서있습니다.");
                        Console.ReadKey();
                        return Place.plain;

                    case ConsoleKey.D3:
                        Console.WriteLine("평원을 떠납니다.");
                        Console.ReadKey();
                        return Place.start;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        return Place.plain;
                }
            }

        }

        static Place Fight(Player _player, Place _place)
        {
            Monster _mobA = new Monster("허수아비", 3, 30, 2, 30);
            Place prePlace = _place;
            while (true)
            {
                Console.Clear();
                _player.StatusTextPrint();
                Console.WriteLine("-----------------------");
                Console.WriteLine($"{_mobA.GetName()}의 싸움.");
                Console.WriteLine("1 때린다.");
                Console.WriteLine("2 떠난다.");
                Console.WriteLine("-----------------------");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        // 허수아비가 죽었을 때.
                        // 파이트 함수가 끝나야한다.
                        _mobA.Damaged(_player);
                        _player.Damaged(_mobA);
                        Console.ReadKey();
                        if (_mobA.IsLife() == false)
                        {
                            Console.WriteLine("전투가 끝났습니다.");
                            return Player.preStaticPlace;
                        }
                        else if (_player.IsLife() == false)
                        {
                            Console.WriteLine($"플레이어 {_player.GetName()} 죽었습니다");
                            return Player.preStaticPlace;
                        }
                        break;

                    case ConsoleKey.D2:

                        return Place.start;

                    default:

                        break;
                }


            }
        }


        static void Main(string[] args)
        {
            Place place = Place.start;
            Player playerA = new Player("전사", 5, 50, 5, 40);



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
                        place = River(playerA);
                        break;
                    case Place.plain:
                        place = Plain(playerA);
                        break;
                    case Place.fight:
                        place = Fight(playerA, place);
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }

            }


        }
    }
}
