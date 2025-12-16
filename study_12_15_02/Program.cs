using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



public static class FishBreadTool
{
    public static int bell;
    //클래스 자체에서 사용하는 메서드
    public static void BellFunc()
    {
    }
}

public class Monster
{
    public int testA;
    private int testB;
    public void TestFunc()
    {
        Console.WriteLine("호출시 출력");
    }
}

namespace TestReview2
{
    public enum Season
    {
        spring,
        summer,
        fall,
        winter
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            int c = 30;
            int d = 40;
            int result = 50; ;


            string str = "";
            string spaceStr = "";


            int i = 0;
            for (i = 0; i < 10; i++)
            {
                for (int j = 10; i < j; j--)
                    spaceStr += " ";
                str += "△";
                Console.WriteLine(spaceStr + str);
                spaceStr = "";
            }
            i = 10;
            str = "";
            spaceStr = "";
            while (0 <= i--)
            {
                int k = 0;
                while (k++ <= i)
                    str += "▽";

                int j = 10;
                while (i < j--)
                    spaceStr += " ";
                Console.WriteLine(spaceStr + str);
                str = "";
                spaceStr = "";
            }




            Console.ReadLine();
        }
    }
}
