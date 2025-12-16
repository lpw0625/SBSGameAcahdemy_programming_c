using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayEx
{
    public partial class Monster : UnitParent
    {

        public void Damaged(UnitParent attacker)

        {

            int _att = attacker.GetAtt();
            Console.WriteLine( "attacker : " + _att);
        }

    }
}