using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballEx
{
    internal class Program
    {
        // 게임 시작 메시지를 출력하는 함수
        static void ShowStartScreen()
        {
            Console.WriteLine("야구게임 시작~!.");
            Console.WriteLine("☆ 룰 설명~! ☆ :  중복되지 않는 숫자 3개를 입력해주세요!");
        }

        // 컴퓨터가 중복되지 않는 3개의 숫자를 생성하는 함수 (셔플 알고리즘)
        static int[] GetNumber()
        {
            Random rand = new Random();
            int[] arrayRandNum = new int[10];

            // 0부터 9까지 숫자를 배열에 채움
            for (int i = 0; i < 10; i++)
                arrayRandNum[i] = i;

            // 피셔-예이츠 셔플과 유사한 방식으로 앞의 3개만 무작위로 섞음
            for (int i = 0; i < 3; i++)
            {
                int result = rand.Next(i, 10); // i번째 이후의 인덱스 중 하나를 무작위로 선택
                int temp = arrayRandNum[i];    // 값 바꾸기(Swap)를 통해 중복 방지
                arrayRandNum[i] = arrayRandNum[result];
                arrayRandNum[result] = temp;
            }
            return arrayRandNum; // 섞인 배열 반환 (앞의 3개만 사용 예정)
        }

        // 사용자가 입력한 문자열이 규칙에 맞는지 검사하는 함수
        static bool IsNumberCheck(string str)
        {
            // 1. 길이가 3인지 체크
            if (str.Length != 3)
            {
                Console.WriteLine("입력하신 문자 길이가 3개가 아닙니다.");
            }
            else
            {
                bool _isNum = true;          // 숫자인지 여부
                bool _isDuplication = true;  // 중복이 없는지 여부

                for (int i = 0; i < 3; i++)
                {
                    char temp = str[i];
                    // 2. 숫자인지 체크 (아스키 코드 48~57 : '0'~'9')
                    if (48 <= temp && temp <= 57)
                    {
                        // 3. 중복 체크 (자신과 다음 숫자들을 비교)
                        for (int a = 0; a < str.Length; a++)
                        {
                            for (int b = a + 1; b < str.Length; b++)
                            {
                                if (str[a] == str[b]) _isDuplication = false;
                            }
                        }
                    }
                    else
                    {
                        _isNum = false; // 문자가 포함된 경우
                    }
                }

                // 모든 검사를 통과했을 때만 true 반환
                if (_isNum)
                {
                    if (_isDuplication)
                    {
                        Console.WriteLine("입력받은게 모두 정상적인 숫자입니다.");
                        return true;
                    }
                    else Console.WriteLine("중복된 숫자가 있습니다.");
                }
                else Console.WriteLine("입력받은 것 중에 문자가 있습니다.");
            }
            return false;
        }

        static void Main(string[] args)
        {
            ShowStartScreen();

            // 1. 컴퓨터의 정답 숫자 생성 및 저장
            int[] arrayCorrectNum = new int[3];
            int[] arrayResult = GetNumber();

            // 생성된 무작위 배열에서 앞의 3개만 정답 배열에 복사
            for (int i = 0; i < arrayCorrectNum.Length; i++)
                arrayCorrectNum[i] = arrayResult[i];

            // 2. 게임 루프 시작
            while (true)
            {
                string str = Console.ReadLine();

                // 입력값 유효성 검사
                if (IsNumberCheck(str))
                {
                    int[] arrayEnterNum = new int[3];
                    for (int i = 0; i < arrayEnterNum.Length; i++)
                    {
                        // 문자를 숫자로 변환 (아스키 코드 값 보정)
                        // '0'의 아스키 코드는 48이므로 -48을 해야 실제 숫자가 됨
                        arrayEnterNum[i] = Convert.ToInt32(str[i]) - 48;
                    }

                    int _strike = 0;
                    int _ball = 0;

                    // 3. 판정 로직 (이중 반복문)
                    for (int i = 0; i < arrayCorrectNum.Length; i++) // 컴퓨터 숫자 기준
                    {
                        for (int j = 0; j < arrayEnterNum.Length; j++) // 사용자 입력 기준
                        {
                            // 숫자가 존재하는지 확인
                            if (arrayCorrectNum[i] == arrayEnterNum[j])
                            {
                                if (i == j) _strike++; // 자릿수까지 같으면 스트라이크
                                else _ball++;          // 자릿수는 다르면 볼
                            }

                            // 4. 승리 조건 체크
                            if (_strike == 3)
                            {
                                Console.WriteLine("축하합니다! 정답을 맞히셨습니다.");
                                // ※ 주의: 여기서 break는 내부 for문만 탈출합니다.
                                // 게임을 끝내려면 아래에 추가 처리가 필요합니다.
                            }
                        }
                    }

                    // 5. 현재 턴 결과 출력
                    Console.WriteLine(_strike + " S ");
                    Console.WriteLine(_ball + " B ");
                    Console.WriteLine();

                    // 정답을 맞혔을 때 게임 종료 처리 (추가 권장)
                    if (_strike == 3) break;




                }
            }
        }
    }
}