using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class AttackAction: Action
    {
        private int damage;

        public AttackAction()
            : base("Attack") { }

        public override void execute()
        {
            int random = new Random().Next(1, 100);
            if (primary.HitChance >= random)
            {
                damage = new Random().Next(primary.MinDamage, primary.MaxDamage);
                if (Target.subtractHP(damage))
                    damage = damage / 2;
            }
        }

        public override String toString()
        {
            if(damage == 0)
                return primary.Name + " missed!";

            return primary.Name + " deals " + damage + " damage to " + target.Name;
        }
    }
}
