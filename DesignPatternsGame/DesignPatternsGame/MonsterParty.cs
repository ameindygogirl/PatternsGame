using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class MonsterParty: Party
    {
        private MonsterFactory monsters;

        public MonsterParty()
        {
            monsters = new MonsterFactory();
        }

        public override void initParty()
        {
            GameCharacter m1 = monsters.createCharacter(new Random().Next(6)+1);
            GameCharacter m2 = monsters.createCharacter(new Random().Next(6)+1);
            GameCharacter m3 = monsters.createCharacter(new Random().Next(6)+1);

            Characters.AddFirst(m3);
            Characters.AddFirst(m2);
            Characters.AddFirst(m1);                        
        }
    }
}
