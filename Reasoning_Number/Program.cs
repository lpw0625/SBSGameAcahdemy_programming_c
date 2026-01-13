using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reasoning_Number
{
    public class Program
    {

        public class NumberGame
        {

            private int[] m_ComputerNumber; // 컴퓨터가 생성하는 답안 

            public int[] ComputerNumber
            {
                get
                {
                    return m_ComputerNumber;
                }
            }


            private int m_CurrentTargetIndex; // 현재 몇 번째 정답을 맞추는 중.

            //public int CurrentTargetIndex
            //{
            //    get
            //    {
            //        return m_CurrentTargetIndex;

            //    }
            //}



            private int m_SuccessCount; // 총 시도 횟수

            public int SuccessCount
            {
                get
                {
                    return m_SuccessCount;
                }
            }

            private int m_level = 1;

           

     
            public bool Isplaying = true;

        public static void InputPlayerNumber(NumberGame _numberGame, int Level)
            {
                _numberGame.m_level = Level; // 선택한 난이도 저장

                _numberGame.m_ComputerNumber = new int[Level]; // 난이도만큼 배열 크기 설정 

                _numberGame.m_SuccessCount = 0; // 시도 횟수 초기화
                _numberGame.m_CurrentTargetIndex = 0;

               Random random = new Random();

                for (int i = 0; i < Level; i++)
                {
                    _numberGame.m_ComputerNumber[i] = random.Next(1, 101); // 
                }

                Console.WriteLine($"\n☆ 컴퓨터가 {Level}개의 숫자를 정했습니다! 게임 시작합니다~! ☆");
            }

          public static void PlayGame(NumberGame _numberGame)
            {

                int playerGuessNumber = 0;


                Console.WriteLine("\n ☆숫자를 입력을 하세요~☆");

                playerGuessNumber = int.Parse(Console.ReadLine());


                if (playerGuessNumber < 1 || playerGuessNumber > 100)
                {
                    Console.WriteLine(" =============================== ");
                    Console.WriteLine(" [경고!] 범위에서 벗어났습니다! [1~100]");
                    Console.WriteLine(" =============================== ");
                }

                else
                {
                    _numberGame.m_SuccessCount++;

                    CheckUpDown(_numberGame,playerGuessNumber);
                }

            }


            public static void CheckUpDown(NumberGame _numberGame, int guess)
            {
                int target = _numberGame.m_ComputerNumber[_numberGame.m_CurrentTargetIndex];
                
                if (guess < target)
                {
                    Console.WriteLine("▲ UP!");
                }

                else if (guess > target)
                {
                    Console.WriteLine("▼ DOWN!");
                }

                else
                {
                    Console.WriteLine("★ 정답입니다! ★");
                    _numberGame.m_CurrentTargetIndex++;


                    if (_numberGame.m_CurrentTargetIndex >= _numberGame.m_ComputerNumber.Length)
                    {

                        Console.WriteLine("\n 축하합니다! 당신은 모든 숫자를 맞추셨습니다!");
                        Console.WriteLine($" 총 시도 횟수 : {_numberGame.m_SuccessCount}회");
                        _numberGame.Isplaying = false; // 루프 탈출


                    }
                }

            }


              public static void ProcessMenu(NumberGame _numberGame)
                {
                Console.WriteLine("\n[1] 게임 시작 [2] 난이도 설정 [0] 종료");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)

                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        InputPlayerNumber(_numberGame, _numberGame.m_level);
                        
                        while (_numberGame.Isplaying)
                        {
                            PlayGame(_numberGame);
                        }
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        LevelChoiceMenu(_numberGame);
                        break;

                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        _numberGame.Isplaying = false;
                        break;

                    default:

                        Console.WriteLine("잘못된 입력압니다! - 엔터를 누르세요");
                        break;
                }
            }

           public static void LevelChoiceMenu (NumberGame _numberGame)
            {

                Console.WriteLine("\n난이도를 선택하여 주세요 : 1.[ 초급 ] 2.[ 중급 ] 3.[ 상급 ]");
                _numberGame.m_level = int.Parse(Console.ReadLine());
                Console.WriteLine($"난이도가 {_numberGame.m_level}로 설정이 되었습니다");


            }
        }
        static void Main(string[] args)
        {

            NumberGame numberGame = new NumberGame();

            
            while (numberGame.Isplaying) 
            
            { 
            
                NumberGame.ProcessMenu(numberGame);  
            
            
            }


          


        }
    }
}
