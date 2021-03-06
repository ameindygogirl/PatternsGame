﻿using System;
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
    /// Interaction logic for PickItem.xaml
    /// </summary>
    public partial class PickItem : Window
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private int item;
        public int Item
        {
            get { return item; }
        }

        public PickItem(ItemList items)
        {
            InitializeComponent();
            LinkedListNode<Item> cur = items.First;
            while (cur != items.Last.Next)
            {
                if(cur.Value.Name == "Health Potion")
                {
                    if (cur.Value.Amount == 0)
                    {
                        btnHealthTint.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        btnHealthTint.Visibility = Visibility.Hidden;
                    }
                    lblHealth.Content = cur.Value.toString();
                }
                else if(cur.Value.Name == "Snack Pack")
                {
                    if (cur.Value.Amount == 0)
                    {
                        btnSnackTint.Visibility = Visibility.Visible;
                    }
                    else
                        btnSnackTint.Visibility = Visibility.Hidden;
                    
                    lblSnack.Content = cur.Value.toString();
                }
                else
                {
                    if (cur.Value.Amount == 0)
                    {
                        btnCollarTint.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        btnCollarTint.Visibility = Visibility.Hidden;
                    }
                    lblCollar.Content = cur.Value.toString();
                }
                cur = cur.Next;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        private void btnCollar_Click(object sender, RoutedEventArgs e)
        {
            item = 2;
            DialogResult = true; 
        }

        private void btnHealth_Click(object sender, RoutedEventArgs e)
        {
            item = 1;
            DialogResult = true;
        }

        private void btnSnack_Click(object sender, RoutedEventArgs e)
        {
            item = 3;
            DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            item = 0;
            DialogResult = true;
        }
    }
}
