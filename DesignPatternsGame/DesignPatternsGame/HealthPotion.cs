using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class HealthPotion : Item
    {
        private int healed;

        public HealthPotion()
        {
            this.Name = "Health Potion";
            Amount = 1;
        }

        public HealthPotion(int quantity) : base(quantity) { this.Name = "Health Potion"; }

        public override void use()
        {
            int prevHP = Target.HP;
            Target.addHP(30);
            healed = Target.HP - prevHP;
            this.Amount--;
        }

        public override string ToString()
        {
            return Target.Name + " is healed " + healed + " hp!";
        }
    }
}
