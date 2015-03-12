using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class Player
    {
        private int row;
        private int column;
        private int curLeft;
        private int curTop;
        private bool hasRobot;
        private int level;

        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        public int Column
        {
            get { return column; }
            set { column = value; }
        }

        public int CurLeft
        {
            get { return curLeft; }
            set { curLeft = value; }
        }

        public int CurTop
        {
            get { return curTop; }
            set { curTop = value; }
        }

        public bool HasRobot
        {
            get { return hasRobot; }
            set { hasRobot = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public Player(int level)
        {
            this.level = level;
            hasRobot = true;
        }
    }
}
