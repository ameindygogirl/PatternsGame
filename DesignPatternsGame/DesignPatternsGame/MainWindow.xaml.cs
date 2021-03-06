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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesignPatternsGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int SMALL_MAZE = 120;
        private readonly int MEDIUM_MAZE = 80;
        private readonly int LARGE_MAZE = 50;

        int level;
        BattleWindow bw;
        Ellipse partyMarker;
        HeroParty hparty;
        PathGen path;
        Room[,] ara;
        RoomEvent myEvent;
        RobotFactory rfact;
        Player player;
        int mazeSize;

        public MainWindow()
        {
            level = 1;
            rfact = RobotFactory.getInstance();
            InitializeComponent();
            cbSize.SelectionChanged += cbSize_SelectionChanged;
            player = new Player(1);

            this.hparty = new HeroParty();   
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
        private void createPartyMarker(int size)
        {
            partyMarker = new Ellipse();
            partyMarker.Height = size-10;
            partyMarker.Width = size-10;
            if(size == SMALL_MAZE)
            {
                partyMarker.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/partySmall.png", UriKind.Absolute)));
            }
            else if(size == MEDIUM_MAZE)
            {
                partyMarker.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/partyMedium.png", UriKind.Absolute)));
            }
            else
            {
                partyMarker.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/partyLarge.png", UriKind.Absolute)));
            }
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
                            rect.Fill = new ImageBrush(ImageFactory.findImage("enter_"+player.Level));
                            enter = true;
                        }
                        else if (this.ara[i, j].Exit)
                        {
                            rect.Fill = new ImageBrush(ImageFactory.findImage("exit_"+player.Level));
                        }
                        else
                        {
                            rect.Fill = new ImageBrush(ImageFactory.findImage("path_"+player.Level));
                        }
                    }
                    else
                    {
                        rect.Fill = new ImageBrush(ImageFactory.findImage("wall_"+player.Level));
                    }
                    board.Children.Add(rect);
                    Canvas.SetLeft(rect, overlapLeft);
                    Canvas.SetTop(rect, overlapTop);
                    if(enter)
                    {
                        createPartyMarker(tile);
                        board.Children.Add(partyMarker);
                        Canvas.SetLeft(partyMarker, overlapLeft);
                        Canvas.SetTop(partyMarker, overlapTop);
                        enter = false;
                        player.Row = i;
                        player.Column = j;
                        player.CurLeft = overlapLeft;
                        player.CurTop = overlapTop;
                    }
                    overlapLeft += tile;
                }
                overlapTop += tile;
                overlapLeft = 0;
            }
        }
        
        private bool canMove(int row, int column)
        {
            //Check to see if out of bounds
            if(row > ara.GetLength(1)-1 || column > ara.GetLength(0)-1 || row < 0 || column < 0)
            {
                return false;
            }
            //Check for walls
            else if(ara[row,column] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void battle_Click(object sender, RoutedEventArgs e)
        {
            hparty = new HeroParty();

            bw = new BattleWindow(hparty, new MonsterParty());
            bw.Show();
        }

        private void btnPickCharacters_Click(object sender, RoutedEventArgs e)
        {
            pickCharacters();
           
        }

        private void pickCharacters()
        {
            CharacterPicker cp = new CharacterPicker();
            if (cp.ShowDialog() == true)
            {
                int char1, char2, char3;

                char1 = cp.heros[0];
                char2 = cp.heros[1];
                char3 = cp.heros[2];

                this.hparty = new HeroParty(char1, char2, char3);
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

        private void disableNavigation()
        {
            btnUp.Visibility = System.Windows.Visibility.Hidden;
            btnDown.Visibility = System.Windows.Visibility.Hidden;
            btnLeft.Visibility = System.Windows.Visibility.Hidden;
            btnRight.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            //Create a new game
            cbSize.SelectedIndex = -1;
            cbSize.IsEnabled = true;
            board.Children.Clear();
            disableNavigation();
            player.Level = 1;
        }

        private void levelUpMaze()
        {
            level++;
            board.Children.Clear();
            this.hparty.HasRobot = false;
            int tile;
            if (cbSize.SelectedIndex == 0)
            {
                path = new PathGen(0);
                tile = SMALL_MAZE;
                mazeSize = 0;
            }
            else if (cbSize.SelectedIndex == 1)
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
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(bw != null)
                bw.Topmost = false;
    
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure?", "Quit Game?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if(bw != null)
                    bw.Close();
    
                e.Cancel = false;
            }
            else
            {
                bw.Topmost = true;
                e.Cancel = true;
            }
        }

        private void btnResults_Click(object sender, RoutedEventArgs e)
        {
            Results r = new Results(false);
            r.ShowDialog();
        }

        // WHERE EVENTS HAPPEN
        private void enterRoom()
        {
            myEvent = this.ara[this.player.Row, this.player.Column].Event;
            if (myEvent != null)
            {
                myEvent.execute(hparty);
                if (!(myEvent is ItemEvent))
                {
                    bw = myEvent.BW;
                    if (bw != null)
                    {
                        disableNavigation();
                        navigationController.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        { 
            int newCord = player.Row - 1;
            if(canMove(newCord, player.Column))
            {
                int move;
                if (mazeSize == 0)
                {
                    move = player.CurTop - SMALL_MAZE;

                }
                else if (mazeSize == 1)
                {
                    move = player.CurTop - MEDIUM_MAZE;
                }
                else
                {
                    move = player.CurTop - LARGE_MAZE;
                }
                Canvas.SetTop(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurTop = move;
                player.Row = newCord;

                enterRoom();

                checkWon();
            }       
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            int newCord = player.Column + 1;
            if(canMove(player.Row, newCord))
            {
                int move;
                if (mazeSize == 0)
                {
                    move = player.CurLeft + SMALL_MAZE;       
                }
                else if (mazeSize == 1)
                {
                    move = player.CurLeft + MEDIUM_MAZE;
                }
                else
                {
                    move = player.CurLeft + LARGE_MAZE;
                }
                Canvas.SetLeft(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurLeft = move;
                player.Column = newCord;

                enterRoom();

                checkWon();
            }
            
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            int newCord = player.Column - 1;
            if(canMove(player.Row, newCord))
            {
                int move;
                if (mazeSize == 0)
                {
                    move = player.CurLeft - SMALL_MAZE;  
                }
                else if (mazeSize == 1)
                {
                    move = player.CurLeft - MEDIUM_MAZE;
                }
                else
                {
                    move = player.CurLeft - LARGE_MAZE;
                }
                Canvas.SetLeft(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurLeft = move;
                player.Column = newCord;

                enterRoom();

                checkWon();
            }
            
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            int newCord = player.Row + 1;
            if(canMove(newCord, player.Column))
            {
                int move;
                if (mazeSize == 0)
                {
                    move = player.CurTop + SMALL_MAZE;    
                }
                else if (mazeSize == 1)
                {
                    move = player.CurTop + MEDIUM_MAZE;
                }
                else
                {
                    move = player.CurTop + LARGE_MAZE;
                }
                Canvas.SetTop(partyMarker, move);
                Canvas.SetZIndex(partyMarker, 1);
                player.CurTop = move;
                player.Row = newCord;

                enterRoom();

                checkWon();
            }
            
        }

        private void checkWon()
        {
            if(hparty.HasRobot && ara[player.Row, player.Column].Exit && player.Level == 3)
            {
                Results r = new Results(true);
                if(r.ShowDialog() == true)
                {
                    Create_Click(null, null);
                }
                else
                {
                    disableNavigation();
                }
            }
            else if(!hparty.HasRobot && ara[player.Row, player.Column].Exit)
            {
                MessageBox.Show("Must have a robot to move on!");
            }
            else if(hparty.HasRobot && ara[player.Row, player.Column].Exit)
            {
                player.Level = player.Level + 1;
                levelUpMaze();
            }
            else
            {
                //Nothing occurs, player not at exit
            }
        }

        private void btnItemAwarded_Click(object sender, RoutedEventArgs e)
        {
            ItemAwarded ia = new ItemAwarded("Health Potion");
            ia.ShowDialog();
        }

        private void navigationController_Click(object sender, RoutedEventArgs e)
        {
            if(hparty.isDead())
            {
                Results r = new Results(false);
                r.ShowDialog();
            }
            else if (bw != null)
            {
                if (!bw.IsLoaded)
                {
                    if (myEvent is RobotEvent)
                    {
                        rfact.getRobot(hparty, level);
                    }
                    hparty.refresh();
                    enableNavigation();
                    navigationController.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.Topmost = false;
                    bw.Topmost = true;
                    ContinueNavigationWindow w = new ContinueNavigationWindow();
                    w.ShowDialog();
                }
            }
            else
            {
                enableNavigation();
                navigationController.Visibility = Visibility.Hidden;
            }
            myEvent.BW = null;
        }

        private String getRobotName()
        {
            if (level == 1)
                return "Escaflowne";
            if (level == 2)
                return "Unit 01";
            if (level == 3)
                return "GaoGaiGar";
            return null;
        }
    }
}
