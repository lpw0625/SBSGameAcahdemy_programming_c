using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg_study
{
    public class Warrior : PlayerUnit
    {
        public Warrior(string _playerName, int _playerLv, int _Atk, int _Def, int _y, int _x, int _gold, int _Mp, int _Exp)
        {
            m_name = _playerName;
            m_lv = _playerLv;
            m_atk = _Atk;
            m_def = _Def;
            m_exp = 0;
            

        }

    }
}
