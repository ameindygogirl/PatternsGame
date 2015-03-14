using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesignPatternsGame
{
    class ImageFactory
    {
        public static BitmapImage findImage(String s)
        {
            BitmapImage img = null;
            
            switch(s)
            {
                //heroes
                case "chipmunk":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/chipmunk.png", UriKind.Absolute));
                    break;
                case "kitten":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/kitten.png", UriKind.Absolute));
                    break;
                case "duck":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/duck.png", UriKind.Absolute));
                    break;
                case "dog":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/puppy.png", UriKind.Absolute));
                    break;
                case "turtle":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/tinyTurtle.png", UriKind.Absolute));
                    break;
                case "owl":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/owl.png", UriKind.Absolute));
                    break;

                //monsters
                case "dinosaur":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/dinosaur.png", UriKind.Absolute));
                    break;
                case "vulture":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/vulture.png", UriKind.Absolute));
                    break;
                case "lion":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/lion.png", UriKind.Absolute));
                    break;
                case "shark":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/shark.png", UriKind.Absolute));
                    break;
                case "snake":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/snake.png", UriKind.Absolute));
                    break;
                case "spider":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/spider.png", UriKind.Absolute));
                    break;

                //Maze pieces
                case "wall_1":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/wall.png", UriKind.Absolute));
                    break;
                case "path_1":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/path.png", UriKind.Absolute));
                    break;
                case "enter_1":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/enter.png", UriKind.Absolute));
                    break;
                case "exit_1":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/exit.png", UriKind.Absolute));
                    break;
                case "wall_2":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/roof.png", UriKind.Absolute));
                    break;
                case "path_2":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/road.png", UriKind.Absolute));
                    break;
                case "enter_2":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/enterMan.png", UriKind.Absolute));
                    break;
                case "exit_2":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/exitMan.png", UriKind.Absolute));
                    break;
                case "wall_3":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/waves.png", UriKind.Absolute));
                    break;
                case "path_3":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/sand.png", UriKind.Absolute));
                    break;
                case "enter_3":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/beachEnter.png", UriKind.Absolute));
                    break;
                case "exit_3":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/beachExit.png", UriKind.Absolute));
                    break;

                //Items
                case "Health Potion":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/health.png", UriKind.Absolute));
                    break;
                case "Snack Pack":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/snack.png", UriKind.Absolute));
                    break;
                case "Collar of Power":
                    img = new BitmapImage(new Uri("pack://application:,,,/Images/collar.png", UriKind.Absolute));
                    break;

            }
            return img;
        }
    }
}
