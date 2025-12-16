using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayEx
{
    // 이 부분 오늘 집에서 꼭 복습을 해야함.

    // 처음부터 다시 타이핑을 해서. 




    public class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            Monster MonA = new Monster(); // Monster 클래스의 새로운 **객체(인스턴스)**인 MonA를 생성합니다.
            Player playerA = new Player(); // Player 클래스의 새로운 **객체(인스턴스)**인 playerA를 생성합니다.

            playerA.Dance();
            Console.ReadLine();

            UnitParent AAA = MonA;
            playerA.Dameged(MonA); // playerA 객체의 Dameged 메서드를 호출합니다. 이때, MonA 객체를 인수로 전달합니다  (몬스터가 플레이어를 공격하거나, 몬스터의 속성을 이용해 플레이어가 피해를 입는 로직을 가정)
            MonA.Dameged(playerA); // MonA 객체의 Dameged 메서드를 호출합니다. 이때, playerA 객체를 인수로 전달합니다 (플레이어가 몬스터를 공격하는 로직을 가정할 수 있습니다.)


            Console.WriteLine();
            Console.ReadKey();


            int[] arrayA = new int[20];
            for (int i = 0; i < arrayA.Length; i++)
            {
                arrayA[i] = i;
            }
            for (int i = 0; i < arrayA.Length; i++)
            {
                Console.WriteLine(arrayA[i]);
            }


            Console.ReadLine();

        }
    }
}