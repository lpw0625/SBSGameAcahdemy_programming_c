using MyList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SturctureEX
{
    internal class Program
    {
        static void Main(string[] args)


        //listA.Add(i); // 리스트에 자료형에 맞게 추가 
        //listA.Insert(0, i); // 원하는 위치에 Add
        //listA.Remove(0); // 해당 값의 자료형을 지울때 사용
        //listA.RemoveAt(3); // 몇 번째 인덱스에 있는 자료형을 제거
        //listA.Sort(); // 내부에서 데이터를 정렬해준다.                                                                                                                                                                                                                                                                                                                                                                                                                    
        //listA.Clear(); // 외부에서 비워준다.

        {

            List<int> listA = new List<int>();
            for (int i = 0; i < 10; i++)
                listA.Add(i);
            listA.Insert(5, -20);
            listA.Remove(3);
            listA.RemoveAt(5);

            for (int i = 0; i < listA.Count; i++)
                Console.Write(listA[i] + " ");

            Console.WriteLine();
            Console.WriteLine($"listA.Count : {listA.Count}   listA.Capacity : {listA.Capacity}");


            MyList<double> myList = new MyList<double>();
            for (int i = 0; i < 10; i++)
                myList.Add(i);
            myList.Insert(5, -20);
            myList.Remove(3);
            myList.RemoveAt(5);

            for (int i = 0; i < myList.Count; i++)
                Console.Write(myList.array[i] + " ");

            Console.WriteLine();
            Console.WriteLine($"myList.Count : {myList.Count}   myList.Capacity : {myList.Capacity}");


            Console.ReadKey();

        }
    }
}

