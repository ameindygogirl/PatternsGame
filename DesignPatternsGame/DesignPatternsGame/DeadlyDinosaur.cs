using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesignPatternsGame
{
    public class DeadlyDinosaur: Monster
    {
        public DeadlyDinosaur()
        {
            Name = "Deadly Dinosaur";
            TotalHP = 100;
            HP = TotalHP;
            Speed = 10;
            MaxDamage = 50;
            MinDamage = 30;
            HitChance = 70;
            Defense = 5;
            img = ImageFactory.findImage("dinosaur");
        }
        
        public override void useSpecial(GameCharacter target)
        {
            throw new NotImplementedException();
        }
    }
}
