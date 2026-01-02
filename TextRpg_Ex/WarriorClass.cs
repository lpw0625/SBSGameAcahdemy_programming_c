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
        
        
        }
         public void ShowClassStatus()
        {
        
            Console.WriteLine("※====================================※");
            Console.WriteLine("[플레이어 스테이터스 창]");
            Console.WriteLine($"플레이어 이름 : {Name}"  );
            Console.WriteLine($"레벨          : {Level}");
            Console.WriteLine($"필요 경험치      : {m_expPersentage}");
            Console.WriteLine($"공격력        : {AtkValue}");
            Console.WriteLine($"방어력        : {DefValue}");
            Console.WriteLine($"골드          : {Gold}");
            Console.WriteLine("※====================================※");


        }


    }
}
