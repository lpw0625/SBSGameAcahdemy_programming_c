using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette
{
    public class Revolver
    {
        public Cylinder cylinder
        {
            get; private set;
        }

        private int FirstSelectBulletCount;

        public Revolver(int cylinderSize)
        {
            cylinder = new Cylinder();
            cylinder.SetSize(cylinderSize);
        }

        public void FirstSelectSetUp(int bulletCount)
        {
            FirstSelectBulletCount = bulletCount;
            
        }

        public void Reload()
        {
            cylinder.SetSize(cylinder.Size);

           for (int i = 0; i < FirstSelectBulletCount; i++) 
            {

                cylinder.LoadBullet(i, new Bullet(BulletType.normal));
            
            }

           cylinder.Shuffle();

            Console.WriteLine($"\n[시스템] 실탄 {FirstSelectBulletCount}발을 새로 장전하고 탄창을 회전시켰습니다.");
        }

        public void AddBullet(int index, BulletType _bulletType)
        {
            cylinder.LoadBullet(index, new Bullet(_bulletType));    
        }
    }
}
