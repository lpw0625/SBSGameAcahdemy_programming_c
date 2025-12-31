using ConcaveGame.ConcaveGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


// 오목 게임 
// 흑돌과 백돌이 필요하다.
// 오목판 (좌표)
// 입력 받기 -인풋 자리 
// 내가 어디 둘것인지 대한 좌표 = 현재 나의 좌표
// 룰 정리

namespace ConcaveGame
{
    namespace ConcaveGame
    {
        public class Omok
        {
            private int[,] m_seat;   // 오목판 데이터를 저장하는 2차원 배열 (0:빈칸, 1:흑돌, 2:백돌)
            private int m_size;      // 오목판의 크기 (기본 19x19)

            // 현재 커서(C)의 X 좌표 (프로퍼티를 통해 판 범위를 벗어나지 않게 제어)
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

            // 현재 커서(C)의 Y 좌표
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

            private bool m_isBlackTurn; // true면 흑돌 턴, false면 백돌 턴
            public bool IsPlaing { get; set; } // 게임이 진행 중인지 여부

            // 생성자: 게임 시작 시 초기 설정을 담당
            public Omok(int _size = 19)
            {
                m_size = _size;
                CurX = m_size / 2; // 커서를 판 정중앙에 위치
                CurY = m_size / 2;
                m_seat = new int[m_size, m_size];

                // 판의 모든 칸을 0(빈칸)으로 초기화
                for (int y = 0; y < m_size; y++)
                {
                    for (int x = 0; x < m_size; x++)
                    {
                        m_seat[y, x] = 0;
                    }
                }

                m_isBlackTurn = true; // 흑돌 선공
                IsPlaing = true;
            }

            // 화면 렌더링: 현재 판의 상태를 콘솔에 출력
            public void ShowOmok()
            {
                Console.Clear(); // 화면을 지우고 새로 그림
                for (int y = 0; y < m_seat.GetLength(0); y++)
                {
                    for (int x = 0; x < m_seat.GetLength(1); x++)
                    {
                        if (CurX == x && CurY == y) // 현재 내 커서 위치
                            Console.Write("C");
                        else if (m_seat[y, x] == 1) // 흑돌
                            Console.Write("B");
                        else if (m_seat[y, x] == 2) // 백돌
                            Console.Write("W");
                        else if (m_seat[y, x] == 0) // 빈 공간
                            Console.Write("'");

                        Console.Write(" "); // 보기 편하게 한 칸 띔
                    }
                    Console.WriteLine();
                }

                // 하단에 현재 누구 턴인지 표시
                if (m_isBlackTurn) Console.WriteLine("흑돌 턴");
                else Console.WriteLine("백돌 턴");
            }

            // 키보드 입력 처리: 방향키로 이동하고 스페이스바로 돌을 놓음
            public void InputKey()
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: case ConsoleKey.W: CurY--; break;
                    case ConsoleKey.DownArrow: case ConsoleKey.S: CurY++; break;
                    case ConsoleKey.RightArrow: case ConsoleKey.D: CurX++; break;
                    case ConsoleKey.LeftArrow: case ConsoleKey.A: CurX--; break;
                    case ConsoleKey.Spacebar:
                        PutStone(); // 스페이스바 누르면 돌 놓기 시도
                        break;
                }
            }

            // 돌을 판에 기록하는 메서드
            private void PutStone()
            {
                int x = m_curX;
                int y = m_curY;

                // 해당 자리에 이미 돌이 있지 않을 때만 놓을 수 있음
                if (m_seat[y, x] == 0)
                {
                    m_seat[y, x] = m_isBlackTurn ? 1 : 2; // 현재 턴의 돌 번호 저장

                    // 돌을 놓은 직후 승리 조건을 체크
                    if (!CheckFiveStone())
                        m_isBlackTurn = !m_isBlackTurn; // 이기지 않았다면 상대방 턴으로 교체
                }
            }

            // 핵심 알고리즘: 5개가 연결되었는지 4가지 방향(가로, 세로, 대각선 2개) 체크
            private bool CheckFiveStone()
            {
                int checkNum = m_isBlackTurn ? 1 : 2; // 지금 놓은 돌이 1인지 2인지 확인
                int x = CurX;
                int y = CurY;

                // 알고리즘 원리: 현재 놓은 위치를 포함하여 5개가 일렬이 되는 모든 경우의 수를 검사
                // (i는 시작점 오프셋, j는 연속된 돌의 개수 확인)

                // 1. 가로 체크
                for (int i = 0; i < 5; i++)
                {
                    int count = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        int temp = i + j - 4;
                        if (x - temp < 0 || x - temp >= m_size) continue; // 판 밖으로 나가면 무시
                        if (m_seat[y, x - temp] == checkNum) count++;
                        else break;

                        if (count == 5) { IsPlaing = false; return true; } // 5개 완성 시 게임 종료
                    }
                }
                // ... (세로, 대각선들도 동일한 로직으로 검사)
                // 중략: 세로, 대각선(/), 대각선(\) 체크 로직...

                return false; // 아직 5개가 안 됨
            }

            public bool GetIsBlackTurn() { return m_isBlackTurn; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Omok omok = new Omok(); // 1. 게임 객체 생성 (초기화)

            // 2. 게임이 진행 중(IsPlaing == true)인 동안 무한 반복
            while (omok.IsPlaing)
            {
                omok.ShowOmok();  // 화면에 현재 판을 그림
                omok.InputKey();  // 플레이어의 키 입력을 기다리고 처리함
            }

            // 3. 루프를 빠져나왔다면 누군가 승리한 것임
            // 마지막에 돌을 둔 사람이 승리자이므로 현재 턴을 확인하여 승리 메시지 출력
            if (omok.GetIsBlackTurn())
                Console.WriteLine("흑돌 승리");
            else
                Console.WriteLine("백돌 승리");

            Console.ReadLine();
        }
    }


// 오목을 만들것입니다.
// 이제 우리 뭐함?
// 1. 흑돌과 백돌이 필요하다.
//    - 각각 한번씩 돌을 놔야한다.
//    - 완
// 2. 오목판 - (좌표) 
//    - 완
// 3. 입력받기 - 인풋처리
//    - 완
// 4. 내가 어디 둘것인지 대한 좌표 - 현재 나의 좌표
//    - 완
//  
// 5. 알고리즘
//    - 많은데이터를 저장하고 관리하는게 알고리즘
// 룰정리 - 문서로 표현할줄 알아야한다.
// 가로   세로   오른쪽아래대각선   오른쪽위대각선
// 돌을 둔 그 순간 그 돌을 기준으로 5개가 연결되는지를 체크해야한다.

