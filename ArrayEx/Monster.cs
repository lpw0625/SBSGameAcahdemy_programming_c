using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayEx
{
    public partial class Monster : UnitParent // UnitParent라는 부모 클래스 특성을 물려 받음 .
    {



        // 프로퍼티 - 편의성을 위한것 - Set,Get 메서드와 같다라고 봐도 된다.
        // 생략된 int Hp가 접근하는 같은 자료형이 만들어진다.

     // ===============================================================================

        //역할: Monster 객체의 이름(Name)에 접근하는 공식 통로입니다.

        //작동 방식: get은 이름을 읽어올 때, set은 이름을 설정할 때 사용됩니다.
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        // ===============================================================================

        //생략된 int Hp가 접근하는 같은 자료형이 만들어진다: 이것은 Hp를 자동 구현 프로퍼티로 선언했을 때(예: public int Hp { get; set; }) 

        //C# 컴파일러가 자동으로 내부 필드를 만들어준다는 개념을 언급한 것으로 보입니다. (현재 코드에는 Hp 프로퍼티 대신 SetHp/GetHp 메서드가 사용되었습니다.)


        public void SetHp(int _hp)
        {
            hp = _hp; // Monster 객체의 체력(hp)을 설정하는 메서드입니다. 외부에서 전달받은 값(_hp)을 내부 변수 hp에 할당합니다. (void는 반환 값이 없음을 의미)
        }
        public int GetHp()
        {
            return hp; // Monster 객체의 현재 체력(hp) 값을 외부로 반환하는 메서드입니다.
        }


        public void Dance()
        {
            Console.WriteLine("춤을 엄청 잘춥니다.");
        }


    }
}
