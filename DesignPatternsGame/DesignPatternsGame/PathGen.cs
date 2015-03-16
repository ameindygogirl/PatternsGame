using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsGame
{
    class PathGen
    {
        private int FINDFREQ = 8;
        private BattleWindow bw;
        private Room[,] grid;
        private Room entrance;
        private Random rand = new Random();
        int x, y, tempRooms, goalRooms, level;

        public PathGen(int type, int level, BattleWindow bw)
        {
            this.bw       = bw;
            this.entrance = null;
            this.level    = level;
            
            if(type == 0)
            {
                setEasy();
            }
            else if(type == 1)
            {
                setMedium();
            }
            else
            {
                setHard();
            }        
        }

        public void setEasy()
        {
            this.x = 5;
            this.y = 5;
            this.grid = new Room[x, y];
            int floor = (x * y) / 3;
            int ceil = floor * 2;
            this.goalRooms = rand.Next(floor, ceil);

        }

        public void setMedium()
        {
            this.x = 8;
            this.y = 8;
            this.grid = new Room[x, y];
            int floor = (x * y) / 3;
            int ceil = floor * 2;
            this.goalRooms = rand.Next(floor, ceil);

        }

        public void setHard()
        {
            this.x = 12;
            this.y = 12;
            this.grid = new Room[x, y];
            int floor = (x * y) / 3;
            int ceil = floor * 2;
            this.goalRooms = rand.Next(floor, ceil);

        }

        public Room[,] getPath()
        {
            this.tempRooms = 0;
            this.entrance = new Room();
            this.entrance.Entrance = true;
            int i = rand.Next(this.x);
            int j = rand.Next(this.y);


            while (this.tempRooms < this.goalRooms)
            {
                buildPath(this.entrance, i, j);
            }

            setRobot();

            return this.grid;
        }

        

        private void buildPath(Room cur, int i, int j)
        {
            int r;
            Room next;

            this.grid[i, j] = cur;
            

            if (tempRooms < goalRooms)
            {
                setEvent(cur);

                r = rand.Next(2);
                if (r == 0 && isValidIndex(i + 1, j))
                {
                    next = attachNorth(cur, i, j);
                    buildPath(next, i + 1, j);
                }

                r = rand.Next(2);
                if (r == 0 && isValidIndex(i - 1, j) && tempRooms < goalRooms)
                {
                    next = attachSouth(cur, i, j);
                    buildPath(next, i - 1, j);
                }

                r = rand.Next(2);
                if (r == 0 && isValidIndex(i, j + 1) && tempRooms < goalRooms)
                {
                    next = attachEast(cur, i, j);
                    buildPath(next, i, j + 1);
                }

                r = rand.Next(2);
                if (r == 0 && isValidIndex(i, j - 1) && tempRooms < goalRooms)
                {
                    next = attachWest(cur, i, j);
                    buildPath(next, i, j - 1);
                }
            }
            else
            {
                cur.Exit = true;
            }
            
        }

        private void setEvent(Room cur)
        {
            int r = 0;
            r = rand.Next(0, FINDFREQ);

            switch (r)
            {
                case 0:
                    cur.Event = new BattleEvent(bw);
                    break;
                case 1:
                    cur.Event = new ItemEvent();
                    break;
                default:
                    break;
            }
        }

        private void setRobot()
        { 
            int i, j;
            do
            {
                i = this.rand.Next(this.x);
                j = this.rand.Next(this.y);
            } while (this.grid[i,j] == null || this.grid[i,j].Entrance || this.grid[i,j].Exit);

            this.grid[i, j].Event = new RobotEvent(level, bw);
        }

        private Room attachNorth(Room cur, int i, int j)
        {
            int n = i + 1;
            Room next = getNext(n, j);
            cur.North = next;
            next.South = cur;
            return next;
        }

        private Room attachSouth(Room cur, int i, int j)
        {
            int n = i - 1;
            Room next = getNext(n, j);
            cur.South = next;
            next.North = cur;
            return next;
        }

        private Room attachEast(Room cur, int i, int j)
        {
            int n = j + 1;
            Room next = getNext(i, n);
            cur.East = next;
            next.West = cur;
            return next;
        }

        private Room attachWest(Room cur, int i, int j)
        {
            int n = j - 1;
            Room next = getNext(i, n);
            cur.West = next;
            next.East = cur;
            return next;
        }

        private Room getNext(int n, int j)
        {
            Room next;
            if (grid[n, j] != null)
            {
                next = grid[n, j];
            }
            else
            {
                next = new Room();
                tempRooms++;
            }

            return next;
        }

        private bool isValidIndex(int i, int j)
        {
            try
            {
                this.grid[i, j] = this.grid[i, j];
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }

        }
        public Room[,] getPathToPrint()
        {
            return this.grid;
        }
        public void printPath()
        {
            for (int i = 0; i < this.x; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < this.y; j++)
                {
                    if (this.grid[i, j] != null)
                    {
                        if (this.grid[i, j].Entrance)
                            Console.Write("E ");
                        else if (this.grid[i, j].Exit)
                            Console.Write("X ");
                        else
                            Console.Write("0 ");
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }
                Console.WriteLine("|");
            }
        }

    }
}
