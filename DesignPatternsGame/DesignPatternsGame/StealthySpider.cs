using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesignPatternsGame
{
    public class StealthySpider: Monster
    {
        public StealthySpider()
        {
            Name = "Stealthy Spider";
            TotalHP = 40;
            HP = TotalHP;
            Speed = 20;
            MaxDamage = 35;
            MinDamage = 20;
            HitChance = 85;
            Defense = 1;
            img = ImageFactory.findImage("spider");
            special = new ExtraStrengthSpecial();
        }
    }
}
