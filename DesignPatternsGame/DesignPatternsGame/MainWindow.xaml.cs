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
        MonsterParty mparty;
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

        public void printPath()
        {
            int overlapLeft = 0;
            int overlapTop = 0;

            for (int i = 0; i < ara.GetLength(1); i++)
            {
                for (int j = 0; j < ara.GetLength(0); j++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Height = 70;
                    rect.Width = 70;
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
                    overlapLeft += 70;
                }
                overlapTop += 70;
                overlapLeft = 0;
            }
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            //Create a new game
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure?", "Quit Game?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void battle_Click(object sender, RoutedEventArgs e)
        {
            HeroFactory hf = new HeroFactory();
            GameCharacter h1 = hf.createCharacter(1);
            GameCharacter h2 = hf.createCharacter(2);
            GameCharacter h3 = hf.createCharacter(3);
            hparty.Characters.AddLast(h1);
            hparty.Characters.AddLast(h2);
            hparty.Characters.AddLast(h3);

            //BattleWindow bw = new BattleWindow();
            //bw.Show();
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
            if(cbSize.SelectedIndex == 0)
            {
                path = new PathGen(0);
            }
            else if(cbSize.SelectedIndex == 1)
            {
                path = new PathGen(1);
            }
            else
            {
                path = new PathGen(2);
            }
            
            path.getPath();
            ara = path.getPathToPrint();
            printPath();

            cbSize.IsEnabled = false;
            btnStartGame.IsEnabled = false;
            pickCharacters();
        }

    }
}
