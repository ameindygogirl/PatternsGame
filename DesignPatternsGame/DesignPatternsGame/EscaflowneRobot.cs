using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class EscaflowneRobot : RobotDecorator
    {
        public EscaflowneRobot(GameCharacter pilot) : base(pilot)
        {
            this.name = "Escaflowne pilot " + pilot.Name;
            this.TotalHP = 50 + pilot.TotalHP;
            this.HP = this.TotalHP;
            this.Speed = 25 + pilot.TotalHP;
            this.MaxDamage = 15 + pilot.MaxDamage;
            this.MinDamage = 5 + pilot.MinDamage;
            this.HitChance = 0.95 * pilot.HitChance;
            this.Defense = 7 + pilot.Defense;
            this.img = ImageFactory.findImage("escaflowne");
        }
    }
}
