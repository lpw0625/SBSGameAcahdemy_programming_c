using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Test
{



    internal class Program
    {

        public enum State
        {
            none,
            battle

        }

        public class UnitParent
        {
            protected string name;
            public string Name { get { return name; } }

            protected int hp;
            public int Hp { get { return hp; } }

            protected int atk;
            public int Atk { get { return atk; } }


            protected int totalAttackCount;

            public int TotalAttackCount { get { return totalAttackCount; } }

            protected int hitCount;

            public int HitCount { get { return hitCount;} }


            public void AddAttackResult(bool isSuccess)
            {
               totalAttackCount++;

                if (isSuccess)
                {
                    hitCount++;

                }
            }

            protected State state = State.none;


            public void SetState(State _state)
            {
                state = _state;
            }                                                                                        



            public State GetState()

            {
                return state;
            }

            public UnitParent(string _name, int _hp, int _atk)
            {
                name = _name;
                hp = _hp;
                atk = _atk;
            }



            public void Damaged(UnitParent _attacker)
            {
                hp -= _attacker.Atk;
                Console.WriteLine($"★ {_attacker.Name} 이 {_attacker.Atk} 만큼 {this.Name}에게 피해를 입혔습니다~!★");
            }

            public bool IsAlive()
            {
                if (hp <= 0)
                    return false;
                else
                    return true;
            }
        }



        public class Player : UnitParent
        {
            public Player(string _name, int _hp, int _atk) : base(_name, _hp, _atk) { }


             
        }


        public class Orc : UnitParent
        {

            public Orc(string _name, int _hp, int _atk) : base(_name, _hp, _atk) { }


        }







        static void showstatusplayer(UnitParent _unitParent)
        {
            Console.WriteLine("★============================★");
            Console.WriteLine("플레이어 정보");
            Console.WriteLine("플레이어 이름 : " + _unitParent.Name);
            Console.WriteLine("플레이어 체력 : " + _unitParent.Hp);
            Console.WriteLine("플레이어 공격력 : " + _unitParent.Atk);
            Console.WriteLine("★============================★");

            Console.WriteLine($" 공격 성공 / 시도 : {_unitParent.HitCount} / {_unitParent.TotalAttackCount}");
            Console.WriteLine();
        }



        static void showstatusMonster(UnitParent _unitParent)
        {
            Console.WriteLine("★============================★");
            Console.WriteLine("몬스터 정보");
            Console.WriteLine("몬스터 이름 : " + _unitParent.Name);
            Console.WriteLine("몬스터 체력 : " + _unitParent.Hp);
            Console.WriteLine("몬스터 공격력 : " + _unitParent.Atk);
            Console.WriteLine("★============================★");

          
        }


        static void ActionSimurator(Player _player)
        {
            Console.WriteLine("★============================★");
            Console.WriteLine("★ 플레이어 행동을 선택하세요 ★");
            Console.WriteLine("1. ★결투를 신청한다★");
            Console.WriteLine("2. 대기한다");

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {

                case
                ConsoleKey.D1:
                    Console.WriteLine("★전투에 들어섭니다-!★");
                    _player.SetState(State.battle);
                    break;

                case
                ConsoleKey.D2:
                    Console.WriteLine("★대기 합니다...★");

                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 선택하세요");
                    break;




            }


        }

        static void BattelSimulation(UnitParent _playerA, UnitParent _orcB)
        {

            while (true)
            {

                Console.Clear();
                showstatusplayer(_playerA);
                showstatusMonster(_orcB);
                Console.WriteLine("※ 어디를 공격하시겠습니까? ※");
                Console.WriteLine("※ 1. 머리(상단 공격) / 2. 가슴(중간 공격) / 3. 하체(하단 공격)");
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                int atkType = -1;
                if (keyInfo.Key == ConsoleKey.D1) atkType = 0;

                else if (keyInfo.Key == ConsoleKey.D2) atkType = 1;

                else if (keyInfo.Key == ConsoleKey.D2) atkType = 2;

                if (atkType != -1)

                {
                    Console.WriteLine();
                    CheckingAttack(_playerA, _orcB, atkType);
                }


                if (_orcB.IsAlive() == false)
                {
                    Console.WriteLine("\n" + _orcB.Name + "가 쓰러졌습니다~!★");
                    _playerA.SetState(State.none);
                    return;
                }

                Console.WriteLine("\n 계속하려면 아무 키를 입력하세요......");
                Console.ReadKey();
            }


        }


        static void CheckingAttack(UnitParent _playerA, UnitParent __orcB, int _aktType)
        {
            Random atkRand = new Random();
            int result = atkRand.Next(0, 3);

            string guard = (result == 0) ? "상단 공격이 막혔습니다~?!★" : (result == 1) ? "중단 공격이 막혔습니다~?!★" : "하단 공격이 막혔습니다~?!★";
            Console.WriteLine(__orcB.Name + "의 방어: " + guard);

            if (result != _aktType)
            {
                __orcB.Damaged(_playerA);
                _playerA.AddAttackResult(true);

            }
            else
            {
                Console.WriteLine("공격이 막혔습니다~!");
                _playerA.AddAttackResult(false);
            }
        }
        
        static void Main(string[] args)
        {
            Player player = new Player("플레이어1", 50, 10);




            while (true)
            {
                Console.Clear();
                showstatusplayer(player);
                Orc orc = new Orc("오크", 30, 5);

                switch (player.GetState())
                {
                    case State.none:
                        ActionSimurator(player);
                        break;

                    case State.battle:
                        
                        BattelSimulation(player, orc);
                        break;

                }
                Console.ReadKey();
            }
        }
    }
}
  
                            



                            

    
    
    


