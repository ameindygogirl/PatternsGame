using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesignPatternsGame
{
    public class CrookedVulture: Monster
    {
        public CrookedVulture()
        {
            Name = "Crooked Vulture";
            TotalHP = 65;
            HP = TotalHP;
            Speed = 50;
            MaxDamage = 35;
            MinDamage = 15;
            HitChance = 90;
            Defense = 2;
            img = ImageFactory.findImage("vulture");
        }

        public override void useSpecial(GameCharacter target)
        {
            throw new NotImplementedException();
        }
    }
}
