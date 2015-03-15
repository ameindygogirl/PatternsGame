using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class GaoGaiGarRobot : RobotDecorator
    {

        public GaoGaiGarRobot(GameCharacter pilot) : base(pilot)
        {
            this.name = "GaoGaiGar pilot " + pilot.Name;
            this.TotalHP = 70 + pilot.TotalHP;
            this.HP = this.TotalHP;
            this.Speed = 10 + pilot.TotalHP;
            this.MaxDamage = 25 + pilot.MaxDamage;
            this.MinDamage = 10 + pilot.MinDamage;
            this.HitChance = 0.8 * pilot.HitChance;
            this.Defense = 10 + pilot.Defense;
            this.img = ImageFactory.findImage("gaogaigar");
        }
    }
}
