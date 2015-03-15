using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesignPatternsGame
{
    public class FuzzyPuppy : Hero
    {
        public FuzzyPuppy()
        {
            Name = "Fuzzy Puppy";
            TotalHP = 150;
            HP = TotalHP;
            Speed = 20;
            MaxDamage = 60;
            MinDamage = 30;
            HitChance = 80;
            Defense = 6;
            img = ImageFactory.findImage("dog");
        }
        
        public override void useSpecial(GameCharacter target)
        {
            throw new NotImplementedException();
        }
    }
}
