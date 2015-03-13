using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesignPatternsGame
{
    public class TinyTurtle: Hero
    {
        public TinyTurtle()
        {
            Name = "Tiny Turtle";
            TotalHP = 200;
            HP = TotalHP;
            Speed = 10;
            MaxDamage = 40;
            MinDamage = 30;
            HitChance = 80;
            Defense = 10;
            img = ImageFactory.findImage("turtle");
        }

        public override void useSpecial(GameCharacter target)
        {
            throw new NotImplementedException();
        }
    }
}
