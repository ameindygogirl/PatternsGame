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
        int PAUSE = 1000;
        Action action;
        HeroParty heroes;
        MonsterParty monsters;
        GameCharacter myTurn;
        GameCharacter target;
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

        public void beginTurn()
        {
            if (heroes.isDead() == false && monsters.isDead() == false)
            {
                cur = cur.Next;
                if (cur == turnList.Last.Next)
                    cur = turnList.First;

                myTurn = cur.Value;

                battlePrompt.Text.Remove(0);
                battlePrompt.Text = myTurn.Name;

                if (myTurn is Monster)
                    monsterStart();
                else
                {
                    battlePrompt.Text = "Please choose an action";
                    actionSwitch(1);
                }
            }
            
            if (heroes.isDead())
            {
                battlePrompt.Text = "Game Over";
                System.Threading.Thread.Sleep(PAUSE);
                Environment.Exit(0);
            }
            else if(monsters.isDead())
            {
                battlePrompt.Text = "Enemies defeated";
                System.Threading.Thread.Sleep(PAUSE);
                Environment.Exit(0);
            }
        }

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

        // Recursive until hero's turn
        private void monsterStart()
        {
            Monster m = (Monster)myTurn;
            action = m.pickAction();
            action.Target = m.pickTarget(heroes.Characters);
            target = action.Target;
            action.execute();
            action.toString();
            System.Threading.Thread.Sleep(PAUSE);
            myTurn = null;
            target = null;
            action = null;
            beginTurn();
        }

        private void pickItem()
        {

        }

        //Switches --------------------------------------->

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

        private void heroSwitch(int i)
        {
            if (i >= 0)
            {
                if (heroes.Characters.ElementAt(0).HP > 0)
                    heroImg1.IsEnabled = true;

                if (heroes.Characters.ElementAt(1).HP > 0)
                    heroImg2.IsEnabled = true;

                if (heroes.Characters.ElementAt(2).HP > 0)
                    heroImg3.IsEnabled = true;
            }
            else
            {
                heroImg1.IsEnabled = false;
                heroImg2.IsEnabled = false;
                heroImg3.IsEnabled = false;
            }
        }

        private void monsterSwitch(int i)
        {
            if(i >= 0)
            {
                if (monsters.Characters.ElementAt(0).HP > 0)
                    enemyImg1.IsEnabled = true;

                if (monsters.Characters.ElementAt(1).HP > 0)
                    enemyImg2.IsEnabled = true;

                if (monsters.Characters.ElementAt(2).HP > 0)
                    enemyImg3.IsEnabled = true;
            }
            else
            {
                enemyImg1.IsEnabled = false;
                enemyImg2.IsEnabled = false;
                enemyImg3.IsEnabled = false;
            }
        }

        //Images ----------------------------------------------->

        public void showHeroes()
        {
            if (heroes.Characters.Count >= 1)
            {
                heroImg1.Background = new ImageBrush(heroes.Characters.ElementAt(0).Img);
                heroImg1.IsEnabled = false;
                heroImg1.Visibility = Visibility.Visible;
            }
            if (heroes.Characters.Count >= 2)
            {
                heroImg2.Background = new ImageBrush(heroes.Characters.ElementAt(1).Img);
                heroImg2.IsEnabled = false;
                heroImg2.Visibility = Visibility.Visible;
            }
            if (heroes.Characters.Count == 3)
            {
                heroImg3.Background = new ImageBrush(heroes.Characters.ElementAt(2).Img);
                heroImg3.IsEnabled = false;
                heroImg3.Visibility = Visibility.Visible;
            }
        }

        public void showMonsters()
        {
            if (monsters.Characters.Count >= 1)
            {
                enemyImg1.Background = new ImageBrush(monsters.Characters.ElementAt(0).Img);
                enemyImg1.IsEnabled  = false;
                enemyImg1.Visibility = Visibility.Visible;
            }
            if (monsters.Characters.Count >= 2)
            {
                enemyImg2.Background = new ImageBrush(monsters.Characters.ElementAt(1).Img);
                enemyImg2.IsEnabled  = false;
                enemyImg2.Visibility = Visibility.Visible;
            }
            if (monsters.Characters.Count == 3)
            {
                enemyImg3.Background = new ImageBrush(monsters.Characters.ElementAt(2).Img);
                enemyImg3.IsEnabled  = false;
                enemyImg3.Visibility = Visibility.Visible;
            }
        }

        //Buttons ----------------------------------------------->

        private void attackButton_Click(object sender, RoutedEventArgs e)
        {
            heroSwitch(0);
            action = new AttackAction();
            battlePrompt.Text = "Please choose a target";
            monsterSwitch(1);
        }

        private void defendButton_Click(object sender, RoutedEventArgs e)
        {
            heroSwitch(0);
            monsterSwitch(0);
            action = new DefendAction();
            beginTurn();
        }

        private void specialButton_Click(object sender, RoutedEventArgs e)
        {
            heroSwitch(0);
            action = new FireBallSpecial();
            battlePrompt.Text = "Please choose a target";
            monsterSwitch(1);
        }

        private void itemButton_Click(object sender, RoutedEventArgs e)
        {
            monsterSwitch(0);
            heroSwitch(0);
            battlePrompt.Text = "Please select an item";
            Item item = new HealthPotion(1);
            action = new ItemAction(item);
            battlePrompt.Text = "Please choose a target";
            heroSwitch(1);
        }

        // Enemy Buttons ------------------------------------->

        private void enemyImg1_Click(object sender, RoutedEventArgs e)
        {
            monsterSwitch(0);
            target = monsters.Characters.ElementAt(0);
            action.execute();
            action.toString();
            if (target.HP <= 0)
            {
                battlePrompt.Text = target.Name + " is slain!";
                enemyTint1.Visibility = Visibility.Visible;
                turnList.Remove(target);
            }
            beginTurn();
        }

        private void enemyImg2_Click(object sender, RoutedEventArgs e)
        {
            monsterSwitch(0);
            target = monsters.Characters.ElementAt(1);
            action.execute();
            action.toString();
            if (target.HP <= 0)
            {
                battlePrompt.Text = target.Name + " is slain!";
                enemyTint1.Visibility = Visibility.Visible;
                turnList.Remove(target);
            }
            beginTurn();
        }

        private void enemyImg3_Click(object sender, RoutedEventArgs e)
        {
            monsterSwitch(0);
            target = monsters.Characters.ElementAt(2);
            action.execute();
            action.toString();
            if (target.HP <= 0)
            {
                battlePrompt.Text = target.Name + " is slain!";
                enemyTint1.Visibility = Visibility.Visible;
                turnList.Remove(target);
            }
            beginTurn();
        }

        // Hero Buttons ------------------------------------------>

        private void heroImg1_Click(object sender, RoutedEventArgs e)
        {
            selectHero(0);
        }

        private void heroImg2_Click(object sender, RoutedEventArgs e)
        {
            selectHero(1);
        }

        private void heroImg3_Click(object sender, RoutedEventArgs e)
        {
            selectHero(2);
        }

        private void selectHero(int i)
        {
            heroSwitch(0);
            target = heroes.Characters.ElementAt(i);
            action.execute();
            action.toString();
            beginTurn();
        }
    }
}
