using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Human
{
    private string m_name;
    public string Name { get { return m_name; } }

    private int m_hp;
    public int HP { get { return m_hp; } }

    private bool m_isControl = false;
    public bool IsControl { get { return m_isControl; } }


    public Human(string _name, int _hp, bool _isControl)
    {
        m_name = _name;
        m_hp = _hp;
        m_isControl = _isControl;
    }


    public bool IsLife()
    {
        return m_hp > 0;
    }

    public void Damaged(int _atk)
    {
        m_hp -= _atk;
    }


    //public bool IsDead()
    //{
    //    return m_hp <= 0;
    //}

}
