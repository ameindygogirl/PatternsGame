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
            GameCharacter a, b, c;
            Random rand = new Random();

            a = monsters.createCharacter(rand.Next(6) + 1);
            b = monsters.createCharacter(rand.Next(6) + 1);
            c = monsters.createCharacter(rand.Next(6) + 1);

            switch(level)
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
