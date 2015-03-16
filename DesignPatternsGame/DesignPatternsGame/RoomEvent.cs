using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    abstract class RoomEvent
    {
        protected bool triggered;
        protected int level;
        protected BattleWindow bw;

        public RoomEvent() { triggered = false; }
        
        public BattleWindow BW
        {
            get { return bw; }
            set { bw = value; }
        }

        public abstract void execute(HeroParty hparty);
    }
}
