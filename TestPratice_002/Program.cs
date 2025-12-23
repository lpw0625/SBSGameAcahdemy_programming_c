using System.ComponentModel.Design;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TestPratice_002
{
    internal class Program
    {
        // [열거형] 플레이어의 현재 상황을 정의 (평상시 / 전투중)
        public enum State
        {
            none,
            battle
        }

        // [부모 클래스] 모든 생명체(플레이어, 몬스터)의 공통 속성 정의
        public class Unit
        {
            // 속성 데이터 (이름, 체력, 공격력)
            protected string name;
            public string Name { get { return name; } }

            protected int hp;
            public int HP { get { return hp; } }

            protected int atk;
            public int Atk { get { return atk; } }

            // 추가 기능: 공격 통계 데이터 (시도 횟수, 성공 횟수)
            protected int totalAttackCount;
            public int TotalAttackCount { get { return totalAttackCount; } }

            protected int hitCount;
            public int HitCount { get { return hitCount; } }

            // 공격 결과를 기록하는 메서드
            public void AddAttackResult(bool isSuccess)
            {
                totalAttackCount++; // 시도 횟수 증가
                if (isSuccess) hitCount++; // 성공 시 성공 횟수 증가
            }

            // 캐릭터 상태 관리
            protected State state = State.none;
            public void SetState(State _state) { state = _state; }
            public State GetState() { return state; }

            // 생성자: 캐릭터가 생성될 때 초기값 설정
            public Unit(string _name, int _hp, int _atk)
            {
                name = _name;
                hp = _hp;
                atk = _atk;
            }

            // 데미지 처리 메서드: 상대방의 공격력만큼 HP 차감
            public void Damaged(Unit _attacker)
            {
                hp -= _attacker.Atk;
                Console.WriteLine($"{_attacker.Name} 이 {_attacker.Atk} 만큼 {this.Name}에게 피해를 입힘");
            }

            // 생존 확인 메서드: HP가 0보다 크면 살아있음
            public bool IsAlive()
            {
                if (hp <= 0) return false;
                else return true;
            }
        }

        // [상속] 부모인 Unit의 기능을 그대로 물려받은 플레이어 클래스
        public class Player : Unit
        {
            public Player(string _name, int _hp, int _atk) : base(_name, _hp, _atk) { }
        }

        // [상속] 부모인 Unit의 기능을 그대로 물려받은 몬스터(오크) 클래스
        public class Orc : Unit
        {
            public Orc(string _name, int _hp, int _atk) : base(_name, _hp, _atk) { }
        }

        // [UI] 플레이어의 현재 정보를 화면에 출력
        static void ShowStatus(Unit _unit)
        {
            Console.WriteLine("★====================================★");
            Console.WriteLine("[플레이어 정보]");
            Console.WriteLine("플레이어 이름 : " + _unit.Name);
            Console.WriteLine("플레이어 Hp : " + _unit.HP);
            Console.WriteLine("플레이어 공격력 : " + _unit.Atk);
            Console.WriteLine("★====================================★");

            // 통계 정보 출력
            Console.WriteLine($"공격 성공/시도 : {_unit.HitCount} / {_unit.TotalAttackCount}");
            Console.WriteLine();
        }

        // [UI] 몬스터의 현재 정보를 화면에 출력
        static void MonsterStatus(Unit _unit)
        {
            Console.WriteLine("★====================================★");
            Console.WriteLine("[몬스터 정보]");
            Console.WriteLine("몬스터 이름 : " + _unit.Name);
            Console.WriteLine("몬스터 Hp : " + _unit.HP);
            Console.WriteLine("몬스터 공격력 : " + _unit.Atk);
            Console.WriteLine("★====================================★");
        }

        // [로직] 메인 메뉴에서 플레이어의 행동(공격 시작 여부)을 선택
        static void SituationSelect(Unit _player)
        {
            Console.WriteLine("★ 플레이어 행동.★");
            Console.WriteLine("1.공격한다 (전투 시작)");
            Console.WriteLine("2.대기한다");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("\n★ 전투를 시작합니다! ★");
                    _player.SetState(State.battle); // 상태를 전투중으로 변경
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("\n대기 중...");
                    break;
                default:
                    Console.WriteLine("\n잘못된 입력");
                    break;
            }
        }

        // [전투 엔진] 전투 화면을 유지하고 플레이어의 입력을 처리
        static void BattleSituation(Unit _unitA, Unit _unitB)
        {
            while (true) // 몬스터가 죽을 때까지 반복
            {
                Console.Clear();
                ShowStatus(_unitA);
                MonsterStatus(_unitB);
                Console.WriteLine("어디를 공격하시겠습니까?");
                Console.WriteLine("1. 상단공격 / 2. 중단공격 / 3. 하단공격");
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                // 입력된 키에 따라 공격 타입 설정 (1->0, 2->1, 3->2)
                int atkType = -1;
                if (keyInfo.Key == ConsoleKey.D1) atkType = 0;
                else if (keyInfo.Key == ConsoleKey.D2) atkType = 1;
                else if (keyInfo.Key == ConsoleKey.D3) atkType = 2;

                if (atkType != -1)
                {
                    Console.WriteLine();
                    CheckAttack(_unitA, _unitB, atkType); // 공격 판정 실행
                }

                // 몬스터 사망 체크: 죽었다면 전투 종료 및 상태 환원
                if (_unitB.IsAlive() == false)
                {
                    Console.WriteLine("\n" + _unitB.Name + "가 사망했습니다!");
                    _unitA.SetState(State.none);
                    return; // 루프 종료 및 메인으로 복귀
                }
                Console.WriteLine("\n계속하려면 아무 키나 누르세요...");
                Console.ReadKey();
            }
        }

        // [핵심 로직] 공격 성공과 실패를 판정 (랜덤 가위바위보 방식)
        static void CheckAttack(Unit _unitA, Unit _unitB, int _atkType)
        {
            Random atkRand = new Random();
            int result = atkRand.Next(0, 3); // 몬스터의 방어 방향 결정

            string guard = (result == 0) ? "상단막기" : (result == 1) ? "중단막기" : "하단막기";
            Console.WriteLine(_unitB.Name + "의 대응: " + guard);

            // 판정: 플레이어 공격 방향과 몬스터 방어 방향이 다르면 명중
            if (result != _atkType)
            {
                _unitB.Damaged(_unitA); // 데미지 입힘
                _unitA.AddAttackResult(true); // 성공 기록
            }
            else
            {
                Console.WriteLine("공격이 막혔습니다!");
                _unitA.AddAttackResult(false); // 실패 기록
            }
        }

        // [진입점] 게임의 전체적인 흐름 제어
        static void Main(string[] args)
        {
            // 1. 플레이어 데이터 초기 생성
            Player player = new Player("히어로", 50, 10);

            // 2. 게임 무한 루프
            while (true)
            {
                Console.Clear();
                ShowStatus(player);

                // 현재 상태(평시/전투)에 따라 다른 함수 실행
                switch (player.GetState())
                {
                    case State.none:
                        SituationSelect(player); // 마을 행동 선택
                        break;

                    case State.battle:
                        Orc orc = new Orc("오크", 30, 5); // 전투 진입 시 새 오크 생성
                        BattleSituation(player, orc);     // 전투 진행
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}