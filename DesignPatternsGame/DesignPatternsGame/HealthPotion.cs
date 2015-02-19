using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class HealthPotion : Item
    {
        public HealthPotion()
        {
            Amount = 1;
        }
        public HealthPotion(int quantity): base(quantity) {}

        public override void use()
        {
            int newHealth = Target.HP + 30;
            if (newHealth > Target.TotalHP)
                Target.HP = Target.TotalHP;

            else
                Target.HP = newHealth;

            this.Amount--;
        }
    }
}
