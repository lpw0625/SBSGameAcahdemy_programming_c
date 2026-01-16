using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{



    static void GamePlaing(Revolver _revolver, HumanManager _humanManager)
    {
        Console.Clear();
        _humanManager.ShowHumanInfo();



        // 턴을 비교해서 누구 턴인지 확인하고
        // 그 턴인 사람이 내가 조종할수 있는 사람인지 아닌지 체크를한다.
        // Human IsControl 이 값이 true 인지 false 인지 
        if (_humanManager.GetCurHumanIsCont())
        {
            _humanManager.ShowPlayerTurnInfo();
            ConsoleKeyInfo keyinfo = Console.ReadKey();
            Console.WriteLine();
            if (keyinfo.Key == ConsoleKey.Q)
            {
                //여기서 진짜 총알이 나오면 체력이 깍여야 한다.
                int attack = _revolver.Shot();
                _humanManager.CurShot++;
                _humanManager.GetHumanData(_humanManager.CurTurn).Damaged(attack);
            }
            else if (keyinfo.Key == ConsoleKey.W)
            {
                // 턴 넘기는 메서드를 만들어 주시고 - (메서드 생성)
                // 방아쇠를 당기기 전까지는 턴을 넘길수없게 - 조건
                if (_humanManager.CurShot == 0)
                    Console.WriteLine("일단 쏘세요.");
                else
                    _humanManager.NextTurn();
            }
            EnterPlease();
        }
        else
        {
            AutoPlay(_revolver, _humanManager);
        }

        // 내가 죽으면 or 누군가가 죽었을때
        // 어떻게 처리해야하는지를 
        // 즉, human.islife()가 true false 냐에 따라 분기를 나눠야한다.
    }


    /// <summary>
    /// AI의 행동
    /// 기본적으로 우리가 하는 행동과 비슷하거나 같아야된다.
    /// 트리거 당기기, 턴넘기기
    /// </summary>
    static void AutoPlay(Revolver _revolver, HumanManager _humanManager)
    {
        // 트리거를 당겨서 총을 쏜 다음에
        // 턴을 넘길수 있다.
        // 트리거를 몇 번 당길수 있으니 - 여러번 하는 로직이 들어갈수있다.
        // 먼저 한번트리거를 당기고 턴을 넘기는 것이 AutoPlay 들어가야한다.

        // 총을 한번도 안쐇기 때문에 반드시 쏴야한다.
        _humanManager.ShowPlayerTurnInfo();
        if (_humanManager.CurShot == 0)
        {
            _revolver.Shot();
            _humanManager.CurShot++;
        }
        else
        {
            _humanManager.NextTurn();
        }
        EnterPlease();
    }

    static void EnterPlease()
    {
        Console.WriteLine("계속 하려면 엔터를 누르세요.");
        Console.ReadLine();
    }


    /// <summary>
    /// 메서드를 호출 하는 역할
    /// </summary>
    static void Main()
    {
        Console.WriteLine("러시안 룰렛");
        HumanManager humanManager = new HumanManager();
        //humanManager.Shffle_Human();

        Revolver revolver = new Revolver();
        revolver.SetBulletAdd();
        revolver.Suffle();

        while (true)
        {
            GamePlaing(revolver, humanManager);
        }


        Console.ReadLine();
    }


}


/*
  
  무조건
 1. 클래스를 만드는것 
    - 총이 있어야한다.
    - 총관련 클래스가 있어야한다.
 2. 총 클래스를 만들었고 그 안에 기능이 있어야한다.
    - 약실
 3. 러시안 룰렛을 같이할 상대가 필요하다.
    - 간단한 인공지능 캐릭이 필요하다.(AI)
    - 클래스를 만들어야한다


*************** 처음 부터 끝까지 하려고 하지말것 ***************
***************  순차적으로 작업이 진행되여 함   ***************

    0. 러시아 룰렛
       - 6개의 약실 중에 1개만 총알이 들어가있다.
       - 총알 당겨서 죽고 안죽고 되게

    1. 약실을 플레이어가 초기에 늘릴 수 있다.
       - 약실 - 6 그냥 이런식으로 적용 X
       - 변수를 통행서 약실 갯수를 변형이 가능해야한다.
    여기까지 먼저 작업이 되고 넘어가는게 좋습니다.


    1. 내가 스스로 방아쇠를 당긴다음
       - 한번 더 당길지
       - 그냥 턴을 넘길지
    플레이어의 행동이 여러개.


    2. 총알을 여러개 넣는게 가능하게
       - 원래 정석은 6개의 약실에 총알 한발
       - 20개의 약실에 총알 여러 발
    총기 커스텀.


    3. 혼자서, 1:1, 여러명 가능하게
       - 여러명일 경우 - Ex) 5명
       - 총알이 발사됬을때 그때 한명이 die
       - 약실에 총알을 다시 넣고
       - 5명 -> 4명
       - 최후 생존자가 나올때까지 or 내가 죽을 때 까지
    여러명이서 하는 러시안룰렛 - 자료구조 사용 - 대표적인 List


    4. 러시아 룰렛인데
       - 플레이어만이 가질수 있는 라이프
       - 아이템 - 총알이 있는지 없는지 확인하기
       - 특정 ai는 라이프가 더 있다. 얘도 아이템을 쓴다.
    아이템 클래스를 만들어서 사용
    아이템을 관리하는 인벤토리 클래스가 필요


    6. 리팩토링
       - 코드 수정하기
       - 메인에서는 메서드를 호출하는 구조가 가장 좋음
       - 코드를 수정하기 좋은 구조가 좋음 (하나 고쳤을때 게임 전체에 영향이 가면 안좋음)
       - 가독성 있어야 좋음
       - 쪼개면 쪼갤수록 좋음


 */
