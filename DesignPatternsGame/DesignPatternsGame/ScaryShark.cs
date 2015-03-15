using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesignPatternsGame
{
    public class ScaryShark: Monster
    {
        public ScaryShark()
        {
            Name = "Scary Shark";
            TotalHP = 80;
            HP = TotalHP;
            Speed = 30;
            MaxDamage = 60;
            MinDamage = 20;
            HitChance = 80;
            Defense = 3;
            img = ImageFactory.findImage("shark");
            special = new QuackSpecial();
        }
    }
}
