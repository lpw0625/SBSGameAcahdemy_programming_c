using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_Ex
{

   

    internal class Program
    {
        static void Main(string[] args)
        {
            WarriorClass playWarrior = new WarriorClass("바바리안", 1, 10, 5);

            Worldmap map = new Worldmap();

    
            while (true) 
            {
                Console.Clear();
                map.ShowScreenMap(Map.start);
                playWarrior.ShowClassStatus();

                Console.ReadLine();



            }


            }
        }
    }



/*
 * 맵만들기
 * 캐릭터 클래스
 * 인벤토리
 * 아이템 만들기
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
