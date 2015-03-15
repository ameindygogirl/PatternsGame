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
            initParty();
        }

        public override void initParty()
        {
            Random random = new Random();
            int i = random.Next(6) + 1;
            GameCharacter m1 = monsters.createCharacter(i);
            i = random.Next(6) + 1;
            GameCharacter m2 = monsters.createCharacter(i);
            i = random.Next(6) + 1;
            GameCharacter m3 = monsters.createCharacter(i);

            Characters.AddFirst(m3);
            Characters.AddFirst(m2);
            Characters.AddFirst(m1);                        
        }
    }
}
