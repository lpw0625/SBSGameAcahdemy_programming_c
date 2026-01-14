using System;
using System.Collections.Generic;

namespace RussianRoulette
{
    public class Cylinder
    {
        // 실제 총알(Bullet 객체)들이 담길 리스트입니다. 
        // null이면 빈 칸, Bullet 객체가 있으면 총알이 들어있는 것으로 간주합니다.
        private List<Bullet> m_cylinders = new List<Bullet>();

        // 현재 공이(공이치기)가 위치한 약실의 번호(인덱스)입니다.
        private int currentChamber = 0;

        // 외부에서 현재 총 약실이 몇 칸인지 확인할 수 있는 프로퍼티입니다.
        public int Size
        { get { return m_cylinders.Count; } }

        // [약실 초기화] 입력받은 size만큼 빈 칸(null)을 생성합니다.
        public void SetSize(int size)
        {
            m_cylinders.Clear(); // 기존 약실 정보를 비웁니다.
            for (int i = 0; i < size; i++)
            {
                m_cylinders.Add(null); // 설정된 개수만큼 빈 공간을 만듭니다.
            }
        }

        // [총알 장전] 특정 위치(index)에 원하는 총알(_bullet)을 넣습니다.
        public void LoadBullet(int index, Bullet _bullet)
        {
            // 인덱스가 약실 범위 안인지 확인하여 안전하게 장전합니다.
            if (index >= 0 && index < m_cylinders.Count)
                m_cylinders[index] = _bullet;
        }

        // [방아쇠 당기기] 현재 칸의 결과를 반환하고 다음 칸으로 이동합니다.
        public Bullet PullTrigger()
        {
            // 1. 현재 커서 위치에 있는 총알 정보를 가져옵니다. (없으면 null)
            Bullet fireBullet = m_cylinders[currentChamber];

            // 2. 발사 시도 후에는 해당 칸을 비웁니다. (일회성 발사 로직)
            m_cylinders[currentChamber] = null;

            // 3. 중요: 다음 방아쇠를 위해 커서를 한 칸 옮깁니다.
            // % 연산자를 사용해 마지막 칸 다음에 다시 0번 칸으로 돌아오게 만듭니다 (원형 구조).
            currentChamber = (currentChamber + 1) % m_cylinders.Count;

            // 4. 발사된 총알 객체를 반환합니다 (이걸로 데미지를 계산하게 됩니다).
            return fireBullet;
        }

        // [약실 회전] 리스트의 순서를 무작위로 섞는 기능을 구현할 위치입니다.
        public void Shuffle()
        {
            // 여기에 Random 객체를 사용해 m_cylinders 리스트를 섞는 로직이 들어갈 예정입니다.
        }
    }
}