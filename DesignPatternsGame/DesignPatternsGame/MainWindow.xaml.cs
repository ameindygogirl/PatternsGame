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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesignPatternsGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HeroParty hparty = new HeroParty();
        MonsterParty mparty = new MonsterParty();
        PathGen path;
        Room[,] ara;
        public MainWindow()
        {
            InitializeComponent();
            cbSize.SelectionChanged += cbSize_SelectionChanged;

        }

        void cbSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbSize.SelectedIndex != -1)
            {
                btnStartGame.IsEnabled = true;
            }
            else
            {
                btnStartGame.IsEnabled = false;
            }           
        }

        public void printPath(int tile)
        {
            int overlapLeft = 0;
            int overlapTop = 0;

            for (int i = 0; i < ara.GetLength(1); i++)
            {
                for (int j = 0; j < ara.GetLength(0); j++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Height = tile;
                    rect.Width = tile;
                    if (this.ara[i, j] != null)
                    {
                        if (this.ara[i, j].Entrance)
                        {
                            //("pack://application:,,,/img/txtBackground.png", UriKind.Absolute));
                            rect.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/enter.png", UriKind.Absolute)));
                        }
                        else if (this.ara[i, j].Exit)
                        {
                            rect.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/exit.png", UriKind.Absolute)));
                        }
                        else
                        {
                            rect.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/path.png", UriKind.Absolute)));
                        }
                    }
                    else
                    {
                        rect.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/wall.png", UriKind.Absolute)));
                    }
                    board.Children.Add(rect);
                    Canvas.SetLeft(rect, overlapLeft);
                    Canvas.SetTop(rect, overlapTop);
                    overlapLeft += tile;
                }
                overlapTop += tile;
                overlapLeft = 0;
            }
        }
       

        private void battle_Click(object sender, RoutedEventArgs e)
        {
            hparty.initParty();
            mparty.initParty();

            BattleWindow bw = new BattleWindow(hparty, mparty);
            bw.Show();
        }

        private void btnPickCharacters_Click(object sender, RoutedEventArgs e)
        {
            pickCharacters();
        }

        private static void pickCharacters()
        {
            CharacterPicker cp = new CharacterPicker();
            if (cp.ShowDialog() == true)
            {
                //New up the characters here
            }
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            int tile;
            if(cbSize.SelectedIndex == 0)
            {
                path = new PathGen(0);
                tile = 167;
            }
            else if(cbSize.SelectedIndex == 1)
            {
                path = new PathGen(1);
                tile = 105;
            }
            else
            {
                path = new PathGen(2);
                tile = 70;
            }
            
            
            ara = path.getPath();
            printPath(tile);

            cbSize.IsEnabled = false;
            btnStartGame.IsEnabled = false;
            pickCharacters();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            //Create a new game
            cbSize.SelectedIndex = -1;
            cbSize.IsEnabled = true;
            board.Children.Clear();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure?", "Quit Game?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnResults_Click(object sender, RoutedEventArgs e)
        {
            Results r = new Results(false);
            r.ShowDialog();
        }
    }
}
