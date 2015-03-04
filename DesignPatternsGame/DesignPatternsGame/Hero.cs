using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public abstract class Hero : GameCharacter
    {
        HeroParty heroes;

        public Hero(HeroParty heroes)
        {
            this.heroes = heroes;
        }
        public override abstract void useSpecial(GameCharacter target);
    
        public ItemList getItems()
        {
            return this.heroes.Items;
        }
    }
}
