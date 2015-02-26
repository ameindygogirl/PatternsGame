using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class HeroFactory: GameCharacterFactory
    {
        public override GameCharacter createCharacter(int option)
        {
            GameCharacter hero = null;
            switch (option)
            {
                case 1:
                    hero = new ChubbyChipmunk();
                    break;
                case 2:
                    hero = new CuddlyKitten();
                    break;
                case 3:
                    hero = new DarlingDuckling();
                    break;
                case 4:
                    hero = new FuzzyPuppy();
                    break;
                case 5:
                    hero = new TinyTurtle();
                    break;
                case 6:
                    hero = new WiseOwl();
                    break;
            }
            return hero;
        }

        public String getName()
        {
            String name = Console.ReadLine();
            if (name.Length > 8)
                return name.Substring(0, 8);
            return name;
        }
    }
}
