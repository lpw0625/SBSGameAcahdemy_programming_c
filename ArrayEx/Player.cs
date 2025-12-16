using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayEx
{
    public class Player : UnitParent
    {

        public int SpecialAttack = 10000; // public 필드는 관행상 소문자로 시작하지 않지만, 일단 이대로 둡니다.

        public override int GetSpecialAttack()
        {
            // 필드 이름과 동일하게 대문자로 시작하도록 수정
            return att * SpecialAttack;
        }

        public virtual int GetAtt()
        {
            return att;
        }
    }
}