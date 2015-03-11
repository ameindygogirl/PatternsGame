using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
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
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public int[] heros = new int[3];
        BitmapImage chipmunk = ImageFactory.findImage("chipmunk");
        BitmapImage kitten = ImageFactory.findImage("kitten");
        BitmapImage duck = ImageFactory.findImage("duck");
        BitmapImage dog = ImageFactory.findImage("dog");
        BitmapImage turtle = ImageFactory.findImage("turtle"); 
        BitmapImage owl = ImageFactory.findImage("owl");
        int chip = 1;
        int kit = 2;
        int duckling = 3;
        int dg = 4;
        int trt = 5;
        int ow = 6;
        public CharacterPicker()
        {
            InitializeComponent();
            
        }

        private void picture_Click(Object sender, RoutedEventArgs e)
        {
            BitmapImage img;
            int character;
            Button b = (Button)sender;
            if(b.Name == "btnChip")
            {
                img = chipmunk;
                character = chip;
            }
            else if(b.Name == "btnKitten")
            {
                img = kitten;
                character = kit;
            }
            else if(b.Name == "btnDuck")
            {
                img = duck;
                character = duckling;
            }
            else if(b.Name == "btnTurtle")
            {
                img = turtle;
                character = trt;
            }
            else if(b.Name == "btnOwl")
            {
                img = owl;
                character = ow;
            }
            else
            {
                img = dog;
                character = dg;
            }

            if (imgFirst.Source == null)
            {
                imgFirst.Source = img;
                heros[0] = character;
                btnDeleteFirst.IsEnabled = true;
                enableDone();
            }
            else if (imgSecond.Source == null)
            {
                imgSecond.Source = img;
                heros[1] = character;
                btnDeleteSecond.IsEnabled = true;
                enableDone();
            }
            else if (imgThird.Source == null)
            {
                imgThird.Source = img;
                heros[2] = character;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
    }
}
