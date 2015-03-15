using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class QuackSpecial : DefensiveSpecial
    {
        public QuackSpecial() : base("Quack") { }

        public override void execute()
        {
            LinkedListNode<GameCharacter> cur = primary.Allies.First;
            while(cur != primary.Allies.Last.Next)
            {
                cur.Value.addHP(20);
                cur = cur.Next;
            }
        }
        public override String toString()
        {
            return primary.Name + " rallies the party!\nParty increases 20hp";
        }
    }
}
