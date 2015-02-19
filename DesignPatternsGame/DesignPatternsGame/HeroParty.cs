using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class HeroParty: Party
    {
        private ItemList items;
        private HeroFactory makeHero;

        public HeroParty()
        {
            makeHero = new HeroFactory();
            items = new ItemList();
        }

        public void addItem(Item item)
        {
            items.AddFirst(item);
        }

        public override void initParty()
        {
            GameCharacterList list = null;
            ActionList alist = null;

            ItemAction item       = new ItemAction();
            SpecialAction special = new SpecialAction();
            DefendAction defend   = new DefendAction();
            AttackAction attack   = new AttackAction();

            //TODO Set createCharacter to user chosen character
            GameCharacter gc1 = makeHero.createCharacter(0);
            GameCharacter gc2 = makeHero.createCharacter(1);
            GameCharacter gc3 = makeHero.createCharacter(2);
            
            alist.AddFirst(item);
            alist.AddFirst(special);
            alist.AddFirst(defend);
            alist.AddFirst(attack);

            gc1.Actions = alist;
            gc2.Actions = alist;
            gc3.Actions = alist;

            list.AddFirst(gc3);
            list.AddFirst(gc2);
            list.AddFirst(gc1);

            Characters = list;
        }

        public Boolean isDead()
        {
            int i, j = 0;
            LinkedListNode<GameCharacter> heroNode = Characters.First;
            for (i = 0; i < Characters.Count; i++)
            {
                if (heroNode.Value.HP <= 0)
                {
                    j++;
                }
            }
            if (j >= Characters.Count)
                return true;

            return false;
        }
    }
}
