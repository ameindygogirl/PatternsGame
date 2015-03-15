using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class Unit01Robot : RobotDecorator
    {

        public Unit01Robot(GameCharacter pilot) : base(pilot)
        {
            this.name = "Unit01 pilot " + pilot.Name;
            this.TotalHP = 55 + pilot.TotalHP;
            this.HP = this.TotalHP;
            this.Speed = 20 + pilot.TotalHP;
            this.MaxDamage = 15 + pilot.MaxDamage;
            this.MinDamage = 10 + pilot.MinDamage;
            this.HitChance = 0.7 * pilot.HitChance;
            this.Defense = 9 + pilot.Defense;
            this.img = ImageFactory.findImage("unit01");
        }
    }
}
