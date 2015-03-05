using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class ActionFactory
    {
        private int COUNT = 4;

        public int Count
        {
            get { return this.COUNT; }
        }

        public Action makeAction(GameCharacter gc, int i)
        {
            switch(i)
            {
                case 0:
                    return new AttackAction();
                case 1:
                    return new DefendAction();
                case 2:
                    //return new SpecialAction();
                    return new AttackAction();
                case 3:
                    ItemList items = gc.getItems();
                    if (items == null)
                        return new AttackAction();

                    int random = new Random().Next(0, items.Count);
                    Item item = items.ElementAt(random);
                    return new ItemAction(item);
            }
            return null;
        }
    }
}
