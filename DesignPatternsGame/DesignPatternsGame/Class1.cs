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
        public BitmapImage findImage(String s)
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
                    //img =
                    break;
                case "shark":
                    //img =
                    break;
                case "snake":
                    //img =
                    break;
                case "spider":
                    //img =
                    break;
            }
            return img;
        }
    }
}
