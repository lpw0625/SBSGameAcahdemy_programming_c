using Omok_game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Omok_game
{

    namespace Omok_game
    {
        public class Omok
        {
            private int[,] m_seat;
            private int m_size;

            private int m_curX;
            public int CurX
            {
                get { return m_curX; }
                set
                {
                    m_curX = value;
                    if (m_curX < 0) m_curX = 0;
                    else if (m_curX > m_size - 1) m_curX = m_size - 1;
                }
            }

            private int m_curY;
            public int CurY
            {
                get { return m_curY; }
                set
                {
                    m_curY = value;
                    if (m_curY < 0) m_curY = 0;
                    else if (m_curY > m_size - 1) m_curY = m_size - 1;
                }
            }

            private bool m_isBlackTurn;
            public bool IsPlaying { get; set; } // 오타 수정: IsPlaing -> IsPlaying

            public Omok(int _size = 19)
            {
                m_seat = new int[_size, _size];
                m_size = _size;

                CurX = m_size / 2;
                CurY = m_size / 2;

                for (int y = 0; y < m_size; y++)
                {
                    for (int x = 0; x < m_size; x++)
                    {
                        m_seat[y, x] = 0;
                    }
                }

                m_isBlackTurn = true;
                IsPlaying = true;
            }

            public void ShowScreen()
            {
                Console.Clear();
                for (int y = 0; y < m_seat.GetLength(0); y++)
                {
                    for (int x = 0; x < m_seat.GetLength(1); x++)
                    {
                        if (CurX == x && CurY == y)
                            Console.Write("C");
                        else if (m_seat[y, x] == 1)
                            Console.Write("B");
                        else if (m_seat[y, x] == 2)
                            Console.Write("W");
                        else
                            Console.Write("."); // 빈 공간은 점으로 표시하는 게 보기 좋습니다.

                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }

                if (m_isBlackTurn) Console.WriteLine("흑돌 차례입니다.");
                else Console.WriteLine("백돌 차례입니다.");
            }

            // --- 메서드들이 클래스 안에 포함되도록 중괄호 조정 필요 ---
            public void InputKey()
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: CurY--; break;
                    case ConsoleKey.DownArrow: CurY++; break;
                    case ConsoleKey.LeftArrow: CurX--; break; // 수정: 왼쪽은 --
                    case ConsoleKey.RightArrow: CurX++; break; // 수정: 오른쪽은 ++
                    case ConsoleKey.Spacebar: PutStone(); break; // 돌 놓기 기능 연결
                }
            }

            private void PutStone()
            {
                if (m_seat[CurY, CurX] == 0)
                {
                    m_seat[CurY, CurX] = m_isBlackTurn ? 1 : 2;

                    if (CheckFiveStone())
                    {
                        IsPlaying = false; // 승리 시 루프 종료
                    }
                    else
                    {
                        m_isBlackTurn = !m_isBlackTurn; // 승리 안 했을 때만 턴 교체
                    }
                }
            }

            private bool CheckFiveStone()
            {
                int checkNum = m_isBlackTurn ? 1 : 2;

                // 가로 체크 (세로, 대각선 로직도 동일한 구조로 추가 가능)
                for (int i = 0; i < 5; i++)
                {
                    int count = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        int temp = i + j - 4;
                        if (CurX - temp < 0 || CurX - temp >= m_size) continue;

                        if (m_seat[CurY, CurX - temp] == checkNum) count++;
                        else break;

                        if (count == 5) return true;
                    }
                }
                return false; // 모든 루프를 다 돌았는데 5개가 없으면 그때 false 리턴
            }


            //private bool CheckFiveStoneTwo (int _x, int _y, int _checkNuM, int _xDt, int _yDt)
            //{ 
            //     for (int i = 0; i< 5; i++)
            //    {
            //        int count = 0;
            //        for (int j = 0; j< 5; j++)
            //        {
            //            int xDt = 0; // x +i + j - 4;
            //            int yDt = 0;
            //            if (_xDt == 1)
            //                xDt = _x + i + j - 4;

            //            if (_yDt == 1)
            //                yDt = _y + i + j - 4;



            //            if (CurX - temp< 0 || CurX - temp >= m_size) continue;

            //            if (m_seat[CurY, CurX - temp] == checkNum) count++;
            //            else break;

            //            if (count == 5) return true;
            //        }
        
    



    public bool GetIsBlackTurn() => m_isBlackTurn;

            internal class Program
            {
                static void Main(string[] args)
                {

                    Omok omok = new Omok();

                    while (omok.IsPlaying)
                    {
                        omok.ShowScreen();
                        omok.InputKey();
                    }

                    if (omok.GetIsBlackTurn())
                        Console.WriteLine("흑돌이 승리하였습니다");
                    else
                        Console.WriteLine("백돌이 승리하였습니다");

                    Console.ReadLine();



                }
            }
        }     
    }
}
-
