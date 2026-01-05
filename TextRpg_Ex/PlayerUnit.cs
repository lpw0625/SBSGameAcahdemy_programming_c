using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_Ex
{
    public class PlayerUnit : Unit, IMoveController
    {

        private int[,] dirs = new int[,]
        {
            { 0 , -1}, // 위
            { 0 ,  1}, // 아래 
            {-1 ,  0}, // 왼쪽
            { 1,   0} // 오른쪽
        };
        public void InputMove(ConsoleKeyInfo _keyInfo, int _sizeX, int _sizeY)
        {
            int dir = 0;
            switch (_keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                 
                    dir = 0;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                  
                    dir = 1;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                   
                    dir = 2;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    
                    dir = 3;
                    break;

                default:
                    return;
            }

            MoveFunc(dirs[dir, 0], dirs[dir, 1], _sizeX, _sizeY);
        }


        public void MoveFunc(int _dtx, int _dty, int _sizeX, int _sizeY)
        {
            CurX += _dtx;
            CurY += _dty;

            if (CurX < 0)
                CurX = 0;
            else if (CurX >= _sizeX)
                CurX = _sizeX - 1;

            if (CurY < 0)
                CurY = 0;
            else if (CurY >= _sizeY)
                CurY = _sizeY - 1;
        }

     
    }
}
