using System;
using System.Dynamic;
using System.Security.Policy;


#region
//enum State
//{ 
//    none,
//    battle
//}
//public class Charactor
//{
//    protected string name;
//    public string Name { get { return name; } }
//    protected int hp;
//    public int Hp { get { return hp; } }
//    protected int att;
//    public int Att { get { return att; } }


//    public void Damaged(Charactor _attacker)
//    {
//        hp -= _attacker.Att;
//        Console.WriteLine($"name : {Name}   hp : {Hp}");
//    }

//    public bool IsAlive()
//    {
//        if (hp >= 0)
//            return true;
//        else
//            return false;
//    }
//}

//public class Player : Charactor
//{
//    public Player(string _name, int _hp, int _att)
//    {
//        name = _name;
//        hp = _hp;
//        att = _att;
//    }
//}

//public class Monster : Charactor
//{
//    public Monster(string _name, int _hp, int _att)
//    {
//        name = _name;
//        hp = _hp;
//        att = _att;
//    }
//}

#endregion

public class Program
{
    #region

    //static void ShowStatusScreen(Player _player)
    //{
    //    Console.WriteLine("=========================");
    //    Console.WriteLine("스테이스터스 창");
    //    Console.WriteLine("name : " + _player.Name);
    //    Console.WriteLine("hp : " + _player.Hp);
    //    Console.WriteLine("att : " + _player.Att);
    //    Console.WriteLine("=========================");
    //}

    //static void ShowStartScreen()
    //{
    //    Console.WriteLine("1. 몬스터와 싸운다.");
    //    Console.WriteLine("2. 대기한다.");
    //}

    //static State SelectPlayer()
    //{
    //    ShowStartScreen();

    //    ConsoleKeyInfo keyInfo = Console.ReadKey();
    //    switch (keyInfo.Key)
    //    {
    //        case ConsoleKey.D1:
    //            Console.WriteLine("몬스터와 싸웁니다.");
    //            return State.battle;
    //        case ConsoleKey.D2:
    //            Console.WriteLine("대기합니다.");
    //            return State.none;
    //        default:
    //            Console.WriteLine("잘못된 입력입니다.");
    //            return State.none;
    //    }

    //}


    //static State DamagedMonster(Monster _mob)
    //{
    //    if (_mob.IsAlive())
    //    {
    //        return State.battle;
    //    }
    //    else
    //    {
    //        Console.WriteLine("몬스터가 사망하였습니다. 시작지점으로 돌아갑니다.");
    //        return State.none;
    //    }
    //}

    //static State Battle(Player _player, Monster _mob)
    //{
    //    Console.Clear();
    //    ShowStatusScreen(_player);
    //    Console.WriteLine("1. 상단 공격.");
    //    Console.WriteLine("2. 중단 공격.");
    //    Console.WriteLine("3. 하단 공격.");
    //    ConsoleKeyInfo keyInfo = Console.ReadKey();
    //    switch (keyInfo.Key)
    //    {
    //        case ConsoleKey.D1:
    //            Console.WriteLine("상단 공격.");
    //            _mob.Damaged(_player);
    //            return DamagedMonster(_mob);
    //        case ConsoleKey.D2:
    //            Console.WriteLine("중단 공격.");
    //            _mob.Damaged(_player);
    //            return DamagedMonster(_mob);
    //        case ConsoleKey.D3:
    //            Console.WriteLine("하단 공격.");
    //            _mob.Damaged(_player);
    //            return DamagedMonster(_mob);
    //        default:
    //            Console.WriteLine("잘못된 입력입니다.");
    //            return State.battle;
    //    }
    //}

    #endregion

    public enum State // 게임의 상황을 정한다 none은 대기 battle은 배틀 
    {
        none,
        battle
    }

    public class Charactor // 모든 등장인물의 공통점입니다. (이름, 피, 공격력을 가짐) // 부모님 
    {
        public string name;
        public string Name { get { return name; } }
        public int hp;
        public int Hp { get { return hp; } }
        public int att;
        public int Att { get { return att; } }

        protected State state = State.none;
        public void SetState(State _state)
        {
            state = _state;
        }
        public State GetState()
        {
            return state;
        }
        public Charactor(string _name, int _hp, int _att)
        {
            name = _name;
            hp = _hp;
            att = _att;
        }



        public void Damaged(Charactor _attacker) // 메서드: 누군가 나를 때렸을 때 내 피(hp)를 깎는 기능을 미리 만들어둔 것입니다.
        {
            hp -= _attacker.Att;
            Console.WriteLine($"{_attacker.name} 이 {_attacker.Att} 만큼 {this.Name} 에게 데미지를 주었습니다.");
        }

        public bool IsAlive()
        {
            if (hp > 0)
                return true;
            else
                return false;
        }


    }

    public class Player : Charactor
    {
        public Player(string _name, int _hp, int _att) : base(_name, _hp, _att)
        {
        }

        int sp;
        public int Sp { get { return sp; } }

    }

    public class Monster : Charactor
    {
        public Monster(string _name, int _hp, int _att) : base(_name, _hp, _att)
        {
        }
    }

    static void ShowStatusChar(Charactor _char)
    {
        Console.WriteLine("==============================");
        Console.WriteLine("name : " + _char.Name);
        Console.WriteLine("hp : " + _char.Hp);
        Console.WriteLine("att : " + _char.Att);
        Console.WriteLine("==============================");
    }

    static void StartSelect(Charactor _player)
    {
        Console.WriteLine("여기는 시작지점입니다.");
        Console.WriteLine("1. 싸운다");
        Console.WriteLine("2. 대기한다");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        switch (keyInfo.Key)
        {
            case ConsoleKey.D1:
                Console.WriteLine("전투에 돌입합니다.");
                _player.SetState(State.battle);
                break;

            case ConsoleKey.D2:
                Console.WriteLine("대기합니다.");
                break;

            default:
                Console.WriteLine("잘못된 입력입니다.");
                break;
        }

    }

    static void BattleSection(Charactor _charA, Charactor _charB)
    {
        while (true)
        {
            Console.Clear();
            ShowStatusChar(_charA);
            ShowStatusChar(_charB);
            Console.WriteLine("1. 상단공격");
            Console.WriteLine("2. 중단공격");
            Console.WriteLine("3. 하단공격");
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("상단 공격.");
                    CheckAttack(_charA, _charB, 0);

                    if (_charB.IsAlive() == false)
                    {
                        Console.WriteLine("사망했습니다.");
                        _charA.SetState(State.none);
                        return;
                    }
                    break;

                case ConsoleKey.D2:
                    Console.WriteLine("중단 공격.");
                    CheckAttack(_charA, _charB, 1);
                    if (_charB.IsAlive() == false)
                    {
                        Console.WriteLine("사망했습니다.");
                        _charA.SetState(State.none);
                        return;
                    }
                    break;

                case ConsoleKey.D3:
                    Console.WriteLine("하단 공격.");
                    CheckAttack(_charA, _charB, 2);
                    if (_charB.IsAlive() == false)
                    {
                        Console.WriteLine("사망했습니다.");
                        _charA.SetState(State.none);
                        return;
                    }
                    break;

                default:
                    break;
            }
            Console.ReadKey();
        }
    }


// 화면 청소: Console.Clear() 로 이전 턴 내용을 지웁니다.

//정보 표시: ShowStatusChar로 현재 피가 얼마인지 보여줍니다.

//내 공격: 플레이어가 1, 2, 3 중 하나를 누릅니다. -> CheckAttack 실행.

//사망 확인: 몬스터가 죽었는지 확인하고, 죽었으면 마을(none) 로 보냅니다.

//몬스터 공격 (추가할 부분): 플레이어가 상, 중, 하 중 어디를 막을지 선택합니다. -> CheckAttack 실행.


    static void CheckAttack(Charactor _charA, Charactor _charB, int _attType)
    {
        Random rand = new Random();
        int result = rand.Next(0, 3); // 몬스터가 선택한 0(상), 1(중), 2(하)

        // _attType은 플레이어가 누른 번호입니다.
        // 결과(result)와 내가 낸 번호가 다르면? -> 공격 성공!

        string guard = "";
        if (result == 0)
            guard = "상단막기";
        else if (result == 1)
            guard = "중단막기";
        else if (result == 2)
            guard = "하단막기";

        Console.WriteLine(_charB.Name + "  " + guard);

        //공격성공
        if (result != _attType)
        {
            _charB.Damaged(_charA); // 상대방 피를 깎음

        }
        //공격실패
        else
        {
            Console.WriteLine("공격이 실패했습니다."); // 막힘
        }
    }

    static void Main()
    {
        Player player = new Player("테스터", 10, 3);

        while (true)
        {
            Console.Clear();
            ShowStatusChar(player);


            switch (player.GetState())
            {
                case State.none:
                    StartSelect(player);
                    break;

                case State.battle:
                    Monster mobA = new Monster("고보", 5, 1);
                    BattleSection(player, mobA);
                    break;

                default:
                    break;
            }

            Console.ReadKey();
        }



    }

}



//
// 아직 익숙하지 않으신분
// 익숙해졌지만 아직 만드시는 분들 - 지웠
// 완성했고 잘하시는 분들 - 개인 작업, 다이아몬드 (for 문을 통한), 배열에 받은 값들을 랜덤하게하고 다시 내림차순 오림차순 가능하게
// 계산기 만들기 - 실수 정수를 포함한.
//
// 스테이터스 창
// 화면 - 플레이어 정보
// name :
// hp : 
// att :
// 
// 입력받을수 있다.
// 1. 몬스터와 싸운다. - 몬스터와 싸웁니다.
// 2. 대기한다. - 대기합니다.
// 3. 다른경우 - 잘못된입력입니다.
// 
// 1번 무조건 화면에 띄운다.
// 2번 입력을 받아서 결과창이 나와야한다.
// 3번 반복되야한다. 
//
//
// 추가 부분
// 클래스로 만든다.

// 싸운다 선택 이후
// 공격이 가능하게 만든다.
// 몬스터가 죽을때까지.

// 플레이어는 상단, 중단, 하단을 공격할수있다

// 몬스터는 이 세 부위 상단, 중단, 하단을 랜덤하게 막고
// 막으면 공격은 무효 못막으면 데미지가 들어온다.
// 몬스터가 죽을때까지
//
//////// +
////////  
//////// 턴제 방식으로 플레이어 공격시 그다음은 몬스터가 공격한다.
//////// 플레이어는 상단, 중단, 하단의 공격을 막아야한다.
//////// 한쪽이 죽을때까지
//////// 