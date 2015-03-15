using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class RobotFactory
    {
        private static RobotFactory instance;
        int level;

        private RobotFactory()
        {
            this.level = 1;
        }

        public void getRobot(HeroParty hparty)
        {
            RobotDecorator robot;
            GameCharacter temp;
            RobotAwarded ra;

            switch(level)
            {
                case 1:
                    temp = hparty.Characters.ElementAt(0);
                    robot = new EscaflowneRobot(temp);
                    hparty.Characters.Remove(temp);
                    hparty.Characters.AddLast(robot);

                    ra = new RobotAwarded(temp.Name, "Escaflowne", "escaflowne");
                    ra.ShowDialog();
                    break;
                case 2:
                    temp = hparty.Characters.ElementAt(0);
                    robot = new Unit01Robot(temp);
                    hparty.Characters.Remove(temp);
                    hparty.Characters.AddLast(robot);

                    ra = new RobotAwarded(temp.Name, "Unit 01", "unit01");
                    ra.ShowDialog();
                    break;
                case 3:
                    temp = hparty.Characters.ElementAt(0);
                    robot = new GaoGaiGarRobot(temp);
                    hparty.Characters.Remove(temp);
                    hparty.Characters.AddLast(robot);

                    ra = new RobotAwarded(temp.Name, "GaoGaiGar", "gaogaigar");
                    ra.ShowDialog();
                    break;
                default:
                    break;
            }

            hparty.HasRobot = true;
            level ++;
        }

        public static RobotFactory getInstance()
        {
            if(instance == null)
            {
                instance = new RobotFactory();
            }

            return instance;
        }
    }
}
