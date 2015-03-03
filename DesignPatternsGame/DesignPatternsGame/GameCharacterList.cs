using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class GameCharacterList: LinkedList<GameCharacter>, IEnumerable<GameCharacter>
    {
        public void sort() // based on attackSpeed
        {
            if (this.Count <= 0)
                return;

            LinkedListNode<GameCharacter> start = null;
            GameCharacter nextUnsorted = null;
            LinkedListNode<GameCharacter> sortedWalker = null;

            for (start = this.First; start != this.Last; start = start.Next)
            {
                nextUnsorted = start.Next.Value;
                for (sortedWalker = start.Next; sortedWalker != this.First; sortedWalker = sortedWalker.Previous)
                {
                    if(sortedWalker.Value.Speed <= start.Value.Speed)
                        break;

                    sortedWalker.Value = sortedWalker.Previous.Value;
                }
                sortedWalker.Value = nextUnsorted;
            }
        }
    }
}
