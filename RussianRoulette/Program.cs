using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette
{

    public class Program
    {

        private static int GetNumber(string Message)
        {
            Console.Write(Message);
            return int.Parse(Console.ReadLine());
        }


        public static List<Player> ShowScreen(Revolver _revolver)
        {
            Console.WriteLine("========= 러시아 룰렛 설정 =========");

            int CylinderSize = GetNumber("▶ 전체 약실 크기: ");
            _revolver.cylinder.SetSize(CylinderSize); // 약실 크기 재설정

            int BulletCount = GetNumber("▶ 실탄 개수: ");
            int PlayerCount = GetNumber("▶ 참여 인원수: ");
            _revolver.FirstSelectSetUp(BulletCount);


            List<Player> PlayerList = new List<Player>();
            for (int i = 0; i < PlayerCount; i++)
            {
                Console.Write($"▶ {i + 1}번 플레이어 이름:");
                string Name = Console.ReadLine();
                PlayerList.Add(new Player(Name, 3));
            }

            return PlayerList;
        }

        public static void ShowScreenWinner(string Winner)

        {
            Console.Clear();
            Console.WriteLine("************************************");
            Console.WriteLine("          G A M E  O V E R          ");
            Console.WriteLine("************************************");
            Console.WriteLine($"      축하합니다! 승리자: {Winner}");
            Console.WriteLine("************************************");
        }


        static void Main(string[] args)
        {

            Revolver revolver = new Revolver(6);


            List<Player> player = ShowScreen(revolver);

            int currentIndex = 0;

            int aliveCount = player.Count;
            while (aliveCount > 1)
            {
                if (!revolver.cylinder.HasBullet())

                    revolver.Reload();


                Player currentPlayer = player[currentIndex];


                // 만약 플레이어가 방금 턴에 사망했다면 리스트에서 제거
                if (!currentPlayer.IsAlive)
                {
                    currentIndex = (currentIndex + 1) % player.Count;
                    continue;
                }

                bool isTurnEnded = currentPlayer.Playturn(revolver);


                // 턴이 끝났을 때 살아있는 단 한 명을 찾아 승리 화면 표시
                int tempCount = 0;

                for (int i = 0; i < player.Count; i++)

                {

                    if (player[i].IsAlive) tempCount++;
                }
                aliveCount = tempCount;

                // 루프가 끝났을 때 살아있는 단 한 명을 찾아 승리 화면 표시
                if (isTurnEnded || !currentPlayer.IsAlive)
                {

                    currentIndex = (currentIndex + 1) % player.Count;
                }
            }

            for (int i = 0; i < player.Count; i++)
            {
                if (player[i].IsAlive)
                {
                    ShowScreenWinner(player[i].PlayerName);
                    break;

                }
            }
            Console.WriteLine("\n 엔터를 누르면 종료합니다.");
            Console.ReadLine();
        }
    }
}
    













/*
 * 러시아 룰렛
- 6개의 약실 중에 1개만 총알이 들어가있다.
- 총알 당겨서 죽고 안죽고 되게

    
1. 약실을 플레이어가 초기에 늘릴 수 있다.
- 약실 - 6 그냥 이런식으로 적용 X
- 변수를 통행서 약실 갯수를 변형이 가능해야한다.

    
2. 총알을 여러개 넣는게 가능하게
- 원래 정석은 6개의 약실에 총알 한발
- 20개의 약실에 총알 여러 발

    
3. 혼자서, 1:1, 여러명 가능하게
- 여러명일 경우 - Ex) 5명
- 총알이 발사됬을때 그때 한명이 die
- 약실에 총알을 다시 넣고
- 5명 -> 4명
- 최후 생존자가 나올때까지 or 내가 죽을 때 까지

    
4. 러시아 룰렛인데
- 플레이어만이 가질수 있는 라이프
- 아이템 - 총알이 있는지 없는지 확인하기 => 클래스를 만들어서 사용을 할것 => 이 아이템을 관리하기 위한 부모인 Inventroy 클래스도 있어야함.
- 특정 ai는 라이프가 더 있다. 얘도 아이템을 쓴다.

    
5. 내가 스스로 방아쇠를 당긴다음
- 한번 더 당길지
- 그냥 턴을 넘길지
*/