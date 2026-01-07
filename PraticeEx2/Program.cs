using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static PraticeEx2.Program;

namespace PraticeEx2
{
    internal class Program
    {
        public class Calculator
        {
            private int m_FirstNum;
            private int m_SecondNum;


            public void SetNumber(int Num1, int Num2)
            {
                m_FirstNum = Num1;
                m_SecondNum = Num2;
            }

            public int AddNum()
            {
                return m_FirstNum + m_SecondNum;
            }

            public int SubNum()
            {
                return m_FirstNum - m_SecondNum;
            }

            public int MulNum()
            {
                return m_FirstNum * m_SecondNum;
            }

            public double DivNum()
            {
                if (m_SecondNum == 0)
                {
                    Console.WriteLine("0으로 나눈다니 조선천지에 있을 수 없는 일이야.");

                    return 0;
                }
                else
                {
                    return m_FirstNum / m_SecondNum;
                }

            }

            public bool IsRunning { set; get; } = true;
        }
            
            static void InputNumber(Calculator _calculator)
            {

                Console.WriteLine("===================");
                Console.WriteLine("[ + ], [ - ], [ * ], [ / ]");
                Console.Write("결과 값이야 임마 : ");
                ConsoleKeyInfo keyInfo = Console.ReadKey(); 
                
                switch(keyInfo.Key)
                {
                    case ConsoleKey.Add:
                        Console.WriteLine(_calculator.AddNum());
                        break;

                    case ConsoleKey.Subtract:
                        Console.WriteLine(_calculator.SubNum());
                        break;

                        case ConsoleKey.Multiply:
                        Console.WriteLine(_calculator.MulNum());
                       break;

                        case ConsoleKey.Divide:
                        Console.WriteLine(_calculator.DivNum());
                        break;

                        default:
                        Console.WriteLine("정신이 있는거야 없는거야?.");
                        break;
                }

                Console.WriteLine("=================");
                Console.WriteLine(" ");
                Console.ReadKey();

            }


            static void ShowScreen(Calculator _calculator)
            {
                Console.Clear();
                Console.WriteLine("===========내 이름은 계산기 근육=========== ");

                Console.WriteLine("첫번째 숫자를 입력을 해라고 임마");
                int Num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("두번째 값을 입력하라고허허헣허허허헣");
                int Num2 = int.Parse(Console.ReadLine()); 

                _calculator.SetNumber(Num1, Num2); 


            }

        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            while (calculator.IsRunning)
            {
                 ShowScreen(calculator);
                InputNumber(calculator);
              
            }




        }
    }
}
/*
 * 게산기
 * 1-1 덧셈만 
 * 
 * 정수 2개 입력 +덧셈 출력 
 * 
 * 사칙연산 
 * 
 */

// 내가 입력 한 숫자만큼 2의 승수 값을 출력해주세여
// 내가 100을 입력하면 2의 100승 값 출력 되어야하며
// 내가 1000을 입력하면 2의 1000승 값이 출력이 되어야 한다.