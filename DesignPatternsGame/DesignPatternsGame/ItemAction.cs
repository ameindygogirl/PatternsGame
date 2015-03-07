using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class ItemAction: Action
    {
        private Item item;

        public ItemAction(Item that)
        {
            this.item = that;
            item.Target = this.target;
        }

        public override void execute()
        {
            this.item.use();
        }

        public override String toString()
        {
            return Primary.Name + " uses " + item.Name + " on " + item.Target.Name;
        }
    }
}
