using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class ItemAction: Action
    {
        public ItemAction() : base("Item") { }

        private Item item;

        public ItemAction(Item that) : base("Item")
        {
            this.item = that;
            item.Target = this.target;
        }

        public override GameCharacter Target
        {
            set
            {
                this.target = value;
                this.item.Target = target;
            }
            get { return target; }
        }

        public override void execute()
        {
            this.item.use();
        }

        public override String toString()
        {
            String s = Primary.Name + " uses " + item.Name + " on " + item.Target.Name;
            s += "\n" + item.ToString();
            return s;
        }
    }
}
