using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class RobotDecorator : GameCharacter
    {
        GameCharacter pilot;
        
        public RobotDecorator(GameCharacter pilot) : base()
        {
            this.pilot   = pilot;
            this.special = pilot.Special;
            this.allies  = pilot.Allies;
        }

        public Action pickAction()
        {
            Action a;
            ActionFactory af = new ActionFactory();
            int random = new Random().Next(0, af.Count);
            a = af.makeAction(this, random);
            a.Primary = this;
            return a;
        }

        public GameCharacter pickTarget(GameCharacterList theList)
        {
            int random;
            GameCharacter target = null;

            LinkedListNode<GameCharacter> cur = theList.First;
            while (cur != theList.Last.Next)
            {
                if (cur.Value.Action is ProvokeSpecial && cur.Value.HP > 0)
                {
                    return cur.Value;
                }
                cur = cur.Next;
            }

            while (target == null)
            {
                random = new Random().Next(1, 3);
                switch (random)
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
