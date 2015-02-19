using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class ItemList: LinkedList<Item>
    {
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

        public Item getItem(int index) // 1 base indexing
        {
            if (this.Count <= 0 || index > this.Count || index < 1)
                throw new NullReferenceException();

            int i = 1;
            LinkedListNode<Item> cur = this.First;

            while (i != index)
            {
                cur = cur.Next;
                i++;
            }
            return (Item) cur.Value;
        }

        public void printList()
        {
            int i = 1;
            LinkedListNode<Item> cur = this.First;
            while(cur != this.Last.Next)
            {
                Console.WriteLine(i + ". " + cur.Value.Name);
            }
        }
    }
}
