using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayEx
{
    public class UnitParent
    {
        protected int hp;
        protected string name;

        protected int att = 1;


        public void Dance()
        {
            Console.WriteLine("춤을춥니다.");
        }

        public int GetAtt()
        {
            return att;
        }

        public void Dameged(UnitParent attacker)
        {
            int _att = attacker.GetAtt();
            Console.WriteLine(" 적의 공격력 : " + _att);
        }
    }
}