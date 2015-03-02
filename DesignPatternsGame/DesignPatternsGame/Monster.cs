using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public abstract class Monster: GameCharacter
    {
        public override Action takeAction()
        {
            double random = new Random().NextDouble();
            int index = (int) (random * Actions.Count);

            return Actions.getData(index);
        }
        public override abstract void useSpecial(GameCharacter target);
        public bool isHero() { return false; }
    }
}
