using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class AttackAction: Action
    {
        private int damage;

        public AttackAction() : base()
        {
            this.name = "Attack";
        }

        public override void execute()
        {
            int random = new Random().Next(1, 100);
            if (primary.HitChance >= random)
            {
                int hit = new Random().Next(primary.MinDamage, primary.MaxDamage);
                damage = Target.HP - hit;

                if (Target.Action is DefendAction)
                    damage = damage / 2;

                Target.HP = damage;
            }
        }

        public override String toString()
        {
            if(damage == 0)
                return primary.Name + " missed!";

            return primary.Name + " deals " + damage + " to " + target.Name;
        }

        public void undo()
        {
            throw new InvalidOperationException();
        }
    }
}
