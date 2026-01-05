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

             WorldMap map = new WorldMap(Map.start);

    
            while (true) 
            {
                Console.Clear();
                map.ShowScreenMap(playWarrior);
                playWarrior.ShowStatus();
                playWarrior.InputMove(Console.ReadKey, map.GetCurMapSize(0), map.GetCurMapSize(0));




            }


            }
        }
    }



/*
 * 맵만들기
 * 캐릭터 클래스
 *완 - 수정할 수 있음
 *
 *
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
