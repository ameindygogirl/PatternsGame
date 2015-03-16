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

        public RoomEvent() { }
        public RoomEvent(int level)
        {
            this.level = level;
            triggered  = false;
        }
        public RoomEvent(BattleWindow bw)
        {
            this.bw = bw;
            triggered = false;
        }
        public RoomEvent(int level, BattleWindow bw)
        {
            this.bw = bw;
            this.level = level;
            triggered  = false;
        }
        
        public BattleWindow BW
        {
            get { return bw; }
        }

        public abstract void execute(HeroParty hparty);
    }
}
