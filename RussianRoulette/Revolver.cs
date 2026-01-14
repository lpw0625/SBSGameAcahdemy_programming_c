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

        public Revolver(int cylinderSize)
        {
            cylinder = new Cylinder();
            cylinder.SetSize(cylinderSize);
        }

        public void AddBullet(int index, BulletType _bulletType)
        {
            cylinder.LoadBullet(index, new Bullet(_bulletType));    
        }
    }
}
