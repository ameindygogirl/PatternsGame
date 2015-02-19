using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    public abstract class GameCharacterFactory
    {
        public abstract GameCharacter createCharacter(int selection);
    }
}
