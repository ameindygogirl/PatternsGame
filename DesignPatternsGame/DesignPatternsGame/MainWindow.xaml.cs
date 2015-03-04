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
        private readonly int SMALL_MAZE = 167;
        private readonly int MEDIUM_MAZE = 105;
        private readonly int LARGE_MAZE = 70;

        Ellipse partyMarker;
        HeroParty hparty = new HeroParty();
        MonsterParty mparty = new MonsterParty();
        PathGen path;
        Room[,] ara;
        Player player;
        int mazeSize;
        public MainWindow()
        {
            InitializeComponent();
            cbSize.SelectionChanged += cbSize_SelectionChanged;
            createPartyMarker();
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
        private void createPartyMarker()
        {
            partyMarker = new Ellipse();
            partyMarker.Height = 65;
            partyMarker.Width = 65;
            partyMarker.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/party.png", UriKind.Absolute)));
        }
        public void printPath(int tile)
        {
            bool enter = false;
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
                            rect.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/enter.png", UriKind.Absolute)));
                            enter = true;
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
                    if(enter)
                    {
                        board.Children.Add(partyMarker);
                        Canvas.SetLeft(partyMarker, overlapLeft);
                        Canvas.SetTop(partyMarker, overlapTop);
                        enter = false;
                        player = new Player(i, j, overlapLeft, overlapTop);
                    }
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
                tile = SMALL_MAZE;
                mazeSize = 0;
            }
            else if(cbSize.SelectedIndex == 1)
            {
                path = new PathGen(1);
                tile = MEDIUM_MAZE;
                mazeSize = 1;
            }
            else
            {
                path = new PathGen(2);
                tile = LARGE_MAZE;
                mazeSize = 2; 
            }
            
            
            ara = path.getPath();
            printPath(tile);

            cbSize.IsEnabled = false;
            btnStartGame.IsEnabled = false;
            pickCharacters();

            enableNavigation();
        }

        private void enableNavigation()
        {
            btnUp.Visibility = System.Windows.Visibility.Visible;
            btnDown.Visibility = System.Windows.Visibility.Visible;
            btnLeft.Visibility = System.Windows.Visibility.Visible;
            btnRight.Visibility = System.Windows.Visibility.Visible;
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

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Moving up!");
            int move;
            if (mazeSize == 0)
            {
                move = player.CurTop - SMALL_MAZE;
                Canvas.SetTop(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurTop = move;
            }
            else if (mazeSize == 1)
            {
                move = player.CurTop - MEDIUM_MAZE;
                Canvas.SetTop(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurTop = move;
            }
            else
            {
                move = player.CurTop - LARGE_MAZE;
                Canvas.SetTop(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurTop = move;
            }
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            int move;
            MessageBox.Show("Moving right!");
            if (mazeSize == 0)
            {
                move = player.CurLeft + SMALL_MAZE;
                Canvas.SetLeft(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurLeft = move;
            }
            else if (mazeSize == 1)
            {
                move = player.CurLeft + MEDIUM_MAZE;
                Canvas.SetLeft(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurLeft = move;
            }
            else
            {
                move = player.CurLeft + LARGE_MAZE;
                Canvas.SetLeft(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurLeft = move;
            }
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            int move;
            MessageBox.Show("Moving left!");
            if (mazeSize == 0)
            {
                move = player.CurLeft - SMALL_MAZE;
                Canvas.SetLeft(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurLeft = move;
            }
            else if (mazeSize == 1)
            {
                move = player.CurLeft - MEDIUM_MAZE;
                Canvas.SetLeft(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurLeft = move;
            }
            else
            {
                move = player.CurLeft - LARGE_MAZE;
                Canvas.SetLeft(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurLeft = move;
            }
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Moving down!");
            int move;
            if (mazeSize == 0)
            {
                move = player.CurTop + SMALL_MAZE;
                Canvas.SetTop(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurTop = move;
            }
            else if (mazeSize == 1)
            {
                move = player.CurTop + MEDIUM_MAZE;
                Canvas.SetTop(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurTop = move;
            }
            else
            {
                move = player.CurTop + LARGE_MAZE;
                Canvas.SetTop(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurTop = move;
            }
        }
    }
}
