using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;


// 숫자 야구게임 만들기
//
// 룰 - 플레이어는 중복되지 않는 숫자 3개를 입력한다.
//    - 중복되는 숫자거나 숫자 3개가 아니면 아니라고 알려준다.
//    - 숫자 3개 입력시 비교를 하여 스트라이크와 볼을 체크해준다
//
// 1. 처음에 화면에 야구게임이라고 출력해준다.
// 2. 컴퓨터가 중복되지 않는 랜덤한 숫자 3개 정하기
// 3. 플레이어가 뭐든 입력이 가능하게
//    - 문자열의 길이가 3인가?
//    - 입력된 문자들이 숫자인가?
//    - 입력된 숫자들이 중복되지않는가?
// 4. 내가 올바르게 입력한 숫자가 컴퓨터가 처음 정한 숫자가 맞는지 비교를한다.
//    - 숫자와 위치가 같은경우 - S
//    - 숫자는 맞는데 위치가 다른경우 - B
// 5. 몇번만에 맞췄는지에 대한 결과와 끝난다는 결과창이 나와야한다.
//    - 다시 숫자를 집어서 다시 게임이 되어야한다.

namespace BaseballEx
{
    internal class Program
    {
        static void ShowStartScreen()
        {
            Console.WriteLine("숫자 야구게임에 오신것을 환영합니다.");
            Console.WriteLine("중복되지 않는 숫자 3개를 입력해주세요.");
        }

        static int[] GetRandom()
        {
            Random rand = new Random();
            int[] arrayRand = new int[10];
            for (int i = 0; i < arrayRand.Length; i++)
                arrayRand[i] = i;

            for (int i = 0; i < arrayRand.Length; i++)
            {
                int randResult = rand.Next(i, 10);
                int temp = arrayRand[i];
                arrayRand[i] = arrayRand[randResult];
                arrayRand[randResult] = temp;
            }

            int[] arrayResult = new int[3];
            for (int i = 0; i < arrayResult.Length; i++)
                arrayResult[i] = arrayRand[i];

            return arrayResult;
        }

        static bool GetCheckNumber(string str)
        {
            bool _isLength = true;
            bool _isNumber = true;
            bool _isOverlap = true;

            //문자열의 길이비교
            if (str.Length != 3)
            {
                _isLength = false;
                if (str.Length < 3)
                    Console.WriteLine("입력받은 문자의 길이가 3보다 작습니다.");
                else
                    Console.WriteLine("입력받은 문자의 길이가 3을 넘었습니다.");
            }

            //문자열에 숫자만 있는지
            if (_isLength)
            {
                //char tempC = '0'; 일때 int로 바꾸면 48
                //char tempC = '9'; 일때 int로 바꾸면 57
                //입력받은 문자들이 전부 숫자라면
                for (int i = 0; i < str.Length; i++)
                {
                    char tempC = str[i];
                    if (48 > tempC || tempC > 57)
                        _isNumber = false;
                }
            }
            if (_isNumber == false)
                Console.WriteLine("문자가 섞여있습니다.");

            //숫자들이 전부 중복되지 않는지.
            if (_isLength && _isNumber)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    for (int j = i + 1; j < str.Length; j++)
                    {
                        if (str[i] == str[j])
                        {
                            _isOverlap = false;
                        }
                    }
                }
            }
            if (!_isOverlap)
                Console.WriteLine("중복되는 숫자가 있습니다.");



            if (_isLength && _isNumber && _isOverlap)
                return true;
            else
                return false;

        }


        static void Main()
        {
            ShowStartScreen();
            int[] arrayCorrect = GetRandom();
            int _count = 0;

            while (true)
            {
                string inputStr = Console.ReadLine();
                bool _bool = GetCheckNumber(inputStr);

                if (_bool)
                {
                    _count++;
                    int _strike = 0;
                    int _ball = 0;

                    for (int i = 0; i < inputStr.Length; i++)
                    {
                        for (int j = 0; j < arrayCorrect.Length; j++)
                        {
                            int tempNum = (int)inputStr[i] - 48;
                            if (tempNum == arrayCorrect[j])
                            {
                                if (i == j)
                                    _strike++;
                                else
                                    _ball++;
                            }
                        }
                    }

                    Console.WriteLine(_strike + " : S");
                    Console.WriteLine(_ball + " : B");

                    //정답을 맞췄을때
                    if (_strike == 3)
                    {
                        Console.WriteLine("정답입니다!");
                        Console.WriteLine("시도한 횟수 : " + _count);
                        Console.ReadKey();

                        Console.Clear();
                        ShowStartScreen();
                        arrayCorrect = GetRandom();
                        _count = 0;
                    }

                }
                else
                {

                }

            }
        }
    }
}

#region 
//// 게임 시작 메시지를 출력하는 함수
//static void ShowStartScreen()
//{
//    Console.WriteLine("야구게임 시작~!.");
//    Console.WriteLine("☆ 룰 설명~! ☆ :  중복되지 않는 숫자 3개를 입력해주세요!");
//}

//// 컴퓨터가 중복되지 않는 3개의 숫자를 생성하는 함수 (셔플 알고리즘)
//static int[] GetNumber()
//{
//    Random rand = new Random();
//    int[] arrayRandNum = new int[10];

//    // 0부터 9까지 숫자를 배열에 채움
//    for (int i = 0; i < 10; i++)
//        arrayRandNum[i] = i;

//    // 피셔-예이츠 셔플과 유사한 방식으로 앞의 3개만 무작위로 섞음
//    for (int i = 0; i < 3; i++)
//    {
//        int result = rand.Next(i, 10); // i번째 이후의 인덱스 중 하나를 무작위로 선택
//        int temp = arrayRandNum[i];    // 값 바꾸기(Swap)를 통해 중복 방지
//        arrayRandNum[i] = arrayRandNum[result];
//        arrayRandNum[result] = temp;
//    }
//    return arrayRandNum; // 섞인 배열 반환 (앞의 3개만 사용 예정)
//}

//// 사용자가 입력한 문자열이 규칙에 맞는지 검사하는 함수
//static bool IsNumberCheck(string str)
//{
//    // 1. 길이가 3인지 체크
//    if (str.Length != 3)
//    {
//        Console.WriteLine("입력하신 문자 길이가 3개가 아닙니다.");
//    }
//    else
//    {
//        bool _isNum = true;          // 숫자인지 여부
//        bool _isDuplication = true;  // 중복이 없는지 여부

//        for (int i = 0; i < 3; i++)
//        {
//            char temp = str[i];
//            // 2. 숫자인지 체크 (아스키 코드 48~57 : '0'~'9')
//            if (48 <= temp && temp <= 57)
//            {
//                // 3. 중복 체크 (자신과 다음 숫자들을 비교)
//                for (int a = 0; a < str.Length; a++)
//                {
//                    for (int b = a + 1; b < str.Length; b++)
//                    {
//                        if (str[a] == str[b]) _isDuplication = false;
//                    }
//                }
//            }
//            else
//            {
//                _isNum = false; // 문자가 포함된 경우                                  
//            }
//        }

//        // 모든 검사를 통과했을 때만 true 반환
//        if (_isNum)
//        {
//            if (_isDuplication)
//            {
//                Console.WriteLine("입력받은게 모두 정상적인 숫자입니다.");
//                return true;
//            }
//            else Console.WriteLine("중복된 숫자가 있습니다.");
//        }
//        else Console.WriteLine("입력받은 것 중에 문자가 있습니다.");
//    }
//    return false;
//}

//static void Main(string[] args)
//{
//    ShowStartScreen();

//    // 1. 컴퓨터의 정답 숫자 생성 및 저장
//    int[] arrayCorrectNum = new int[3];
//    int[] arrayResult = GetNumber();

//    // 생성된 무작위 배열에서 앞의 3개만 정답 배열에 복사
//    for (int i = 0; i < arrayCorrectNum.Length; i++)
//        arrayCorrectNum[i] = arrayResult[i];

//    // 2. 게임 루프 시작
//    while (true)
//    {
//        string str = Console.ReadLine();

//        // 입력값 유효성 검사
//        if (IsNumberCheck(str))
//        {
//            int[] arrayEnterNum = new int[3];
//            for (int i = 0; i < arrayEnterNum.Length; i++)
//            {
//                // 문자를 숫자로 변환 (아스키 코드 값 보정)
//                // '0'의 아스키 코드는 48이므로 -48을 해야 실제 숫자가 됨
//                arrayEnterNum[i] = Convert.ToInt32(str[i]) - 48;
//            }

//            int _strike = 0;
//            int _ball = 0;

//            // 3. 판정 로직 (이중 반복문)
//            for (int i = 0; i < arrayCorrectNum.Length; i++) // 컴퓨터 숫자 기준
//            {
//                for (int j = 0; j < arrayEnterNum.Length; j++) // 사용자 입력 기준
//                {
//                    // 숫자가 존재하는지 확인
//                    if (arrayCorrectNum[i] == arrayEnterNum[j])
//                    {
//                        if (i == j) _strike++; // 자릿수까지 같으면 스트라이크
//                        else _ball++;          // 자릿수는 다르면 볼
//                    }

//                    // 4. 승리 조건 체크
//                    if (_strike == 3)
//                    {
//                        Console.WriteLine("축하합니다! 정답을 맞히셨습니다.");
//                        // ※ 주의: 여기서 break는 내부 for문만 탈출합니다.
//                        // 게임을 끝내려면 아래에 추가 처리가 필요합니다.
//                    }
//                }
//            }

//            // 5. 현재 턴 결과 출력
//            Console.WriteLine(_strike + " S ");
//            Console.WriteLine(_ball + " B ");
//            Console.WriteLine();

//            // 정답을 맞혔을 때 게임 종료 처리 (추가 권장)
//            if (_strike == 3) break;

#endregion