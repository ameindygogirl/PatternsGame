using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public abstract class Monster: GameCharacter
    {
        protected ItemList items;
        private ActionList actions;

        public Action takeAction()
        {
            double random = new Random().NextDouble();
            int index = (int) (random * actions.Count);

            return actions.getData(index);
        }

        public ItemList getItems()
        {
            return items;
        }

        public Action pickAction()
        {
            Action a;
            ActionFactory af = new ActionFactory();
            int random = new Random().Next(0, af.Count);
            a = af.makeAction(this, random);
            a.Primary = this;
            return a;
        }

        public GameCharacter pickTarget(GameCharacterList theList)
        {
            int random;
            GameCharacter target = null;

            LinkedListNode<GameCharacter> cur = theList.First;
            while(cur != theList.Last.Next)
            {
                if(cur.Value.Action is ProvokeSpecial && cur.Value.HP > 0)
                {
                    return cur.Value;
                }
            }

            while (target == null)
            {
                random = new Random().Next(1, 3);
                switch(random)
                {
                    case 1:
                        target = theList.First.Value;
                        if (target.HP <= 0)
                            target = null;
                        break;
                    case 2:
                        target = theList.First.Next.Value;
                        if (target.HP <= 0)
                            target = null;
                        break;
                    case 3:
                        target = theList.Last.Value;
                        if (target.HP <= 0)
                            target = null;
                        break;
                }
            }
            return target;
        }
    }
}
