using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesignPatternsGame
{
    public class ChubbyChipmunk: Hero
    {
        public ChubbyChipmunk()
        {
            Name = "Chubby Chipmunk";
            TotalHP = 130;
            HP = TotalHP;
            Speed = 30;
            MaxDamage = 40;
            MinDamage = 20;
            HitChance = 90;
            Defense = 4;
            img = ImageFactory.findImage("chipmunk");
        }

        public override void useSpecial(GameCharacter target)
        {
            throw new NotImplementedException();
        }
    }
}
