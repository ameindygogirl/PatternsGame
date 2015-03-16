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
        MonsterFactory monsters;

        private RobotFactory()
        {
            this.level = 1;
            this.monsters = new MonsterFactory();
        }

        public MonsterParty getBossParty()
        {
            RobotDecorator robot = null;
            MonsterParty mparty;
            Monster a, b, c;
            MonsterFactory mf = new MonsterFactory();
            Random rand = new Random();

            a = (Monster) mf.createCharacter(rand.Next(6) + 1);
            b = (Monster) mf.createCharacter(rand.Next(6) + 1);
            c = (Monster) mf.createCharacter(rand.Next(6) + 1);

            switch(level++)
            {
                case 1:
                    robot = new EscaflowneRobot(a);
                    break;
                case 2:
                    robot = new Unit01Robot(a);
                    break;
                case 3:
                    robot = new GaoGaiGarRobot(a);
                    break;
            }
            mparty = new MonsterParty(robot, b, c);

            return mparty;

        }

        public void getRobot(HeroParty hparty, int level)
        {
            //if (level < 0)
            //    return;

            RobotDecorator robot;
            GameCharacter temp;
            RobotAwarded ra;

            switch (level)
            {
                case 1:
                    temp = hparty.Characters.ElementAt(0);
                    robot = new EscaflowneRobot(temp);
                    hparty.Characters.Remove(temp);
                    hparty.Characters.AddLast(robot);
                    ra = new RobotAwarded(hparty.Characters.ElementAt(level-1).Name, "Escaflowne", "escaflowne");
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
            //           level = -1;
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
