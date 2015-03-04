using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public abstract class Hero : GameCharacter
    {
        HeroParty heroes;

        public HeroParty Heroes
        {
            get { return heroes; }
            set { heroes = value; }
        }

        public override abstract void useSpecial(GameCharacter target);
    
        public override ItemList getItems()
        {
            return this.heroes.Items;
        }
    }
}
