using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette
{

    public enum BulletType
    {
        normal, // 데미지 1
        blankBullet, // 데미지 2배
        Critical // 데미지 0

    }

    public class Bullet
    {
        public int Damage
        {
            get; private set;
        }
       public BulletType Type { get; private set; }

        public Bullet(BulletType _type)
        {
            Type = _type;

           switch(_type) 
            { 
                case BulletType.normal:
                    Damage = 1; 
                    
                    break;
                case BulletType.blankBullet:
                    Damage = 0;
                    break;

                case BulletType.Critical:
                    Damage = 2;
                    break;

            
            }

        }
    }
}
