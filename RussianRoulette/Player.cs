using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette
{
    public class Player
    {

        public string PlayerName
        { 
            get; private set; 
        
        }

        public int PlayerLife
        {
            get; private set;
        }

       public bool IsAlive
        {
            get
            {
                return PlayerLife > 0;
            }
            
        }

        public Player(string m_playerName, int m_playerLife)
        {
            PlayerName = m_playerName;
            PlayerLife = m_playerLife;
        }

        // 플레이어의 한 턴을 처리하는 메서드
        // 반환값 (bool) : 턴이 완전히 끝났는지 여부 
     public bool Playturn(Revolver _revolver)
        {
            Console.WriteLine($"\n ==== [{PlayerName}]의 차례입니다. (남은 라이프 : {PlayerLife}) === ");
            Console.WriteLine("1 방아쇠를 당긴다. 2. 턴을 넘긴다.");
            Console.Write("행동 선택:");

            string input = Console.ReadLine();

            if (input == "1")
            {
                Bullet firedBullet = _revolver.cylinder.PullTrigger();


                // 총알이 들어가있을때 격발. 
                if (firedBullet != null)
                {
                    PlayerLife -= firedBullet.Damage;
                    Console.WriteLine($" >>>> [탕!] {firedBullet.Type} 발사! {firedBullet.Damage} 데미지를 입었습니다.");

                    if (!IsAlive)
                    {

                        Console.WriteLine($"{PlayerName}님이 사망하셨습니다... 애도를 표합니다....");
                        return true;

                    }

                    Console.WriteLine("치명상을 입었지만 아직 살아있습니다!");
                }

                // 빈 약실일때. 
                else
                {
                    Console.WriteLine(">>>> [틱!] 빈 총소리입니다. 생존하셨습니다. 지금은....");
                }

                    // 방아쇠를 당긴 후 한 번 더 당길지 물어보는 로직을 위해 false 반환
                    // (기획에 따라 바로 턴을 넘길수도, 추가 기회를 줄 수도 있습니다)

                    Console.WriteLine("다시 한 번 기회가 있습니다.... ");
                    return false;

                }
                else
                {
                    Console.WriteLine($"{PlayerName}님이 안전하게 다음 사람에게 총을 넘깁니다.");
                    return true;
                }
        }
    }
       
 }

