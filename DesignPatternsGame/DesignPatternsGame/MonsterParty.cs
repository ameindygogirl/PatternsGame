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

        public MonsterParty(GameCharacter first, GameCharacter second, GameCharacter third)
        {
            characters.AddLast(first);
            characters.AddLast(second);
            characters.AddLast(third);

            first.Allies = characters;
            second.Allies = characters;
            third.Allies = characters;
        }

        private void initParty()
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

            m1.Allies = characters;
            m2.Allies = characters;
            m3.Allies = characters;
        }
    }
}
