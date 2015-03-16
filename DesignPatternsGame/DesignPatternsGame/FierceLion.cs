using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesignPatternsGame
{
    public class FierceLion: Monster
    {
        public FierceLion()
        {
            Name = "Fierce Lion";
            TotalHP = 90;
            HP = TotalHP;
            Speed = 35;
            MaxDamage = 50;
            MinDamage = 30;
            HitChance = 90;
            Defense = 3;
            img = ImageFactory.findImage("lion");
            special = new LionSpecial();
        }
    }
}
