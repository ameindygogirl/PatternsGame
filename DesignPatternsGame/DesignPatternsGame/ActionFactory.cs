using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class ActionFactory
    {
        private int COUNT = 3;

        public int Count
        {
            get { return this.COUNT; }
        }

        public Action makeAction(GameCharacter gc, int i)
        {
            switch(i)
            {
                case 0:
                    return new AttackAction();
                case 1:
                    return new DefendAction();
                case 2:
                    return gc.Special;
            }
            return null;
        }
    }
}
