using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticeEx_2
{
    internal class Program
    {
        static void Main(string[] args)
    
        {
            #region 예제 오름차순 내림차순


            // a와 b 바꿀떄 어떻게? temp 하나 생성해서 바꾼다
            // 0 ~ 9 까지 숫자가 랜덤하게 배열에 들어가 있어야 한다.
            // 숫자를 오름차순 과 내림차순으로 출력을 할 것.



            // 내가 적은 오름차순 답안
            //int[] arrayB = new int[10];
            //Random rand = new Random();

            //for (int i = 0; i < arrayB.Length; i++)
            //    arrayB[i] = i;

            //for (int i = 0; i < arrayB.Length; i++)

            //{
            //    int _value = rand.Next(0, arrayB.Length);
            //    int _temp = arrayB[i];

            //    arrayB[i] = _value;
            //    arrayB[i] = _temp;

            //}

            //// Console.ReadKey();


            //int[] arrayA = new int[10];

            //for (int i = 0; i < arrayA.Length; i++)
            //    arrayA[i] = i;

            //Random _rand = new Random();
            //rand.Next(0, 10); 


            //int k = 9;
            //for (int i = 0; i < arrayA.Length; i++)
            //{
            //    arrayA[i] = k--;
            //}

            //for (int i = 0; i < arrayA.Length; i++)
            //{
            //    Console.Write(arrayA[i] + " ");
            //}



            //// 내림차순 

            //for (int i = 0; i < arrayA.Length; i++)
            //{

            //    int temp = arrayA[i];
            //    int index = i;

            //    for (int j = i + 1; j < arrayA.Length; j++)

            //    {
            //        if (temp > arrayA[j])
            //        {
            //            temp = arrayA[j];
            //            index = j;

            //        }
            //    }


            //    // a와 b의 값을 바꾸는 구조로 간다면

            //    temp = arrayA[i];
            //    arrayA[i] = arrayA[index];
            //    arrayA[index] = temp;
            //}
            //Console.WriteLine();

            //for (int i = 0; i  < arrayA.Length; i++)

            //{
            //        Console.Write(arrayA[i] + " ");
            //}

            //Console.ReadKey();




            #endregion
            #region 예제2

            // a와 b 바꿀떄 어떻게? temp 하나 생성해서 바꾼다
            // 0 ~ 9 까지 숫자가 랜덤하게 배열에 들어가 있어야 한다.
            // 

            //int[] arrayA = new int[10]; 

            //for (int i = 0; i < arrayA.Length; i++)
            //    arrayA[i] = i;

            //Random rand = new Random();
            //rand.Next(0,10); // arrayA.Length


            //for (int i = 0; i < arrayA.Length; i++) 
            //{
            //   int _value =  rand.Next(i, arrayA[i]);
            //   int temp = arrayA[i];

            //   arrayA[0] = arrayA[_value];
            //   arrayA[_value] = temp;
            //}

            //for (int i = 0; i < arrayA.Length; i++)
            //{
            //    Console.WriteLine(arrayA[i] + " ");
            //}

            //Console.ReadKey();

            #endregion
            #region 예제

            // 제일 큰 숫자 제일 작은 숫자 배열을 뒤집기, 
            // int[] arrayA = new int[10];


            //// 0부터 9까지 숫자가 랜덤하게 배열에 들어가 있어야 한다.


            //// 배열이 내용이 바뀌더라도 가능해야 한다.
            //// 배열에서 가장 큰 숫자를 result 넣어주세요 
            //// 배열에서 가장 작은 숫자를 result 넣어주세요

            //int result = 5;
            //int min = 0;
            //int max = 0;
            //int index = 0;

            //   for (int i = 0; i < arrayA.Length; i++)

            ////   arrayA[i] = i;


            ////   // 배열이 내용이 바뀌더라도 가능해야 한다.
            ////   // 배열에서 가장 큰 숫자를 result 넣어주세요 
            ////   // 배열에서 가장 작은 숫자를 result 넣어주세요

            ////   for (int i = 0; i < arrayA.Length; i++)
            ////   {
            ////        if (result > arrayA[i])
            ////           result = arrayA[i];
            ////   }


            ////Console.WriteLine(index);
            ////Console.ReadKey();


            ////      // 0~9 배열 내부 내용을 거꾸로 넣어주세요 
            //for (int i = 0; i < arrayA.Length; i++)
            //    arrayA[i] = i;

            //int[] arrayB = new int[10];
            //for (int i = 0; i < arrayB.Length; i++)
            //{
            //    arrayB[i] = arrayA[i]; 
            //}

            //int a = 0;
            //int b = 9; //arrayB.Length - 1;
            //for(; a < arrayA.Length;)
            //{
            //    arrayB[a++] = arrayA[b--];

            //}

            //for (int i = 0; i < arrayB.Length; i++)
            //{
            //    Console.WriteLine(arrayB[i] + " ");
            //    Console.ReadKey();
            //}



            //Random _value = new Random();
            //for (int i = 0; i < arrayA.Length; i++) 
            //{

            //   arrayA[i] = _value.Next(0, 10);
            //   Console.WriteLine(arrayA[i] + " ");
            //}




            //// 변수 a와 b의 값을 바꾸시오 

            //int a = 10;
            //int b = 20;

            //// 바꾸는 공간을 만든다.
            //int temp;
            //temp = a;
            //a = b;
            //b = temp;

            //Console.ReadKey();






            //List<int> listA = new List<int>();

            //Random random = new Random();

            //int _rend = 371237;
            //Console.WriteLine(_rend % 10);
            //Console.ReadLine();


            //for ( int i = 0; i < 100; i++ )
            //{
            //    int _value = random.Next(0, 10);
            //    Console.WriteLine(_value);

            //}

            //int _dropGold = 100; // 10 ~ 200

            // Console.ReadKey();  
            #endregion



          

            // int[] arrayA +int[] arrayB 배열 합치기
            int[] arrayA = new int[10];
            int[] arrayB = new int[10];

            int[] arrayResult = new int[arrayA.Length + arrayB.Length];
            for (int i = 0; i < arrayA.Length; i++)
            //for (int i = 0; i < 10; i++)
            {
                arrayA[i] = i;
                arrayB[i] = i + 10;


            }


            for (int i = 0; i < arrayA.Length; i++)
                arrayResult[i] = arrayA[i];

            for (int i = 0; i < arrayB.Length; i++)
                arrayResult[arrayA.Length + 1] = arrayB[i];

            for (int i = 0; i < arrayResult.Length; i++)

                Console.Write(arrayResult[i] + " ");
                Console.ReadKey();

            // int[] arrayA int[] arrayB 배열 나누기

            int _length = arrayResult.Length / 2;
            int[] arrayResultA = new int[_length];
            int[] arrayResultB = new int[_length];

            for (int i = 0; i < _length; i++)
            {
                arrayResultA[0] = arrayResult[i];
                arrayResultB[0] = arrayResult[_length + i];
            }

            for (int i = 0; i < arrayResultA.Length; i++)
            {
                Console.WriteLine(arrayResultA[i] + " ");
                Console.WriteLine(arrayResultB[i] + " ");
            }
                





            //Random rand = new Random();
            //for (int i = 0; i <= 10; i++)
            //{
            //    int result = rand.Next(0, 10);
            //    char temp = arrayC[0];
            //    arrayC[0] = arrayC[result];
            //    arrayC[result] = temp;
            //}


            //string str = "";
            //for (int i = 0; i < arrayC.Length; i++)
            //    str += arrayC[i];



        }


    }

}

