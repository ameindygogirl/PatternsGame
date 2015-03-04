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

        public Player(int row, int column, int curLeft, int curTop)
        {
            this.row = row;
            this.column = column;
            this.curLeft = curLeft;
            this.curTop = curTop;
        }
    }
}
