using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class RobotEvent : RoomEvent
    {
        public RobotEvent() : base() { }
        public RobotEvent(int level) : base(level) { }

        public override void execute(HeroParty hparty)
        {
            if (triggered == true) return;

            RobotFactory rfact = RobotFactory.getInstance();
            bw = new BattleWindow(hparty, rfact.getBossParty());
            bw.Show();
            triggered = true;
        }
    }
}
