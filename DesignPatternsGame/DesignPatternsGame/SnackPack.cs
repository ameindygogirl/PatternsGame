using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class SnackPack: Item
    {
        private int healed;

        public SnackPack()
        {
            this.Name = "Snack Pack";
            Amount = 1;
        }

        public SnackPack(int quantity) : base(quantity) { this.Name = "Snack Pack"; }

        public override void use()
        {
            int newHealth = Target.HP + 10;

            if (newHealth > Target.TotalHP)
            {
                healed = Target.TotalHP - Target.HP;
                Target.HP = Target.TotalHP;
            }
            else
            {
                healed = 10;
                Target.HP = newHealth;
            }
            this.Amount--;
        }

        public override string ToString()
        {
            return Target.Name + " enjoyed a delicious Snack Pack and gained " + healed + " hp!";
        }
    }
}
