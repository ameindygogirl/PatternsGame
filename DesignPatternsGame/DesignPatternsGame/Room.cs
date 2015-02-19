using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class Room
    {
        private Party baddies;
        private Item item;
        private Room north;
        private Room south;
        private Room east;
        private Room west;
        private bool entrance;
        private bool exit;

        public Room()
        {
            Random rand = new Random();
            int randResult = rand.Next(3);
            if (randResult == 1)
            { }
                //baddies = new Party();
            else
                baddies = null;

            randResult = rand.Next(3);
            if (randResult == 1)
                item = null;
            else
                item = null;

            item = null;
            north = null;
            south = null;
            east = null;
            west = null;
        
        }

        public Room North
        {
            get { return this.north; }
            set { this.north = value; }
        }

        public Room South
        {
            get { return this.south; }
            set { this.south = value; }
        }

        public Room East
        {
            get { return this.east; }
            set { this.east = value; }
        }

        public Room West
        {
            get { return this.west; }
            set { this.west = value; }
        }

        public bool Entrance
        {
            get { return this.entrance; }
            set { this.entrance = value; }
        }

        public bool Exit
        {
            get { return this.exit; }
            set { this.exit = value; }
        }

        public bool hasNorth()
        {
            return this.north != null;
        }

        public bool hasSouth()
        {
            return this.south != null;
        }

        public bool hasEast()
        {
            return this.east != null;
        }

        public bool hasWest()
        {
            return this.west != null;
        }
    }
}