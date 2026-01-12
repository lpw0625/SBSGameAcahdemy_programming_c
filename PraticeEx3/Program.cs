using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PraticeEx3
{
    public class Program
    {
       
        public class ArrayNumber
        {
           /* private int[] m_ArrayInt = new int[5];*/ // 배열[]을 쓸때
            private List<int> m_ArrayInt = new List<int>(); // List를 쓸때.

            //public int[] Numbers
            public List<int> Numbers
            {
                get { return m_ArrayInt; }
            }

            public bool IsRunning { set; get; } = true;

        }

        // private로 데이터를 보호를 하면서 사용을 할때는 프로퍼티를 사용을 해보자
        // 배열 변수인  m_ArrayInt 숨기고 외부에서 접근을 할 수 있는 Numbers 라는 프로파티를 작성을 하는 것이다.
        // 프로파티는 변수이면서도 매서드의 존재를 대처 할 수 있는 통로 같은 존재

            static void InputNumber(ArrayNumber _arrayNumber)
            {

            _arrayNumber.Numbers.Clear();
            // List를 새로 입력받기 위해 기존 데이터를 바꾼다.

            Console.WriteLine("\n 숫자 5개를 입력을 해보세요");
            //for (int i = 0; i < _arrayNumber.Numbers.Length; i++)
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i + 1}번 숫자: ");
                //_arrayNumber.Numbers[i] = int.Parse(Console.ReadLine());
                int input = int.Parse( Console.ReadLine());   
                _arrayNumber.Numbers.Add(input);

                //  포인트 1: _arrayNumber 뒤에 '.m_ArrayInt'를 찍어 배열에 접근합니다.
                //  포인트 2: 배열 뒤에 '.Length'를 붙여서 '5번 반복해라'라고 명시합니다.

                // 문자열(string)을 숫자(Integer)로 변환하는 통역사
                // 우리가 입력을 할때 숫자를 입력해도 컴퓨터에서는 문자열로 인식이 된다. 숫자로 번역을 해줘야 하기 때문.
                // 지금 만든 m_ArrayInt는 int 정수만 들어갈 수 있는 즉, 숫자만 들어갈 수 있는 그릇이기 때문에 사용을 하는것.
            }
        }




        static void ProcessMenu(ArrayNumber _arrayNumber)
        {
            Console.WriteLine("[메뉴얼]");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {

                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:

                    InputNumber(_arrayNumber);
                    break;

                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:

                    PresetNumber(_arrayNumber);
                    break;

                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:

                    RandomInputNumber(_arrayNumber);
                    Console.WriteLine("\n [랜덤 생성 완료!] 엔터를 누르세요.");
                    Console.ReadLine();
                    break;

                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:

                    AnalyzeNumbers(_arrayNumber);
                    break;

                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:

                    ReverseArray(_arrayNumber);
                    Console.WriteLine("\n [배열 뒤집기 완료!] 엔터를 누르세요.");
                    Console.ReadLine();
                    break;

                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:

                    _arrayNumber.IsRunning = false;
                    break;

                default:
                    Console.WriteLine("[잘못된 입력입니다!] 엔터를 누르세요!");
                    Console.ReadLine();
                    break;

            }
        

        }


        static void PresetNumber(ArrayNumber _arrayNumber)
        {
            _arrayNumber.Numbers.Clear();

            int[] data = { 10, 20, 30, 40, 50 };

            for (int i = 0; i < data.Length;i++)
            {
                _arrayNumber.Numbers.Add(data[i]);
            }

            Console.WriteLine("\n 입력한 숫자에 대한 데이터 로드가 완료했습니다! (엔터를 누르세요)");
            Console.ReadLine();
            // 미리 준비한 숫자를 data라는 변수의 이름의 그릇에 담는다는 의미이다.
            // 작동 원리 : 5개의 칸이 생기며 10,20,30,40,50의 숫자가 저장.

            // 그럼 이렇게 하는 이유?
            // int[] m_ArrayInt = new int[5]; 에서 숫자를 5개가 들어가 있는 공간을 만들었다.
            // { 10, 20, 30, 40, 50 }; 안에 있는 거는 들어갈 데이터의 내용
            // 컴퓨터가 크기가 5개인 배열이라는 것을 인식한다.

            // 내가 이해하는 생각 :  배열의 크기(공간)를 알려주는 역할

            // { 10, 20, 30, 40, 50 } 안에 숫자가 5개 들어있는 것을 보고 컴퓨터는 "아! 5칸짜리 배열을 만들라는 뜻이구나!"라고 공간의 크기를 인식

            // gemini답 : 초기값(실제 데이터)을 채워넣는 역할

            // 괄호 안의 숫자들은 단순히 공간을 확보하는 것에서 끝나지 않고, 그 공간에 실제로 10, 20... 이라는 데이터를 즉시 채워넣는 역할

        }


        static void AnalyzeNumbers(ArrayNumber _arrayNumber)
        {
            int ArraySum = 0;
            int ArrayMax = _arrayNumber.Numbers[0];
            int ArrayMin = _arrayNumber.Numbers[0];
            Console.WriteLine("\n[짝수 목록] ");

            for (int i = 0; i < _arrayNumber.Numbers.Count; i++)
            //for (int i = 0; i < _arrayNumber.Numbers.Length; i++)

            {
                int CurrentNumber = _arrayNumber.Numbers[i];


                // 합계 구하기
                ArraySum += CurrentNumber; 


                // 최대 값 구하기
                if (CurrentNumber > ArrayMax ) 
                    
                        ArrayMax = CurrentNumber;

                // 최소 값 구하기
                if (CurrentNumber < ArrayMin )

                        ArrayMin = CurrentNumber;

                // 짝수 판별 (2를 나눈 나머지가 0인지 확인한다.)
                if (CurrentNumber % 2 == 0)
                {
                    Console.WriteLine($"{CurrentNumber}");
                }
            }

            //double ArrayAvg = (double)ArraySum / _arrayNumber.Numbers.Length;
            double ArrayAvg = (double)ArraySum / _arrayNumber.Numbers.Count;

            Console.WriteLine($"\n 합계 : {ArraySum}");
            Console.WriteLine($" 평균 : {ArrayAvg}");
            Console.WriteLine($" 최대 : {ArrayMax} / 최소 : {ArrayMin}");
            Console.WriteLine("\n 확인 후 엔터를 누르세요.");
            Console.ReadLine();
        }

        static void ReverseArray(ArrayNumber _arrayNumber)
        {

            // 배열의 전체 길이를 구한다 (여기서 배열의 최대 길이는 : 5)
            int count = _arrayNumber.Numbers.Count;


            // 2. 반복문을 '절반(len / 2)'만 돌리는 것이 핵심입니다!
            for (int i = 0; i < count / 2; i++)
            {

                // [교환 시작] 컵 A와 컵 B의 내용물을 바꾸는 과정입니다.

                // 3. 임시 변수(temp)에 '앞쪽' 값을 미리 대피시켜 둡니다.
                // i가 0일 때: temp = 0번 칸의 값
                int temp = _arrayNumber.Numbers[i];


                // 4. '뒤쪽'에 있는 값을 '앞쪽' 칸에 덮어씁니다.
                // len - 1 - i 는 i와 대칭되는 뒷번호입니다. (i가 0이면 4번, 1이면 3번)
                _arrayNumber.Numbers[i] = _arrayNumber.Numbers[count - 1 - i];

               
                // 5. 미리 대피시켜 두었던 temp(원래 앞쪽 값)를 '뒤쪽' 칸에 넣습니다.
                // 이로써 두 칸의 값이 완벽하게 서로 바뀌었습니다(Swap).
                _arrayNumber.Numbers[count - 1 - i] = temp;



                /*
                 * 절반(len / 2)만 돌렸을 때  => 반복문이 딱 2번만 돕니다. (5 / 2 = 2)
                 * 
                 * 1회차 (i = 0): 맨 앞(1)과 맨 뒤(5)를 바꿉니다. =>  결과: [5, 2, 3, 4, 1]
                 * 
                 * 2회차 (i = 1): 그 다음 안쪽인 2와 4를 바꿉니다. => 결과: [5, 4, 3, 2, 1] (뒤집기 성공!)
                 * 
                 * 전체(5번)를 다 돌리면 "바꿨던 걸 다시 또 바꿔서" 원래 상태로 돌아와 버리기 때문입니다.
                  

                 */
            }


        }

        static void RandomInputNumber(ArrayNumber _arrayNumber)
        {

            _arrayNumber.Numbers.Clear();
            Console.WriteLine("\n 1~100까지 숫자를 무작위로 뽑습니다.");
            Random random = new Random();

            //for (int i = 0; i < _arrayNumber.Numbers.Length; i++)
            for (int i = 0; i < 5; i++)
            {
                {
                    _arrayNumber.Numbers.Add(random.Next(1, 101));

                    // _arrayNumber 매개 변수에 불러온 Numbers 프롬파티를 불러온다. 정수 중 1부터 101까지 랜덤한 숫자를 불러 오는 것.
                }
            }

        }

        static void ShowScreen(ArrayNumber _arrayNumber)
        {

            Console.Clear();
            Console.WriteLine("===================================");
            Console.Write(" 현재 데이터:");

            for (int i = 0; i < _arrayNumber.Numbers.Count; i++)
            {

                Console.Write($"[{_arrayNumber.Numbers[i]}] ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("[1.입력] [2.프리셋] [3.랜덤] [4.분석] [5.뒤집기] [0.종료]");
            Console.WriteLine("===================================");

        }




        static void Main(string[] args)
        {

           ArrayNumber arrayNumber = new ArrayNumber();

            while (arrayNumber.IsRunning)
            {

                ShowScreen(arrayNumber);
               ProcessMenu(arrayNumber);


            }

            Console.WriteLine("\n엔터를 누르면 종료");
            Console.ReadLine();


        }
    }
}

/* 
 * 
 * 숫자  5개 저장 후 출력 배열로
 * 
 * 2 - 1  1을 누르면 숫자 5개를 입력하게 만들고 저장
 * 
 * 2  - 2 2를 누르면 스크립트에 미리 저장해둔 정보로 숫자를 저장
 * 
 * 2 = 3  3을 누르면 랜덤한 숫자 5개가 입력되게 만들어 주세용
 * 
 * 
 * 
 * 합 / 평균 출력 
 * 
 * 최대 / 최소 출력
 * 
 * 짝수만 출력 
 * 
 * 역순 출력
 * 
 * 5  -1 배열 내용을 뒤집어 버리기 
 * 
 * 
 * 추가 사항 
 * 
 * 메뉴에 값을 삭제를 하는 기능을 넣을 것
 * 
 * 입력한 숫자, 혹은 랜덤하게 나온 배열의 값이 중복이 되 안된다.
 * 
 * 
 */