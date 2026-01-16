using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public enum bulletType
{
    normal = 0,
    cri,
    blank
}

public class Bullet
{
    private int m_attack;
    public int Attack { get { return m_attack; } }


    public Bullet()
    {
        m_attack = 1;
        m_bulletType = bulletType.normal;
    }


    private bulletType m_bulletType;

    public bulletType GetBulletType()
    {
        return m_bulletType;
    }

}

/*
    보통 총알
    강한 총알
    공포탄
 */