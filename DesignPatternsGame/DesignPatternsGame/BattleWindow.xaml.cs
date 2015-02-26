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
    /// Interaction logic for BattleWindow.xaml
    /// </summary>
    public partial class BattleWindow : Window
    {
        public BattleWindow() //incoming parameter = parties?
        {
            InitializeComponent();
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
        }
        private void attackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void battlePrompt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
