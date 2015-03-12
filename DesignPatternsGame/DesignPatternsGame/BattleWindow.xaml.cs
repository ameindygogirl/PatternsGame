using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

    public partial class BattleWindow : Window, INotifyPropertyChanged
    {
        HeroParty heroes;
        MonsterParty monsters;
        GameCharacter myTurn;
        GameCharacterList turnList;
        LinkedListNode<GameCharacter> cur;
        String prompt = "";

        public BattleWindow(HeroParty heroes2, MonsterParty monsters2)
        {
            HealthPotion potion = new HealthPotion(5);
            heroes2.addItem(potion);

            heroes = heroes2;
            monsters = monsters2;

            turnList = initTurnList(heroes, monsters);
            cur = turnList.First;

            InitializeComponent();
            this.DataContext = this;
            this.Show();
            actionSwitch(0);
            prompt = "Let the battle begin!";
            addPrompt(prompt);
            showHeroes();
            showMonsters();
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
                monsterStart();

            else
            {
                prompt = myTurn.Name + ": please choose an action";
                addPrompt(prompt);
                continueButton.IsEnabled = false;
                actionSwitch(1);
            }
            endCondition();
        }

        // ENDCONDITION
        private void endCondition()
        {
            if (heroes.isDead())
            {
                prompt = "Game Over";
                addPrompt(prompt);
                continueButton.Content = "END";
            }
            else if (monsters.isDead())
            {
                prompt = "Enemies defeated";
                addPrompt(prompt);
                continueButton.Content = "END";
            }
        }
        
        // ISFINISHED
        private bool isFinished()
        {
            if (heroes.isDead())
                return true;
            
            else if(monsters.isDead())
                return true;

            return false;
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
            prompt = myTurn.Action.toString();
            addPrompt(prompt);
            
            if(myTurn.Action.Target.HP <= 0)
            {
                prompt = myTurn.Action.Target.Name + " has collapsed!";
                addPrompt(prompt);
                heroTint(myTurn.Action.Target, 1);
            }
            myTurn = null;
        }

        // HEROTINT
        private void heroTint(GameCharacter gc, int i)
        {
            LinkedListNode<GameCharacter> cur = heroes.Characters.First;

            int index = 0;
            while(cur.Value != gc)
            {
                cur = cur.Next;
                index++;
            }
            switch(index)
            {
                case 0:
                    if (i > 0)
                        heroTint1.Visibility = Visibility.Visible;
                    else
                        heroTint1.Visibility = Visibility.Hidden;
                    break;

                case 1:
                    if (i > 0)
                        heroTint2.Visibility = Visibility.Visible;
                    else
                        heroTint2.Visibility = Visibility.Hidden;
                    break;

                case 2:
                    if (i > 0)
                        heroTint3.Visibility = Visibility.Visible;
                    else
                        heroTint3.Visibility = Visibility.Hidden;
                    break;
            }


        }

        // PICKITEM
        private void pickItem()
        {

        }

        // ACTIONSWITCH
        private void actionSwitch(int i)
        {
            if (i <= 0)
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
                    heroB1.Visibility   = Visibility.Visible;
                    heroImg1.Visibility = Visibility.Hidden;
                }
                if (heroes.Characters.ElementAt(1).HP > 0)
                {
                    heroB2.Visibility   = Visibility.Visible;
                    heroImg2.Visibility = Visibility.Hidden;
                }
                if (heroes.Characters.ElementAt(2).HP > 0)
                {
                    heroB3.Visibility   = Visibility.Visible;
                    heroImg3.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                heroImg1.Visibility = Visibility.Visible;
                heroImg2.Visibility = Visibility.Visible;
                heroImg3.Visibility = Visibility.Visible;
                heroB1.Visibility   = Visibility.Hidden;
                heroB2.Visibility   = Visibility.Hidden;
                heroB3.Visibility   = Visibility.Hidden;
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
            prompt = "Please choose a target";
            addPrompt(prompt);
            monsterSwitch(1);
        }

        // DEFENDBUTTON_CLICK
        private void defendButton_Click(object sender, RoutedEventArgs e)
        {
            heroSwitch(0);
            monsterSwitch(0);
            myTurn.Action = new DefendAction();
            myTurn.Action.execute();
            prompt = myTurn.Action.toString();
            addPrompt(prompt);
            
        }

        // SPECIALBUTTON_CLICK
        private void specialButton_Click(object sender, RoutedEventArgs e)
        {
            heroSwitch(0);
            Random rnd = new Random();
            int choice = rnd.Next(1, 4);
            switch(choice)
            {
                case 1:
                    myTurn.Action = new FireBallSpecial();
                    break;
                case 2:
                    myTurn.Action = new CutenessSpecial();
                    break;
                case 3:
                    myTurn.Action = new ExtraStrengthSpecial();
                    break;
            }
            
            prompt = "Please choose a target";
            addPrompt(prompt);
            monsterSwitch(1);
        }

        // ITEMBUTTON_CLICK
        private void itemButton_Click(object sender, RoutedEventArgs e)
        {
            monsterSwitch(0);
            heroSwitch(0);
            prompt = "Please select an item";
            Item item = new HealthPotion(1);
            myTurn.Action = new ItemAction(item);
            prompt = "Please choose a target";
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
            prompt = myTurn.Action.toString();
            addPrompt(prompt);

            if (myTurn.Action.Target.HP <= 0)
            {
                prompt = myTurn.Action.Target.Name + " is slain!";
                addPrompt(prompt);
            }
            endCondition();
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
            prompt = myTurn.Action.toString();
            addPrompt(prompt);
        }

        public void addPrompt(string s)
        {
            PromptData = s;
            actionSwitch(0);
            continueButton.IsEnabled = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void RaisePropertyChanged(String propName)
        {
            System.Threading.Thread.Sleep(100);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private string promptData;
        public string PromptData
        {
            get { return promptData; }
            set { promptData = value; RaisePropertyChanged("PromptData"); }
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            if (isFinished())
                this.Close();

            continueButton.IsEnabled = false;
            beginTurn();
        }

        // PROMPTCALLBACK
        //public void promptCallBack(UpdatePrompt up)
        //{
        //    callback("Hello World");
        //}
    }
}
