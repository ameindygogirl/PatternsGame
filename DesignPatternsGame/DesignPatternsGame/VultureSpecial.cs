using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class VultureSpecial : SpecialAction
    {
        private bool raised;

        public VultureSpecial() : base("Raise Ally") { }

        public override void execute()
        {
            LinkedListNode<GameCharacter> cur = primary.Allies.First;
            while(cur != primary.Allies.Last.Next)
            {
                if (cur.Value.revive(cur.Value.TotalHP / 2))
                {
                    raised = true;
                    target = cur.Value;
                    break;
                }
                cur = cur.Next;
            }
        }

        public override string toString()
        {
            if (!raised)
                return primary.Name + " circles above the party!";
            
            return primary.Name + " revives " + target.Name;
        }
    }
}
