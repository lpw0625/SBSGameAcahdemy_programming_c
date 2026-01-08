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


            // 1. 정수(int)형 데이터 20개를 담을 수 있는 'arrayA'라는 이름의 배열을 생성합니다.
            // 메모리에 20개의 칸이 만들어지고, 각 칸은 0번부터 19번까지의 인덱스(방 번호)를 가집니다.
            int[] arrayA = new int[20];

            // 2. 첫 번째 반복문: 배열의 각 칸에 값을 '저장'하는 과정입니다.
            // arrayA.Length는 배열의 크기인 '20'을 의미합니다. i는 0부터 19까지 증가합니다.
            for (int i = 0; i < arrayA.Length; i++)
            {
                // i번째 칸(arrayA[i])에 현재 숫자 i를 대입합니다.
                // 예: arrayA[0] = 0, arrayA[1] = 1 ... arrayA[19] = 19
                arrayA[i] = i;
            }

            // 3. 두 번째 반복문: 배열에 저장된 값을 하나씩 꺼내서 '출력'하는 과정입니다.
            for (int i = 0; i < arrayA.Length; i++)
            {
                // arrayA의 i번째 칸에 저장된 값을 읽어와 콘솔 화면에 한 줄씩 출력합니다.
                Console.WriteLine(arrayA[i]);
            }

            // 4. 출력이 끝난 후 프로그램이 바로 종료되지 않도록 사용자의 입력을 기다립니다.
            // 엔터(Enter) 키를 누르면 프로그램이 종료됩니다.
            Console.ReadLine();

        }
    }
}