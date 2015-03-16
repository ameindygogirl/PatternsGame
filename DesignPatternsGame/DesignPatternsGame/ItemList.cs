using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class ItemList: LinkedList<Item>
    {
        public ItemList()
        {
            this.AddFirst(new HealthPotion(0));
            this.AddFirst(new CollarOfPower(0));
            this.AddFirst(new SnackPack(0));
        }
        public void sort() //alphabetic
        {
            if (this.Count <= 0)
                return;

            LinkedListNode<Item> start = null;
            LinkedListNode<Item> lastSorted = null;
            LinkedListNode<Item> sortedWalker = null;

            for (start = First; start != Last; start = start.Next)
            {
                lastSorted = start;
                for (sortedWalker = start.Next; sortedWalker != First.Previous; sortedWalker = sortedWalker.Previous)
                {
                    if ((sortedWalker.Value.Name).CompareTo(lastSorted.Value.Name) >= 0)
                        break;

                    lastSorted = sortedWalker;
                }
                sortedWalker = start;
            }
        }

        public String showItems()
        {
            String s = "";
            LinkedListNode<Item> cur = this.First;
            while(cur != this.Last.Next)
            {
                s = cur.Value.Name + "\t\t" + cur.Value.Amount + "\n";
            }
            return s;
        }
    }
}
