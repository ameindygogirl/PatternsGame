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

        public Items
        {
            get { return this.items; }
            set { this.items = value; }
        }

        public void addItem(Item item)
        {
            items.AddFirst(item);
        }

        public override void initParty()
        {
            GameCharacterList list = new GameCharacterList();
            ActionList alist       = new ActionList();

            ItemAction item       = new ItemAction();
            SpecialAction special = new SpecialAction();
            DefendAction defend   = new DefendAction();
            AttackAction attack   = new AttackAction();

            GameCharacter gc1 = makeHero.createCharacter(1);
            GameCharacter gc2 = makeHero.createCharacter(2);
            GameCharacter gc3 = makeHero.createCharacter(3);
            
            alist.AddFirst(item);
            alist.AddFirst(special);
            alist.AddFirst(defend);
            alist.AddFirst(attack);

            if(alist != null)
            {
                gc1.Actions = alist;
                gc2.Actions = alist;
                gc3.Actions = alist;
            }
            list.AddFirst(gc3);
            list.AddFirst(gc2);
            list.AddFirst(gc1);

            Characters = list;
        }
    }
}
