using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_Ex
{

    public interface IMoveController
    {
        void InputMove(ConsoleKeyInfo _keyInfo, int _sizeX, int _sizeY);
        void MoveFunc(int _drx, int _dry, int _sizeX, int _sizeY);
    }

    public class Unit
    {
        protected string m_name;
        public string Name { get { return m_name; } }

        protected int m_level;
        public int Lv { get { return m_level; } }


        private int[] m_requireExp = new int[]
            {
                0, 100, 200, 300, 500, 1000
            };
        protected int m_exp;
        public int Exp { get { return m_exp; } }
        protected double m_expPercentage => ((double)m_exp / m_requireExp[Lv]) * 100;


        protected int m_hp;
        public int Hp { get { return m_hp; } }
        protected int m_mp;
        public int Mp { get { return m_mp; } }

        protected int m_atkValue;
        public int AttValue { get { return m_atkValue; } }
        protected int m_defValue;
        public int DefValue { get { return m_defValue; } }

        protected int m_gold;
        public int Gold { get { return m_gold; } }

        public int CurX { get; set; }
        public int CurY { get; set; }


        public void ShowStatus()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"이름 : {Name}  lv : {Lv}  Exp : {m_expPercentage}%  {Exp}");
            Console.WriteLine($"HP : {Hp}  MP : {Mp}");
            Console.WriteLine($"공격력 : {AttValue}  방어력 : {DefValue}");
            Console.WriteLine($"골드 : {Gold}");
            Console.WriteLine("------------------------------------");
        }

    }





}
