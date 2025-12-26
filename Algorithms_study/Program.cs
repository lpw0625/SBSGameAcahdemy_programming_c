using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_study
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listA = new List<int>();

            for (int i = 0; i < 10; i++ )
            {
                ////  배열길이 빈곳 가장 앞에 값이 들어가고
                ////  넘으면 리사이징 해줘서 늘려준다.

                //listA.Add(i); // 리스트에 자료형에 맞게 추가 
                //listA.Insert(0, i); // 원하는 위치에 Add
                //listA.Remove(0); // 해당 값의 자료형을 지울때 사용
                //listA.RemoveAt(3); // 몇 번째 인덱스에 있는 자료형을 제거
                //listA.Sort(); // 내부에서 데이터를 정렬해준다.                                                                                                                                                                                                                                                                                                                                                                                                                    
                //listA.Clear(); // 외부에서 비워준다.
                // // Capacity : 배열의 Length

                var a = 0;
                var b = "";
                var c = 'C';
                var d = 1.2;

            }

           for (int i = 0; i < dicA; i++)
            {

                int result = dicA[""]
                //listA.Add(i);
                //listA.Insert(50, i);
                //Console.WriteLine($"list Count : {listA.Count}");
                //Console.WriteLine($"list Capacity : {listA.Capacity}");

            }

       
            foreach (int listValue in listA) 
            {

                Console.Write(listValue + " ");

            }
            Dictionary<string, int> dicA = new Dictionary<string, int>();
            dicA.Add("Nice", 1);
            dicA.Add("B", 2);
            dicA.Add("C", 3);
            dicA["A"] = 2;

            Console.WriteLine();
            int index = 0;
            foreach (KeyValuePair<string, int> A in dicA)
            {
                Console.Write("결과 : " + A + " ");
            }

            Stack<int> stackA = new Stack<int>();

            stackA.Push(1);
            stackA.Push(2);
            stackA.Push(3);
            stackA.Push(4);

            var a = stackA.Pop();

            Console.WriteLine();
            foreach (int item in stackA)
            {
                Console.WriteLine(item + " ");
            }

            Console.Write( "   a : ");


            #region
            //int[] arrayA = new int[100];

            //for (int i = 0; i < 100; i++)
            //    arrayA[i] = i;

            ////arrayA[50] = 100;
            ////arrayA[51] = arrayA[50];
            ////arrayA[52] = arrayA[51];
            ////arrayA[53] = arrayA[52];

            //for (int i = 45; i < 55; i++)

            //{
            //    Console.WriteLine(arrayA[i] + " ");

            //}
            #endregion
            Console.ReadKey();



        


            #region 동작구조
            // [배열의 동작구조]
            //int[] arrayA = new int[4];
            //arrayA[0] = 0; 
            //arrayA[1] = 1; 
            //arrayA[2] = 2; 
            //arrayA[3] = 3;

            //int[] temp = new int[8];

            //for (int i = 0; i < arrayA.Length; i++ ) 

            //{
            //    temp[i] = arrayA[i];
            //    arrayA = temp;
            //    arrayA[4] = 4;
            //    arrayA[5] = 5;
            //    arrayA[6] = 6;
            //    arrayA[7] = 7;
            //    arrayA[8] = 8;
            //}

            #endregion

            #region
            //int[] array1 = new int[100];

            //// 근본은 배열이다 
            //List<int> array2 = new List<int>();

            //array2.Add(1);

            //for (int i = 0; i < 100; i++)
            //{
            //    array2.Add(1);
            //}

            // 8756을 찾아야한다. 

            //for ( int i = 0; i < 10000; i++ ) 
            //{ 
            //   if (array1[i] == 8756)
            //    {
            //        Console.WriteLine("정답");
            //    }
            //}

            //List<int> listA = new List<int>();
            //LinkedList<int> LinkedListA = new LinkedList<int>();
            //Dictionary<string, int> dicA = new Dictionary<string, int>();
            //Stack<int> stackA = new Stack<int>();
            #endregion


        }
    }
}   

  

