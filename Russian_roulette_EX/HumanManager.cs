using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


public class HumanManager
{
    private List<Human> m_humanList = new List<Human>();
    private int m_curTurn;
    public int CurTurn { get { return m_curTurn; } }

    private int m_curShot;
    public int CurShot { get { return m_curShot; } set { m_curShot = value; } }

    public HumanManager(int _count = 2)
    {
        m_humanList.Add(new Human("플레이어", 1, true));
        for (int i = 1; i < _count; i++)
            m_humanList.Add(new Human("AI_" + i.ToString(), 1, false));
    }

    public Human GetHumanData(int _index)
    {
        if (0 <= _index && _index < m_humanList.Count)
            return m_humanList[_index];
        else
        {
            Console.WriteLine($"입력 하신 index : {_index} 가 범위를 벗어났습니다. 그래서 null 리턴합니다.");
            return null;
        }
    }

    public void Shffle_Human()
    {
        //사람을 섞어 주세요. - 저 순서가 섞인다
        Random rand = new Random();
        int count = m_humanList.Count;
        for (int i = 0; i < count; i++)
        {
            int result = rand.Next(0, count);
            Human temp = m_humanList[i];
            m_humanList[i] = m_humanList[result];
            m_humanList[result] = temp;
        }
    }


    public bool GetCurHumanIsCont()
    {
        return m_humanList[m_curTurn].IsControl;
    }
    public bool GetCurHumanIsCont(int _index)
    {
        return m_humanList[_index].IsControl;
    }

    public void ShowHumanInfo()
    {

        for (int i = 0; i < m_humanList.Count; i++)
        {
            //string life = "";
            //if (m_humanList[i].IsLife())
            //    life = "O";
            //else
            //    life = "X";
            // 위의 구조와 아래의 구조는 같다.
            string temp = m_humanList[i].IsLife() ? "○" : "X";
            Console.WriteLine($"{m_humanList[i].Name} 생존유무 : {temp}");
        }
    }

    public void ShowPlayerTurnInfo()
    {
        Console.WriteLine();
        string name = m_humanList[m_curTurn].Name;
        Console.WriteLine($"{name}의 차례입니다.");
        Console.WriteLine("Q : 발사");
        Console.WriteLine("W : 턴 넘기기");
    }

    public void NextTurn()
    {
        int count = m_humanList.Count;
        m_curTurn++;
        if (m_curTurn == count)
            m_curTurn = 0;

        CurShot = 0;


        Console.WriteLine($"턴을 넘겼습니다.");
        Console.WriteLine($"{m_humanList[m_curTurn].Name}의 차례입니다.");
    }


}