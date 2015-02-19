using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public abstract class Item
    {
        private String name;
        private int amount;
        private GameCharacter target;

        public Item()
        {
            name = null;
            amount = 0;
            target = null;
        }

        public Item(int quantity)
        {
            amount = quantity;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public GameCharacter Target
        {
            get { return target; }
            set { target = value; }
        }

        public abstract void use();
    }
}
