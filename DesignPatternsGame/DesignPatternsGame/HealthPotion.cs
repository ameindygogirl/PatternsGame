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
            Amount = 1;
        }

        public HealthPotion(int quantity): base(quantity) {}

        public override void use()
        {
            int newHealth = Target.HP + 30;

            if (newHealth > Target.TotalHP)
            {
                healed = Target.TotalHP - Target.HP;
                Target.HP = Target.TotalHP;
            }
            else
            {
                healed = 30;
                Target.HP = newHealth;
            }
            this.Amount--;
        }

        public override string ToString()
        {
            return Target.Name + " is healed " + healed + "hp";
        }
    }
}
