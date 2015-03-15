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
        private bool hasRobot;


        public HeroParty()
        {
            makeHero = new HeroFactory();
            items = new ItemList();
            this.hasRobot = false;
            initParty();
        }

        public HeroParty(int a, int b, int c)
        {
            makeHero = new HeroFactory();
            items = new ItemList();
            this.hasRobot = false;
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

        private void initParty()
        {
            GameCharacterList list = new GameCharacterList();
            
            GameCharacter gc1 = makeHero.createCharacter(1);
            GameCharacter gc2 = makeHero.createCharacter(2);
            GameCharacter gc3 = makeHero.createCharacter(3);
            
            list.AddFirst(gc3);
            list.AddFirst(gc2);
            list.AddFirst(gc1);

            Characters = list;

            gc1.Allies = list;
            gc2.Allies = list;
            gc3.Allies = list;
            items.AddFirst(new HealthPotion(5));
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

            characters = list;
            gc1.Allies = list;
            gc2.Allies = list;
            gc3.Allies = list;
            items.AddFirst(new HealthPotion(5));
        }

        public bool HasRobot
        {
            get { return hasRobot; }
            set { hasRobot = value; }
        }
    }
}
