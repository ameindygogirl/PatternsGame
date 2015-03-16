using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class BattleEvent: RoomEvent
    {
        public BattleEvent(BattleWindow bw) : base(bw) { }
        
        public override void execute(HeroParty hparty)
        {
            if (triggered == true) return;
            bw = new BattleWindow(hparty, new MonsterParty());
            bw.Show();
            triggered = true;
        }
    }
}
