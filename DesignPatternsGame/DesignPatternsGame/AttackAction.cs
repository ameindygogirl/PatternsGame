using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class AttackAction: Action
    {
        public AttackAction()
        {
            this.name = "Attack";
        }

        public override void execute()
        {
            if (primary.HitChance >= new Random().NextDouble())
            {
                int hit = new Random().Next(primary.MaxDamage - primary.MinDamage + 1) + primary.MinDamage;
                int result = Target.HP - hit;
                
                //if (Target.PrevAction = instance(Defend))
                //   result = result / 2;

                Target.HP = result;
                Console.WriteLine(primary.Name + " hits " + target.Name + " for " + result + " points of damage");
            }
            else
            {
                Console.WriteLine(primary.Name + " missed!");
            }
        }

        public override string ToString()
        {
            return primary.Name + " attacks against " + target.Name;
        }

        public void undo()
        {
            throw new InvalidOperationException();
        }
    }
}
