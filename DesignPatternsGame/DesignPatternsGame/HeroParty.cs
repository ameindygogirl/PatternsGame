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

        public HeroParty(int a, int b, int c)
        {
            makeHero = new HeroFactory();
            items = new ItemList();
            initParty(a, b, c);
        }

        public ItemList Items
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
            
            GameCharacter gc1 = makeHero.createCharacter(1);
            GameCharacter gc2 = makeHero.createCharacter(2);
            GameCharacter gc3 = makeHero.createCharacter(3);
            
            list.AddFirst(gc3);
            list.AddFirst(gc2);
            list.AddFirst(gc1);

            Characters = list;
        }

        private void initParty(int a, int b, int c)
        {
            GameCharacterList list = new GameCharacterList();
            
            GameCharacter gc1 = makeHero.createCharacter(a);
            GameCharacter gc2 = makeHero.createCharacter(b);
            GameCharacter gc3 = makeHero.createCharacter(c);
            
            list.AddFirst(gc3);
            list.AddFirst(gc2);
            list.AddFirst(gc1);

            Characters = list;
        }
    }
}
