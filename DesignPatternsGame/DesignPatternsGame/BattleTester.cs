using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public static class BattleTester
    {
        public static int main(String[] args)
        {
            HeroParty heroes = new HeroParty();
            heroes.initParty();
            HealthPotion potion = new HealthPotion(5);
            heroes.addItem(potion);

            MonsterParty monsters = new MonsterParty();
            monsters.initParty();

            Battle encounter = new Battle();
            encounter.Heroes = heroes;
            encounter.Monsters = monsters;
            encounter.start();

            return 1;
        }
    }
}
