using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_Ex
{

    public enum Map
    {
        start,
        town,
        river
    }

    public class StageMap
    {
        public int[,] m_seat; 
    }

    
    public class Worldmap
    {

        Dictionary<Map, StageMap> m_dicMap = new Dictionary<Map, StageMap>();



        private int[,] m_startMap;
        private int[,] m_townMap;
        private int[,] m_riverMap;
        public Worldmap() 
        {
            InitMap();
        }
         
        private void InitMap()
        {
            StageMap startMap = new StageMap();
            StageMap townMap = new StageMap();
            StageMap riverMap = new StageMap(); 
            startMap.m_seat = new int[,]
            {
            
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };

            townMap.m_seat = new int[,]
                {
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 1, 0, 0, 0},
                { 0, 0, 0, 0, 1, 0, 0, 0},
            };

            riverMap.m_seat = new int[,]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 1, 0, 0, 0},
                { 0, 0, 0, 0, 1, 0, 0, 0},
            };


            m_dicMap.Add(Map.start, startMap);
            m_dicMap.Add(Map.town, townMap);
            m_dicMap.Add(Map.river, riverMap);


        }

        private int[,] GetMap(Map _map)
        {
            StageMap getMap;
            if  (m_dicMap.TryGetValue(_map, out getMap));
            {
                if (m_dicMap.ContainsKey(_map))
                {
             
                    m_dicMap.TryGetValue(_map, out getMap);
                    return getMap.m_seat;
                }
                // 맵을 제대로 전달 하지 못하는 경우 
                return null;
            }

        }

        #region 
        //switch (_map)
        //{
        //    case Map.start:
        //        return m_startMap;


        //    case Map.town:
        //        return m_townMap;


        //    case Map.river:
        //        return m_riverMap;


        //    default:
        //        Console.WriteLine("맵 전달 실패 초기맵으로");
        //        return m_startMap;
        //}

        #endregion


        public void ShowScreenMap(Map _map)
        {
            int[,] curMap = GetMap(_map);
            for(int y = 0; y < curMap.GetLength(0); y++)
            {
                for (int x = 0; x < curMap.GetLength(1); x++)
                {
                    if (curMap[y, x] == 0)
                    Console.Write("'");
                    else if (curMap[y, x] == 1)
                        Console.Write("+");

                }
                Console.WriteLine();
            }

        }

    }
}
