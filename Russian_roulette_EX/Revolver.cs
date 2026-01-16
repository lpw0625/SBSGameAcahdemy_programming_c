using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Revolver
{
    private Breech[] m_arrBreech;
    private int m_curBreechIndex;


    public Revolver(int _breechCount = 6)
    {
        // 약실의 갯수가 정해진다.
        // 지금 이것은 배열 크기만 만들어졌다.
        m_arrBreech = new Breech[_breechCount];

        // 실제 약실이 만들어 지는 부분
        for (int i = 0; i < _breechCount; i++)
            m_arrBreech[i] = new Breech();

        m_curBreechIndex = 0;
    }


    public void SetBulletAdd(int _count = 1)
    {
        m_arrBreech[0].SetBullet(new Bullet());
    }

    public void Suffle()
    {
        // 총알을 섞는 로직을 여기서 만들어주세요.
        // 총알이 여러개 있어도 잘 섞여야 한다.
        // 용어만 달라졌을 뿐이지 기존에 했던 것
        Random rand = new Random();
        m_curBreechIndex = rand.Next(0, m_arrBreech.Length);
    }

    public int Shot()
    {
        int attack = 0;
        if (m_arrBreech[m_curBreechIndex].GetBullet() == null)
        {
            Console.WriteLine("딸깍");
        }
        else
        {
            Console.WriteLine("탕");
            // 이거 같은거 아니에요??
            // 맞습니다 같은거
            // 그런데 메서드 이름이 달라요
            // 코드 설계이면서 이름이 달라요
            //m_arrBreech[m_curBreechIndex].SetBullet(null);
            //attack = m_arrBreech[m_curBreechIndex].GetBullet().Attack;
            attack = m_arrBreech[m_curBreechIndex].Shot();
        }
        ShotAndNextBreech();

        //여기서 리턴이 되어야한다.
        return attack;
    }

    private void ShotAndNextBreech()
    {
        // 다음으로 넘어가지만 
        // 약실보다 인덱스 값이 크면 안된다.
        // 코드를 짧게 쓰는것도 좋지만
        // 더 중요한 것은 가독성 있게 짜는게 좋다.
        int length = m_arrBreech.Length;
        m_curBreechIndex++;
        if (m_curBreechIndex == length)
            m_curBreechIndex = 0;
    }


    // 기획
    // 러시안 룰렛을 만들자.
    // 약실의 갯수 왜 안바껴??? - (큰일날 기획자)
    // 러시안 룰렛이지만 총알이 여러발 들어가면 좋겠어
    //
    //
    // (우리들 프로그래머가 생각해야 하는 부분)
    // 총알을 넣는것
    // 총알을 섞는것
    // 방아쇠를 당기는것

}