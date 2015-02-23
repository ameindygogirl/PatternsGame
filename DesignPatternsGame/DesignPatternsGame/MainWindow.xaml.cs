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
        PathGen path;
        Room[,] ara;
        public MainWindow()
        {
            InitializeComponent();
            path = new PathGen();
            path.getPath();
            ara = path.getPathToPrint();
            printPath();

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
                    rect.Height = 86;
                    rect.Width = 86;
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
                    overlapLeft += 86;
                }
                overlapTop += 86;
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
            HeroParty heroes = new HeroParty();
            heroes.initParty();
            HealthPotion potion = new HealthPotion(5);
            heroes.addItem(potion);

            MonsterParty monsters = new MonsterParty();
            monsters.initParty();

            Battle encounter = new Battle();
            encounter.Heroes = heroes;
            encounter.Monsters = monsters;
            encounter.start();
            Console.WriteLine("encounter complete");
        }

        private void attackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void battlePrompt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
