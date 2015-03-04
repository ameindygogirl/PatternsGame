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
            int random = new Random().Next(1, 100);
            if (primary.HitChance >= random)
            {
                int hit = new Random().Next(primary.MinDamage, primary.MaxDamage);
                int result = Target.HP - hit;

                if (Target.Action is DefendAction)
                    result = result / 2;

                Target.HP = result;
            }
        }

        public override string ToString()
        {
            return primary.Name + " attacks " + target.Name;
        }

        public void undo()
        {
            throw new InvalidOperationException();
        }
    }
}
