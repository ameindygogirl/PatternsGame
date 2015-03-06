﻿using System;
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
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        public Results(bool win)
        {
            MediaElement me = new MediaElement();
            me.Volume = 1;
            InitializeComponent();
            if(win == true)
            {
                lblResults.Content = "Congratulations!";
                img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/won.png", UriKind.Absolute));
                me.Source = new Uri(@"Won.mp3", UriKind.Relative);
                res.Children.Add(me);
            }
            else
            {
                lblResults.Content = "Party Defeated!";
                img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/lost.png", UriKind.Absolute));
                me.Source = new Uri(@"Lost.mp3", UriKind.Relative);
                res.Children.Add(me);

            }
           
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
