using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesignPatternsGame
{
    public class CuddlyKitten: Hero
    {
        public CuddlyKitten()
        {
            Name = "Cuddly Kitten";
            TotalHP = 140;
            HP = TotalHP;
            Speed = 30;
            MaxDamage = 40;
            MinDamage = 20;
            HitChance = 85;
            Defense = 2;
            img = ImageFactory.findImage("kitten");
        }

        public override void useSpecial(GameCharacter target)
        {
            throw new NotImplementedException();
        }
    }
}
