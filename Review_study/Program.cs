using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Review_study
{


    public class Program
    {
        //    static int abc; // 정적 변수 (어디에서든 사용 가능하다.)

        //    int m_TE; // 맴버변수 (객체변수 안에서 사용 가능)
        static void Main(string[] args) // 매개변수[매서드 내부]
        {
            #region
            // 내가 입력한 숫자의 크기 만큼
            /// ㅁㅁㅁㅁㅁㅁㅁ
            /// ㅁㅁㅁㅁㅁㅁㅁ
            /// ㅁㅁㅁㅁㅁㅁㅁ
            /// ㅁㅁㅁㅁㅁㅁㅁ
            // 건물 모양 나오게 하기
            // 대신 가로길이도 조절 가능하게 
            // 입력받은 수만큼
            // 한번 입력으로.
            // 11, 12

            //int a; // 지역변수 (메서드 안에서 사용 가능하다.)                     

            //Program A = new Program(); 



            //Console.WriteLine("케인 코는 뭉탱이");
            //Console.ReadKey();
            //Building();


            //Console.ReadLine();
            #endregion

            //Building();
            //TriAngle();

            string str_1 = Console.ReadLine();

            reversetriangle(str);

        }



        static void reversetriangle(string str_1)
        {
            int height = 0;
            if (!int. TryParse(Console.ReadLine(), out height))
                Console.WriteLine("파싱 실패");

            int spaceCount = 0;
            for (int i = 9; i >= 0; i--)
            {

                for (int j = 0; j < spaceCount; j++)
                    Console.Write(" ");
                for (int j = 0; j <= i; j++)
                    Console.Write("▽");

                Console.Write("▽");
                spaceCount++;
            }
            Console.ReadKey();


        }


   
     }

            
                
    


            
}

   


        #region 내가한거
        //static void TriAngle()
        //{
        //    //    Console.WriteLine("피라미드의 높이를 입력해주세여");

        //    //    int height = int.Parse(Console.ReadLine()); // 이런 방식은 방어코드가 없기 때문에 안좋은 코드 방식
        //    //    Console.WriteLine("피라미드의 너비를 입력해주세요");
        //    //    int width = int.Parse(Console.ReadLine()); // // 이런 방식은 방어코드가 없기 때문에 안좋은 코드 방식
        //    //    string strTriAngele = "";
        //    //    string strSpaceBar = "";


        //    //    int index = 0;
        //    //    while (index < height)
        //    //    {
        //    //        strSpaceBar = "";
        //    //        strTriAngele = "";

        //    //        for (int i = 0; i < index - height - 1; i++)
        //    //        {
        //    //            strSpaceBar += " ";
        //    //        }

        //    //        if (index == 0)
        //    //        {
        //    //            strTriAngele = "△";
        //    //        }
        //    //        else
        //    //        {

        //    //            for (int i = 0; i < (index * width) + 1; i++)
        //    //            {
        //    //                strTriAngele += "△";
        //    //            }

        //    //        }
        //    //        Console.WriteLine(strSpaceBar + strTriAngele);
        //    //        index++;

        //    //    }

        //    //    Console.ReadKey();
        //    //}
        //}
        #endregion



        


#region
        //static void Building()
        //{
        //    Console.ReadLine();

        //    Console.WriteLine("수를 입력하세요");
        //    string str = Console.ReadLine();
        //    string str_width = "";
        //    string str_height = "";

        //    int index = 0;

        //    for (int i = 0; i < index; i++)
        //    {
        //        index = str[i];
        //        break;
        //    }


        //    for (int i = index; i < str.Length; i++)

        //        str_width += str[i];

        //    for (int i = index; i < str.Length; i++)

        //        str_height += str[i];

        //    Console.WriteLine("ㅁ");

        //    Console.ReadKey();
        //}
        #endregion






        #region
        //    static void Building()
        //    {

        //        Console.ReadLine();
        //        string[] str = Console.ReadLine().Split(' ');
        //        #region
        //        //string str = Console.ReadLine();
        //        //string str_width = "";
        //        //string str_height = "";


        //        //int index = 0;
        //        //for (int i = 0; i < str.Length; i++)
        //        //{
        //        //    if (str[i] == ' ')
        //        //    {
        //        //        index = 1;
        //        //        break;
        //        //    }


        //        // }
        //        //for (int i = 0; i < index; i++)  
        //        //    str_width += str[i];
        //        //for (int i = index; i < str.Length; i++)
        //        //    str_width += str[i];
        //        #endregion
        //        int width = 0;
        //        int height = 0;

        //        if (int.TryParse(str[0], out width) == false || int.TryParse(str[1], out height) == false)
        //            Console.WriteLine("파싱 실패.");


        //        for (int y = 0; y < height; y++)
        //        {

        //            for (int x = 0; x < width; x++)
        //            {
        //                Console.Write("ㅁ");
        //            }
        //            Console.WriteLine();
        //        }



        //        Console.Write("가로 길이 입력");
        //        string str = Console.ReadLine();
        //        //int height = int.TryParse(str);///Convert.ToInt32(str);
        //        int width = 0;
        //        if (int.TryParse(str, out width) == false)
        //            Console.WriteLine("파싱 실패");


        //        Console.Write("세로 길이 입력");
        //        str = Console.ReadLine();
        //        int height = 0;
        //        // 파싱이 되면 true 그렇지 않으면 false를 내뱉는다.
        //        if (int.TryParse(str, out height) == false)
        //            Console.WriteLine("파싱 실패.");

        //        str = "";
        //        for (int y = 0; y < width; y++)
        //            str += "ㅁ";
        //        for (int y = 0; y <= height; y++)
        //            Console.WriteLine(str);

        //        for (int i = 0; i < height; i++)
        //        {

        //            for (int j = 0; j < width; j++)
        //            {

        //                Console.Write("ㅁ");

        //            }
        //            Console.WriteLine();

        //        }

        //        Console.ReadKey();

        //    }
        //}

#endregion










