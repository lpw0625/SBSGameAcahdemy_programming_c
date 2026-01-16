using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Breech
{
    private Bullet m_bullet;

    public void SetBullet(Bullet _bullet)
    {
        m_bullet = _bullet;
    }
    public Bullet GetBullet()
    {
        return m_bullet;
    }
    public int Shot()
    {
        int attack = m_bullet.Attack;
        m_bullet = null;
        return attack;
    }


}