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
    /// @author The Nikola Teslas
    /// Interaction logic for BattleWindow.xaml
    /// </summary>

    public partial class BattleWindow : Window
    {
        int PAUSE = 500;
        HeroParty heroes;
        MonsterParty monsters;
        GameCharacter myTurn;
        GameCharacterList turnList;
        LinkedListNode<GameCharacter> cur;

        public BattleWindow(HeroParty heroes2, MonsterParty monsters2) //incoming parameter = parties?
        {
            HealthPotion potion = new HealthPotion(5);
            heroes2.addItem(potion);

            heroes = heroes2;
            monsters = monsters2;

            turnList = initTurnList(heroes, monsters);
            cur = turnList.First;

            InitializeComponent();
            actionSwitch(0);
            battlePrompt.Text = "Let the battle begin!";
            showHeroes();
            showMonsters();
            this.Show();
            System.Threading.Thread.Sleep(PAUSE);
            beginTurn();
        }

        // BEGINTURN
        public void beginTurn()
        {
            cur = cur.Next;
            if (cur == turnList.Last.Next)
                cur = turnList.First;

            while(cur.Value.HP <= 0)
            {
                cur = cur.Next;
                if (cur == turnList.Last.Next)
                    cur = turnList.First;
            }
            myTurn = cur.Value;


            if (myTurn is Monster)
            {
                battlePrompt.Text = myTurn.Name;
                System.Threading.Thread.Sleep(PAUSE/2);
                monsterStart();
            }
            else
            {
                battlePrompt.Text = myTurn.Name + ": please choose an action";
                actionSwitch(1);
            }
        }

        // ENDCONDITION
        private void endCondition()
        {
            if (heroes.isDead())
            {
                battlePrompt.Text = "Game Over";
                System.Threading.Thread.Sleep(PAUSE * 2);
                Environment.Exit(0);
            }
            else if (monsters.isDead())
            {
                battlePrompt.Text = "Enemies defeated";
                System.Threading.Thread.Sleep(PAUSE*2);
                Environment.Exit(0);
            }
        }

        // INITTURNLIST
        private GameCharacterList initTurnList(Party heroes, Party monsters)
        {
            GameCharacterList allCharacters = new GameCharacterList();
            LinkedListNode<GameCharacter> cur = heroes.Characters.First;
            while (cur != heroes.Characters.Last.Next)
            {
                allCharacters.AddFirst(cur.Value);
                cur = cur.Next;
            }
            cur = monsters.Characters.First;
            while (cur != monsters.Characters.Last.Next)
            {
                allCharacters.AddFirst(cur.Value);
                cur = cur.Next;
            }
            cur = null;
            allCharacters.sort();
            return allCharacters;
        }

        // MONSTERSTART
        private void monsterStart()
        {
            Monster m = (Monster)myTurn;
            myTurn.Action = m.pickAction();
            myTurn.Action.Target = m.pickTarget(heroes.Characters);
            myTurn.Action.execute();
            myTurn.Action.toString();
            System.Threading.Thread.Sleep(PAUSE);
            
            if(myTurn.Action.Target.HP <= 0)
            {
                battlePrompt.Text = myTurn.Action.Target.Name + " has collapsed!";
            }
            myTurn = null;
            endCondition();
            beginTurn();
        }

        // PICKITEM
        private void pickItem()
        {

        }

        // ACTIONSWITCH
        private void actionSwitch(int i)
        {
            if (i < 0)
            {
                attackButton.IsEnabled  = false;
                defendButton.IsEnabled  = false;
                specialButton.IsEnabled = false;
                itemButton.IsEnabled    = false;
            }
            else
            {
                attackButton.IsEnabled  = true;
                defendButton.IsEnabled  = true;
                specialButton.IsEnabled = true;
                itemButton.IsEnabled    = true;
            }
        }

        // HEROSWITCH
        private void heroSwitch(int i)
        {
            if (i > 0)
            {
                if (heroes.Characters.ElementAt(0).HP > 0)
                {
                    heroB1.Visibility = Visibility.Visible;
                    heroImg1.Visibility = Visibility.Hidden;
                }
                if (heroes.Characters.ElementAt(1).HP > 0)
                {
                    heroB2.Visibility = Visibility.Visible;
                    heroImg2.Visibility = Visibility.Hidden;
                }
                if (heroes.Characters.ElementAt(2).HP > 0)
                {
                    heroB3.Visibility = Visibility.Visible;
                    heroImg3.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                heroImg1.Visibility = Visibility.Visible;
                heroImg2.Visibility = Visibility.Visible;
                heroImg3.Visibility = Visibility.Visible;
                heroB1.Visibility = Visibility.Hidden;
                heroB2.Visibility = Visibility.Hidden;
                heroB3.Visibility = Visibility.Hidden;
            }
        }

        // MONSTERSWITCH
        private void monsterSwitch(int i)
        {
            if(i > 0)
            {
                if (monsters.Characters.ElementAt(0).HP > 0)
                {
                    enemyImg1.Visibility = Visibility.Hidden;
                    enemyB1.Visibility = Visibility.Visible;
                }
                if (monsters.Characters.ElementAt(1).HP > 0)
                {
                    enemyImg2.Visibility = Visibility.Hidden;
                    enemyB2.Visibility = Visibility.Visible;
                }
                if (monsters.Characters.ElementAt(2).HP > 0)
                {
                    enemyImg3.Visibility = Visibility.Hidden;
                    enemyB3.Visibility = Visibility.Visible;
                }
            }
            else
            {
                enemyB1.Visibility = Visibility.Hidden;
                enemyB2.Visibility = Visibility.Hidden;
                enemyB3.Visibility = Visibility.Hidden;
                enemyImg1.Visibility = Visibility.Visible;
                enemyImg2.Visibility = Visibility.Visible;
                enemyImg3.Visibility = Visibility.Visible;
            }
        }

        // SHOWHEROES
        public void showHeroes()
        {
            if (heroes.Characters.Count >= 1)
            {
                heroB1.Background = new ImageBrush(heroes.Characters.ElementAt(0).Img);
                heroImg1.Visibility = Visibility.Visible;
                heroImg1.Source = heroes.Characters.ElementAt(0).Img;
                
                
            }
            if (heroes.Characters.Count >= 2)
            {
                heroB2.Background = new ImageBrush(heroes.Characters.ElementAt(1).Img);
                heroImg2.Visibility = Visibility.Visible;
                heroImg2.Source = heroes.Characters.ElementAt(1).Img;
            }
            if (heroes.Characters.Count == 3)
            {
                heroB3.Background = new ImageBrush(heroes.Characters.ElementAt(2).Img);
                heroImg3.Visibility = Visibility.Visible;
                heroImg3.Source = heroes.Characters.ElementAt(2).Img;
            }
        }

        // SHOWMONSTERS
        public void showMonsters()
        {
            if (monsters.Characters.Count >= 1)
            {
                enemyB1.Background = new ImageBrush(monsters.Characters.ElementAt(0).Img);
                enemyImg1.Source = monsters.Characters.ElementAt(0).Img;
                enemyImg1.Visibility = Visibility.Visible;
            }
            if (monsters.Characters.Count >= 2)
            {
                enemyB2.Background = new ImageBrush(monsters.Characters.ElementAt(1).Img);
                enemyImg2.Source = monsters.Characters.ElementAt(1).Img;
                enemyImg2.Visibility = Visibility.Visible;
            }
            if (monsters.Characters.Count == 3)
            {
                enemyB3.Background = new ImageBrush(monsters.Characters.ElementAt(2).Img);
                enemyImg3.Source = monsters.Characters.ElementAt(2).Img;
                enemyImg3.Visibility = Visibility.Visible;
            }
        }

        // ATTACKBUTTON_CLICK
        private void attackButton_Click(object sender, RoutedEventArgs e)
        {
            heroSwitch(0);
            myTurn.Action = new AttackAction();
            battlePrompt.Text = "Please choose a target";
            monsterSwitch(1);
        }

        // DEFENDBUTTON_CLICK
        private void defendButton_Click(object sender, RoutedEventArgs e)
        {
            heroSwitch(0);
            monsterSwitch(0);
            myTurn.Action = new DefendAction();
            myTurn.Action.execute();
            battlePrompt.Text = myTurn.Action.toString();
            System.Threading.Thread.Sleep(PAUSE);
            beginTurn();
        }

        // SPECIALBUTTON_CLICK
        private void specialButton_Click(object sender, RoutedEventArgs e)
        {
            heroSwitch(0);
            myTurn.Action = new FireBallSpecial();
            battlePrompt.Text = "Please choose a target";
            monsterSwitch(1);
        }

        // ITEMBUTTON_CLICK
        private void itemButton_Click(object sender, RoutedEventArgs e)
        {
            monsterSwitch(0);
            heroSwitch(0);
            battlePrompt.Text = "Please select an item";
            Item item = new HealthPotion(1);
            myTurn.Action = new ItemAction(item);
            battlePrompt.Text = "Please choose a target";
            heroSwitch(1);
        }

        // ENEMYB1_CLICK
        private void enemyB1_Click(object sender, RoutedEventArgs e)
        {
            monsterSwitch(0);
            myTurn.Action.Target = monsters.Characters.ElementAt(0);
            myTurn.Action.execute(); 
            
            if (myTurn.Action.Target.HP <= 0)
                enemyTint1.Visibility = Visibility.Visible;
            enemyClick();
        }

        // ENEMYB2_CLICK
        private void enemyB2_Click(object sender, RoutedEventArgs e)
        {
            monsterSwitch(0);
            myTurn.Action.Target = monsters.Characters.ElementAt(1);
            myTurn.Action.execute();

            if (myTurn.Action.Target.HP <= 0)
                enemyTint2.Visibility = Visibility.Visible;
            
            enemyClick();
        }

        // ENEMYB3_CLICK
        private void enemyB3_Click(object sender, RoutedEventArgs e)
        {
            monsterSwitch(0);
            myTurn.Action.Target = monsters.Characters.ElementAt(2);
            myTurn.Action.execute();

            if (myTurn.Action.Target.HP <= 0)
                enemyTint3.Visibility = Visibility.Visible;
            
            enemyClick();
        }

        // ENEMYCLICK
        private void enemyClick()
        {
            battlePrompt.Text = myTurn.Action.toString();
            System.Threading.Thread.Sleep(PAUSE);

            if (myTurn.Action.Target.HP <= 0)
                battlePrompt.Text = myTurn.Action.Target.Name + " is slain!";

            System.Threading.Thread.Sleep(PAUSE);
            endCondition();
            beginTurn();
        }

        // HEROIMG1_CLICK
        private void heroImg1_Click(object sender, RoutedEventArgs e)
        {
            selectHero(0);
        }

        // HEROIMG2_CLICK
        private void heroImg2_Click(object sender, RoutedEventArgs e)
        {
            selectHero(1);
        }

        // HEROIMG3_CLICK
        private void heroImg3_Click(object sender, RoutedEventArgs e)
        {
            selectHero(2);
        }

        // SELECTHERO
        private void selectHero(int i)
        {
            heroSwitch(0);
            myTurn.Action.Target = heroes.Characters.ElementAt(i);
            myTurn.Action.execute();
            battlePrompt.Text = myTurn.Action.toString();
            System.Threading.Thread.Sleep(PAUSE);
            beginTurn();
        }
    }
}
