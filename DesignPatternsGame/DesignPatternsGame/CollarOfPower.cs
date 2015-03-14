using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class CollarOfPower: Item
    {
        public CollarOfPower()
        {
            this.Name = "Collar of Power";
            Amount = 1;
        }

        public CollarOfPower(int quantity) : base(quantity) { this.Name = "Collar of Power"; }

        public override void use()
        {
            int newMaxDamage = Target.MaxDamage + 10;
            Target.MaxDamage = newMaxDamage;
            this.Amount--;
        }

        public override string ToString()
        {
            return Target.Name + " wears the Collar of Power and can now inflict " + Target.MaxDamage + " maximum damage!";
        }
    }
}
