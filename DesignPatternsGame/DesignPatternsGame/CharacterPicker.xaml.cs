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
        BitmapImage chipmunk = new BitmapImage(new Uri("pack://application:,,,/Images/chipmunk.png", UriKind.Absolute));
        BitmapImage kitten = new BitmapImage(new Uri("pack://application:,,,/Images/kitten.png", UriKind.Absolute));
        BitmapImage duck = new BitmapImage(new Uri("pack://application:,,,/Images/duck.png", UriKind.Absolute));
        BitmapImage dog = new BitmapImage(new Uri("pack://application:,,,/Images/puppy.png", UriKind.Absolute));
        BitmapImage turtle = new BitmapImage(new Uri("pack://application:,,,/Images/tinyTurtle.png", UriKind.Absolute));
        BitmapImage owl = new BitmapImage(new Uri("pack://application:,,,/Images/owl.png", UriKind.Absolute));
        public CharacterPicker()
        {
            InitializeComponent();
        }

        private void picture_Click(Object sender, RoutedEventArgs e)
        {
            BitmapImage img;
            Button b = (Button)sender;
            if(b.Name == "btnChip")
            {
                img = chipmunk;
            }
            else if(b.Name == "btnKitten")
            {
                img = kitten;
            }
            else if(b.Name == "btnDuck")
            {
                img = duck;
            }
            else if(b.Name == "btnTurtle")
            {
                img = turtle;
            }
            else if(b.Name == "btnOwl")
            {
                img = owl;
            }
            else
            {
                img = dog;
            }

            if (imgFirst.Source == null)
            {
                imgFirst.Source = img;
                heros[0] = 1;
                btnDeleteFirst.IsEnabled = true;
                enableDone();
            }
            else if (imgSecond.Source == null)
            {
                imgSecond.Source = img;
                heros[1] = 1;
                btnDeleteSecond.IsEnabled = true;
                enableDone();
            }
            else if (imgThird.Source == null)
            {
                imgThird.Source = img;
                heros[2] = 1;
                btnDeleteThird.IsEnabled = true;
                enableDone();
            }
            else
            {
                //Nothing occurs, all spots filled
            }
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void enableDone()
        {
            if(imgFirst.Source != null && imgSecond.Source != null && imgThird.Source != null)
            {
                btnDone.IsEnabled = true;
            }
            else
            {
                btnDone.IsEnabled = false;
            }   
        }

        private void btnDeleteFirst_Click(object sender, RoutedEventArgs e)
        {
            imgFirst.Source = null;
            btnDeleteFirst.IsEnabled = false;
            enableDone();
        }

        private void btnDeleteSecond_Click(object sender, RoutedEventArgs e)
        {
            imgSecond.Source = null;
            btnDeleteSecond.IsEnabled = false;
            enableDone();
        }

        private void btnDeleteThird_Click(object sender, RoutedEventArgs e)
        {
            imgThird.Source = null;
            btnDeleteThird.IsEnabled = false;
            enableDone();
        }
    }
}
