using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class MonsterFactory: GameCharacterFactory
    {
        public override GameCharacter createCharacter(int selection)
        {
            Monster monster = null;

            switch (selection)
            {
                case 1:
                    monster = new CrookedVulture();
                    break;
                case 2:
                    monster = new DeadlyDinosaur();
                    break;
                case 3:
                    monster = new FierceLion();
                    break;
                case 4:
                    monster = new ScaryShark();
                    break;
                case 5:
                    monster = new SlitheringSnake();
                    break;
                case 6:
                    monster = new StealthySpider();
                    break;
            }
            return monster;
        }
    }
}
