using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesignPatternsGame
{
    /// <summary>
    /// Interaction logic for CharacterPicker.xaml
    /// </summary>
    public partial class CharacterPicker : Window
    {
        public int[] heros = new int[3];
        public CharacterPicker()
        {
            InitializeComponent();
        }

        private void btnChip_Click(object sender, RoutedEventArgs e)
        {
            if (imgFirst.Source == null)
            {
                imgFirst.Source = new BitmapImage(new Uri("pack://application:,,,/Images/chipmunk.png", UriKind.Absolute));
                heros[0] = 1;
            }
            else if (imgSecond.Source == null)
            {
                imgSecond.Source = new BitmapImage(new Uri("pack://application:,,,/Images/chipmunk.png", UriKind.Absolute));
                heros[1] = 1;
            }
            else if (imgThird.Source == null)
            {
                imgThird.Source = new BitmapImage(new Uri("pack://application:,,,/Images/chipmunk.png", UriKind.Absolute));
                heros[2] = 1;
                //enableDone();
            }
            else
            {
                //Nothing occurs, all spots filled
            }
        }

        private void btnKitten_Click(object sender, RoutedEventArgs e)
        {
            if (imgFirst.Source == null)
            {
                imgFirst.Source = new BitmapImage(new Uri("pack://application:,,,/Images/kitten.png", UriKind.Absolute));
                heros[0] = 1;
            }
            else if (imgSecond.Source == null)
            {
                imgSecond.Source = new BitmapImage(new Uri("pack://application:,,,/Images/kitten.png", UriKind.Absolute));
                heros[1] = 1;
            }
            else if (imgThird.Source == null)
            {
                imgThird.Source = new BitmapImage(new Uri("pack://application:,,,/Images/kitten.png", UriKind.Absolute));
                heros[2] = 1;
                //enableDone();
            }
            else
            {
                //Nothing occurs, all spots filled
            }
        }

        private void btnDuck_Click(object sender, RoutedEventArgs e)
        {
            if (imgFirst.Source == null)
            {
                imgFirst.Source = new BitmapImage(new Uri("pack://application:,,,/Images/duck.png", UriKind.Absolute));
                heros[0] = 1;
            }
            else if (imgSecond.Source == null)
            {
                imgSecond.Source = new BitmapImage(new Uri("pack://application:,,,/Images/duck.png", UriKind.Absolute));
                heros[1] = 1;
            }
            else if (imgThird.Source == null)
            {
                imgThird.Source = new BitmapImage(new Uri("pack://application:,,,/Images/duck.png", UriKind.Absolute));
                heros[2] = 1;
                //enableDone();
            }
            else
            {
                //Nothing occurs, all spots filled
            }
        }

        private void btnDog_Click(object sender, RoutedEventArgs e)
        {
            if (imgFirst.Source == null)
            {
                imgFirst.Source = new BitmapImage(new Uri("pack://application:,,,/Images/puppy.png", UriKind.Absolute));
                heros[0] = 1;
            }
            else if (imgSecond.Source == null)
            {
                imgSecond.Source = new BitmapImage(new Uri("pack://application:,,,/Images/puppy.png", UriKind.Absolute));
                heros[1] = 1;
            }
            else if (imgThird.Source == null)
            {
                imgThird.Source = new BitmapImage(new Uri("pack://application:,,,/Images/puppy.png", UriKind.Absolute));
                heros[2] = 1;
                //enableDone();
            }
            else
            {
                //Nothing occurs, all spots filled
            }
        }

        private void btnTurtle_Click(object sender, RoutedEventArgs e)
        {
            if (imgFirst.Source == null)
            {
                imgFirst.Source = new BitmapImage(new Uri("pack://application:,,,/Images/tinyTurtle.png", UriKind.Absolute));
                heros[0] = 1;
            }
            else if (imgSecond.Source == null)
            {
                imgSecond.Source = new BitmapImage(new Uri("pack://application:,,,/Images/tinyTurtle.png", UriKind.Absolute));
                heros[1] = 1;
            }
            else if (imgThird.Source == null)
            {
                imgThird.Source = new BitmapImage(new Uri("pack://application:,,,/Images/tinyTurtle.png", UriKind.Absolute));
                heros[2] = 1;
                //enableDone();
            }
            else
            {
                //Nothing occurs, all spots filled
            }
        }

        private void btnOwl_Click(object sender, RoutedEventArgs e)
        {
            if (imgFirst.Source == null)
            {
                imgFirst.Source = new BitmapImage(new Uri("pack://application:,,,/Images/owl.png", UriKind.Absolute));
                heros[0] = 1;
            }
            else if (imgSecond.Source == null)
            {
                imgSecond.Source = new BitmapImage(new Uri("pack://application:,,,/Images/owl.png", UriKind.Absolute));
                heros[1] = 1;
            }
            else if (imgThird.Source == null)
            {
                imgThird.Source = new BitmapImage(new Uri("pack://application:,,,/Images/owl.png", UriKind.Absolute));
                heros[2] = 1;
                //enableDone();
            }
            else
            {
                //Nothing occurs, all spots filled
            }
        }
    }
}
