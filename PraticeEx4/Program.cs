using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticeEx4
{
    public class program
    {
        public class ClassPoint
        {
            private int[] m_ClassPoint = new int[5];
            public int[] Points
            {
                get { return m_ClassPoint; }
            }
            public bool IsRunning { get; set; } = true;
        }

        static void ProcessMenu(ClassPoint _classPoint)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:

                    InputPoint(_classPoint);
                    break;

                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:

                    AnalyzePoints(_classPoint);
                    break;

                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:

                    CheckSubjectPointPass(_classPoint);
                    break;

                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:

                    _classPoint.IsRunning = false;
                    break;

                default:

                    Console.WriteLine("[잘못된 입력입니다!] 엔터를 눌러주세요");
                    break;


            }
        }


        static void InputPoint(ClassPoint _classPoint)
        {
            string[] subjects = { "국어", "수학", "영어", "사회", "과학" };
            Console.WriteLine("\n 각 과목별 성적을 입력하여 주세요");

            for (int i = 0; i < _classPoint.Points.Length; i++)
            {
                int tempInput; // 입력하는 수를 담을 임시 변수

                // 올바른 점수가 입력이 될떄까지 반복
            while(true)
            {
                    Console.WriteLine($"{subjects[i]} 점수 : ");
                    tempInput = int.Parse(Console.ReadLine());

                    // 0점보다 크거나 같거나 100점 보다 작거나 같은지 확인
                    if (tempInput >= 0 && tempInput <= 100)
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine("숫자를 잘못 입력하였습니다.");


                    }
                }

            // 검증이 끝난 점수만 실제 배열에 저장
                _classPoint.Points[i] = tempInput;

           

            }    
         
            
        }

        static void CheckSubjectPointPass (ClassPoint _classPoint)

            // 과목 별로 60점 미만이 있는지 체크
        {
            int SubjectSum = 0;
            bool FalingSubject = false; // 과락(60점 미만) 여부를 체크. 

            for (int i = 0; i < _classPoint.Points.Length; i++)
            {
                int CurrentPoint = _classPoint.Points[i];
                SubjectSum += CurrentPoint;

                if (CurrentPoint < 60)
                {
                    FalingSubject = true;
                }
            }


            // 평균 점수 70점 이상 합격 여부 확인.
            double SubjectAvg = (double)SubjectSum / _classPoint.Points.Length;

            Console.WriteLine("\n ========합격 판정 결과========");
            Console.WriteLine("평균 점수 :" + SubjectAvg);

            if (SubjectAvg >= 70 && FalingSubject == false)
            {

                Console.WriteLine(" 결과 : [합격] 모든 결과에 만족합니다! ");
            }
            else
            {
                Console.WriteLine("결과 : [불합격]");

                if (SubjectAvg < 70)
                {
                    Console.WriteLine("사유 : 평균 점수가 70점 미만입니다.");
                }

                else if (FalingSubject == true)
                {
                    Console.WriteLine("사유 : 60점 미만 과락 과목이 있습니다.");
                }    
            }

            Console.WriteLine("==========================");
            Console.WriteLine("확인 후 엔터를 누르세요");
            Console.ReadLine();

        }


        static void AnalyzePoints(ClassPoint _classPoint)
        {

            string[] subjects = { "국어", "수학", "영어", "사회", "과학" };
            int ArraySum = 0;
            int ArrayMax = _classPoint.Points[0];
            int ArrayMin = _classPoint.Points[0];

            // 과목 위치(인덱스)를 기억하는 변수
            int maxIndex = 0;
            int minIndex = 0;

            for (int i = 0; i < _classPoint.Points.Length; i++)
            {
                int CurrentNumber = _classPoint.Points[i];
                ArraySum += CurrentNumber;

                if (CurrentNumber > ArrayMax)
                {

                    ArrayMax = CurrentNumber;
                    maxIndex = i;
                }

                if (CurrentNumber < ArrayMin)
                {
                    ArrayMin = CurrentNumber;
                    minIndex = i;
                }
            }

            double ArrayAvg = (double)ArraySum / _classPoint.Points.Length;


            Console.WriteLine("\n--- 성적 분석 결과---");
            Console.WriteLine($" 과목 총 평균 : {ArrayAvg}");
            Console.WriteLine(" 최대 점수 : " + ArrayMax + "(" + subjects[maxIndex] + ")");
            Console.WriteLine(" 최소 점수 : " + ArrayMin + "(" + subjects[minIndex] + ")");
            Console.WriteLine("\n 확인을 하셨으면 엔터를 누르세요");
            Console.ReadLine();

        }

        static void ShowScreen(ClassPoint _classPoint)
        {
            Console.Clear();
            Console.WriteLine("■+++++++++++++++++++++++++++++++++++■");
            Console.Write("현재 성적 데이터");

            for (int i = 0; i < _classPoint.Points.Length; i++)
            {
                Console.Write($"[{_classPoint.Points[i]}] ");

            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("[1.성적 입력] 2.[성적 분석] 3.[합격 확인] 4.[종료]");
            Console.WriteLine("■+++++++++++++++++++++++++++++++++++■");
        }




        static void Main(string[] args)
        {

            ClassPoint classPoint = new ClassPoint();

            while (classPoint.IsRunning)
            {
                ShowScreen(classPoint);
                ProcessMenu(classPoint);
            }

            Console.WriteLine("\n 엔터를 누르면 종료.");
            Console.ReadLine();
        }
    }
}



  





//앞에서 했던것을 정수를 관리하는 리스트. 

//클래스를 관리하는 리스트

//먼저 배열로 만들고
//내가 원하는 학생의 정보를 보고싶다.
//4-1 점수 배열 저장

//4-2 평균 출력

//4-3 합격 / 불합격 분류

//4-4 Student 클래스 도입


//여기서 리스트로 변환
//4-5 List<Student> 변경

//4-6 학생 추가

//4-7 학생 삭제

//4-8 전체 출력

//4-9 평균 이상만 출력

//4-10 최고 점수 학생

//4-11 메뉴 통합

//4-12 리팩토링