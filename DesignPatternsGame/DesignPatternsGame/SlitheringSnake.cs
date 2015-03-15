using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesignPatternsGame
{
    public class SlitheringSnake: Monster
    {
        public SlitheringSnake()
        {
            Name = "Slithering Snake";
            TotalHP = 50;
            HP = TotalHP;
            Speed = 35;
            MaxDamage = 45;
            MinDamage = 20;
            HitChance = 90;
            Defense = 1;
            img = ImageFactory.findImage("snake");
            special = new ExtraStrengthSpecial();
        }
    }
}
