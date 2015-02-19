using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class ActionList: LinkedList<Action>
    {
        public void printList()
        {
            foreach(Action a in this)
            {
                Console.WriteLine("1. " + a.Name);
            }
        }

        public Action getData(int index) // 1 base indexing
        {
            if (this.Count <= 0 || index > this.Count || index < 1)
                throw new NullReferenceException();

            int i = 1;
            LinkedListNode<Action> cur = this.First;
            
            while (i != index)
            {
                cur = cur.Next;
                i++;
            }
            return (Action) cur.Value;
        }
    }
}
