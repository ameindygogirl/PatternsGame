using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class BattleEvent : RoomEvent
    {
        
        MonsterParty mparty;

        public BattleEvent()
        {
            

            this.mparty = new MonsterParty();
            this.mparty.initParty();
        }

        void RoomEvent.execute(HeroParty hparty)
        {
            BattleWindow battle = new BattleWindow(hparty, this.mparty);
        }
    }
}
