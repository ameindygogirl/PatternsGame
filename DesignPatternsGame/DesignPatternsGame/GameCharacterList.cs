using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class GameCharacterList: LinkedList<GameCharacter>
    {
        public void sort() // based on attackSpeed
        {
            if (this.Count <= 0)
                return;

            LinkedListNode<GameCharacter> start = null;
            LinkedListNode<GameCharacter> lastSorted = null;
            LinkedListNode<GameCharacter> sortedWalker = null;

            for (start = First; start != Last; start = start.Next)
            {
                lastSorted = start;
                for (sortedWalker = start.Next; sortedWalker != First.Previous; sortedWalker = sortedWalker.Previous)
                {
                    if(sortedWalker.Value.Speed >= lastSorted.Value.Speed)
                        break;

                    lastSorted = sortedWalker;
                }
                sortedWalker = start;
            }
        }
    }
}
