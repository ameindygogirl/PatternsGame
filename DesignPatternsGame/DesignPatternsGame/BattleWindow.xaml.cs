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
        public BattleWindow(HeroParty heroes, MonsterParty monsters) //incoming parameter = parties?
        {
            HealthPotion potion = new HealthPotion(5);
            heroes.addItem(potion);

            start(heroes, monsters);
        }
        private void attackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void battlePrompt_TextChanged(object sender, TextChangedEventArgs e, String message)
        {

        }

        public void start(HeroParty heroes, MonsterParty monsters)
        {
            GameCharacterList turnList = initTurnList(heroes, monsters);
            LinkedListNode<GameCharacter> myTurn = turnList.First;
            Action action = null;

            while(heroes.isDead() == false && monsters.isDead() == false)
            {
                if(myTurn == turnList.Last.Next)
                   myTurn = turnList.First;

                if (myTurn.Value.isHero())
                    action = takeAction(myTurn);

                else
                {
                    //monster's truen
                }
                action.Characters = turnList;
                action.Target = chooseTarget();
                action.execute();
                myTurn = myTurn.Next; 
            }

            if (heroes.isDead())
            {
                Console.WriteLine("Game Over");
            }
            else
            {
                Console.WriteLine("Enemies defeated");
            }
        }

        private GameCharacterList initTurnList(Party heroes, Party monsters)
        {
            GameCharacterList allCharacters = new GameCharacterList();
            LinkedListNode<GameCharacter> cur = heroes.Characters.First;
            while (cur != heroes.Characters.Last.Next)
            {
                allCharacters.AddFirst(cur.Value);
            }
            cur = monsters.Characters.First;
            while (cur != monsters.Characters.Last.Next)
            {
                allCharacters.AddFirst(cur.Value);
            }
            cur = null;
            allCharacters.sort();
            return allCharacters;
        }

        private Boolean confirmAction(Action action)
        {
            if(action.Primary is Monster)
                return true;

            Console.WriteLine(action.ToString() + "? (y/n)");
            String confirm = Console.ReadLine();
            if (confirm.ToLower().CompareTo("y") == 0)
                return true;

            return false;
        }

        private Action takeAction(object sender, TextChangedEventArgs e, Hero hero)
        {
            int option = 0;
            int limit = hero.Actions.Count;
            String s = null;

            Console.WriteLine(Name);
            s = "\n" + hero.Name + ", please choose an action";
            battlePrompt_TextChanged(sender, e, s);
            //option = clicked button
            Action selected = actions.getData(option);
            selected.Primary = hero;
            return selected;
        }
    }
}

