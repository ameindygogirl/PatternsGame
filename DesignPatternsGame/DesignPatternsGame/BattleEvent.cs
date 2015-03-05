using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class BattleEvent : RoomEvent
    {
        MonsterParty party;

        void RoomEvent.execute()
        {
            Console.Write("");
        }
    }
}
