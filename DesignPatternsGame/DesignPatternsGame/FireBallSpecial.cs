﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class FireBallSpecial : SpecialAction
    {
        public FireBallSpecial() : base("Fireball") { }

        public override void execute()
        {
            dmg = new Random().Next(primary.MaxDamage, primary.MaxDamage * 2);
            target.subtractHP(dmg);
        }
        public override String toString()
        {
            return primary.Name + " hurls a fireball at " + target.Name + " for " + dmg + " damage!";
        }
    }
}
