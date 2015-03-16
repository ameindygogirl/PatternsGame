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
            int prevHP = Target.HP;
            Target.revive(10);
            healed = Target.HP - prevHP;
            this.Amount--;
        }

        public override string ToString()
        {
            return Target.Name + " was revived by the deliciousness of the snack pack!";
        }
    }
}
