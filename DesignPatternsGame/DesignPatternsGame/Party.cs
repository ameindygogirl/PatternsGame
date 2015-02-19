using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public abstract class Party
    {
        private GameCharacterList characters;

        public GameCharacterList Characters
        {
            get { return characters; }
            set { characters = value; }
        }

        public abstract void initParty();
        
        public Boolean isEmpty()
        {
            return characters.Count <= 0;
        }
    }
}