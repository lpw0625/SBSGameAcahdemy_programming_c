using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette
{
    
    public class Program
    {

     




        static void Main(string[] args)
        {

            Revolver revolver = new Revolver(10);

            revolver.AddBullet(0, BulletType.normal);
            revolver.AddBullet(3, BulletType.Critical);

            Bullet result = revolver.cylinder.PullTrigger();

            List<Player> player = new List<Player>();
            player.Add(new Player("플레이어A", 3));
            player.Add(new Player("플레이어A", 3));
            player.Add(new Player("플레이어A", 3));
            player.Add(new Player("플레이어A", 3));
            player.Add(new Player("플레이어A", 3));
            player.Add(new Player("플레이어A", 3));
            if (result != null)
                Console.WriteLine($"{result.Type} 발사 ! {result.Damage}");

            else
                Console.WriteLine("틱! 빈 총소리만 들린다....");


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