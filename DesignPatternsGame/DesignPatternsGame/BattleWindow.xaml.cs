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
            action = null;

            InitializeComponent();
            battlePrompt.Text = "Let the battle begin!";
            showMonsters();
            this.Show();
            System.Threading.Thread.Sleep(1000);
            while (heroes.isDead() == false && monsters.isDead() == false)
            {
                action = null;

                if (cur == turnList.Last.Next)
                    cur = turnList.First;

                myTurn = cur.Value;

                battlePrompt.Text.Remove(0);
                battlePrompt.Text = myTurn.Name;

                if (myTurn is Monster)
                    monsterStart();
                else
                    Environment.Exit(0);
                    //playerStart();
            }

            if (heroes.isDead())
            {
                battlePrompt.Text = "Game Over";
            }

            else
            {
                battlePrompt.Text = "Enemies defeated";
            }
        }

        // Need "You win" pop up with "collect loot" button

        private void monsterStart()
        {
            Monster m = (Monster)myTurn;
            action = m.pickAction();
            action.Target = m.pickTarget(heroes.Characters);
            target = action.Target;
            
            //while (action == null) ;
            //action.Characters = monsters.Characters;

            //while (action.Target == null) ;

            action.execute();
            action = null;
        }

        private void playerStart()
        {

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

        //make sure that enemyImg is disabled after killed
        private void chooseTarget(object sender, TextChangedEventArgs e)
        {
            target = null;
            Image i = (Image)sender;
            switch (i.Name)
            {
                case "enemyImg1":
                    action.Target = monsters.Characters.First.Value;
                    break;
                case "enemyImg2":
                    action.Target = monsters.Characters.First.Next.Value;
                    break;
                case "enemyImg3":
                    action.Target = monsters.Characters.First.Next.Next.Value;
                    break;
            }
        }

        private void action_click(object sender, TextChangedEventArgs e)
        {
            action = null;
            Button b = (Button)sender;
            switch(b.Name)
            {
                case "attackButton":
                    action = new AttackAction();
                    battlePrompt.Text = "Please choose a target";
                    break;
                case "defendButton":
                    action = new DefendAction();
                    battlePrompt.Text = myTurn.Name + " defends";
                    break;
                case "specialButton":
                    action = new SpecialAction();
                    battlePrompt.Text = "Currently unavailable";
                    break;
                case "itemButton":
                    battlePrompt.Text = "Please choose an item";
                    //menu for items
                    Item item = new HealthPotion(5);
                    action = new ItemAction(item);
                    battlePrompt.Text = "Please choose a target";
                    break;
            }
            action.Primary = myTurn;
            System.Threading.Thread.Sleep(1000);
        }

        public void showMonsters()
        {
            if (monsters.Characters.Count >= 1)
            {
                enemyImg1.Background = new ImageBrush(monsters.Characters.ElementAt(0).Img);
                enemyImg1.Visibility = Visibility.Visible;
            }
            if (monsters.Characters.Count >= 2)
            {
                enemyImg2.Background = new ImageBrush(monsters.Characters.ElementAt(1).Img);
                enemyImg2.Visibility = Visibility.Visible;
            }
            if (monsters.Characters.Count == 3)
            {
                enemyImg3.Background = new ImageBrush(monsters.Characters.ElementAt(2).Img);
                enemyImg3.Visibility = Visibility.Visible;
            }
            else
                Environment.Exit(1);
        }

        private void attackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void enemyImg1_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void battlePrompt(object sender, TextChangedEventArgs e)
        //{
        //    TextBlock battlePrompt = new TextBlock();
        //    battlePrompt.Text = battlePrompt.Text;
        //}
    }
}
