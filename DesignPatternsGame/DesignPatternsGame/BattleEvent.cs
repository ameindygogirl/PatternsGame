using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class BattleEvent : RoomEvent
    {
        void RoomEvent.execute(HeroParty hparty)
        {
            //BattleWindow battle = new BattleWindow(hparty, new MonsterParty());
        }
    }
}
