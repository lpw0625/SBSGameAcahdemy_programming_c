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
        river,
    }

    public class StageMap
    {
        public int[,] m_seat;
    }

    public class WorldMap
    {
        private Dictionary<Map, StageMap> m_dicMap = new Dictionary<Map, StageMap>();
        private Map m_curMap;
        private StageMap m_curStageMap;
        public WorldMap(Map _map)
        {
            InitMap(_map);
        }

        private void InitMap(Map _map = Map.start)
        {
            StageMap startMap = new StageMap();
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
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                };
            StageMap townMap = new StageMap();
            townMap.m_seat = new int[,]
                {
                {0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0 },
                };
            StageMap riverMap = new StageMap();
            riverMap.m_seat = new int[,]
                {
                {0, 0, 0, 1, 1, 0, 0, 0 },
                {0, 0, 0, 1, 1, 0, 0, 0 },
                {0, 0, 0, 1, 1, 0, 0, 0 },
                {0, 0, 0, 1, 1, 0, 0, 0 },
                {0, 0, 0, 1, 1, 0, 0, 0 },
                {0, 0, 0, 1, 1, 0, 0, 0 },
                {0, 0, 0, 1, 1, 0, 0, 0 },
                {0, 0, 0, 1, 1, 0, 0, 0 },
                };

            m_dicMap.Add(Map.start, startMap);
            m_dicMap.Add(Map.town, townMap);
            m_dicMap.Add(Map.river, riverMap);

            SetCurMap(_map);
          
        }

        private void SetCurMap(Map _map)
        {
            if (!m_dicMap.TryGetValue(_map, out m_curStageMap))
            {
                m_curMap = _map;
            }

            else
            {
                Console.WriteLine("처음 초기화 하는 부분에서 맵을 가져오다가 실패하였습니다.");
            }
        }

        private int[,] GetMap(Map _map)
        {
            StageMap getMap;
            if (m_dicMap.TryGetValue(_map, out getMap))
                return getMap.m_seat;

            // 맵을 제대로 전달 하지못한경우.
            return null;
        }

        public void ShowScreenMap(Unit _player)
        {
            int[,] curMap = m_curStageMap.m_seat;
            for (int y = 0; y < curMap.GetLength(0); y++)
            {
                for (int x = 0; x < curMap.GetLength(1); x++)
                {
                    // 플레이어의 위치를 표시
                    if (_player.CurX == x && _player.CurY == y)
                        Console.Write("P");

                    // 움직일수 있는 좌표를 표시
                    else if (curMap[y, x] == 0)
                        Console.Write("'");

                    // 움직일수 없는 벽을 좌표로 표시
                    else if (curMap[y, x] == 1)
                        Console.Write("+");

                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        /*
         * 현재 맵 사이즈를 가져오는 매서드 
         * 
         * 0과 1만 넣으세요
         */
        public int GetCurMapSize(int dimension)
        {
            return m_curStageMap.m_seat.GetLength(dimension);
        }

    }
}
