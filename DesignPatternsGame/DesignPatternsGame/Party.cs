using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public abstract class Party
    {
        protected GameCharacterList characters = new GameCharacterList();

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

        public bool isDead()
        {
            int j = 0;
            LinkedListNode<GameCharacter> cur = characters.First;
            while (cur != characters.Last.Next)
            {
                if (cur.Value.HP <= 0)
                    j++;

                cur = cur.Next;
            }
            if (j == characters.Count)
                return true;
            return false;
        }
    }
}