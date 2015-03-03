using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public abstract class Monster: GameCharacter
    {
        public Action takeAction()
        {
            double random = new Random().NextDouble();
            int index = (int) (random * Actions.Count);

            return Actions.getData(index);
        }
        public override abstract void useSpecial(GameCharacter target);
        
        public Action pickAction()
        {
            Action a;
            ActionFactory af = new ActionFactory();
            int random = new Random().Next(0, af.Count);
            a = af.makeAction(random);
            return a;
        }

        public GameCharacter pickTarget(GameCharacterList theList)
        {
            int random;
            GameCharacter target = null;
            while (target == null)
            {
                random = new Random().Next(1, 3);
                switch(random)
                {
                    case 1:
                        target = theList.First.Value;
                        if (target.HP <= 0)
                            target = null;
                        break;
                    case 2:
                        target = theList.First.Next.Value;
                        if (target.HP <= 0)
                            target = null;
                        break;
                    case 3:
                        target = theList.Last.Value;
                        if (target.HP <= 0)
                            target = null;
                        break;
                }
            }
            return target;
        }
    }
}
