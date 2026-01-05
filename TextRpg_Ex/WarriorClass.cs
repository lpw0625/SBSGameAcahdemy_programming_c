using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_Ex
{
    internal class WarriorClass : Unit
    {

     
        public WarriorClass(string _name, int _level, int _atk, int _def, int _gold = 300) 
        { 
            m_name = _name;
            m_level = 5;
            m_atkValue = _atk;
            m_defValue = _def;
            m_exp = 10;
            m_hp = 100;
            m_mp = 30;
            m_gold = _gold;
            CurX = 1;
            CurY = 1;

        
        
        }
       

    }
}
