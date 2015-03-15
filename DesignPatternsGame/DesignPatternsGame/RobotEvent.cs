using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class RobotEvent : RoomEvent
    {
        void RoomEvent.execute(HeroParty hparty)
        {
            RobotFactory rfact = RobotFactory.getInstance();

            rfact.getRobot(hparty);
        }
    }
}
