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

     public bool Playturn(Revolver _revolver)
        {
            Console.WriteLine($"\n ==== [{PlayerName}]의 차례입니다. (남은 라이프 : {PlayerLife}) === ");
            Console.WriteLine("1 방아쇠를 당긴다. 2. 턴을 넘긴다.");
            Console.Write("행동 선택:");

            string input = Console.ReadLine();

            if (input == "1")
            {
                Bullet firedBullet = _revolver.cylinder.PullTrigger();

                if (firedBullet != null ) 
                {
                    PlayerLife -= firedBullet.Damage;
                    Console.WriteLine($" >>>> [탕!] {firedBullet.Type} 발사! {firedBullet.Damage});

                }
            }
        }
       
    }
}
