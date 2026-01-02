using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_Ex
{
    internal class Unit
    {
        protected string m_name;
        public string Name { get { return m_name; } }


        protected int m_level;
        public int Level { get { return m_level; } }


        private int[] m_requireExp = new int[] 
        
        { 100, 200, 300, 500, 1000 };

        protected int m_exp;
        public int Exp { get { return m_exp; } }

        protected double m_expPersentage => ((double)m_exp / m_requireExp[Level]) * 100;

        protected int m_hp;
        public int Hp { get { return m_hp; } }


        protected int m_mp;
        public int Mp { get { return m_mp; } }


        protected int m_atkValue;
        public int AtkValue { get { return m_atkValue; } }


        protected int m_defValue;
        public int DefValue { get { return m_defValue; } }


        protected int m_gold;
        public int Gold { get { return m_gold; } }

    }
}
