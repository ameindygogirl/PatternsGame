using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public abstract class Action
    {
        protected string name;
        protected GameCharacter primary;
        protected GameCharacter target;
        protected GameCharacterList characters;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public GameCharacter Primary
        {
            get { return primary; }
            set { primary = (GameCharacter)value; }
        }
        public GameCharacter Target
        {
            get { return target; }
            set { target = value; }
        }
        public GameCharacterList Characters
        {
            get { return characters; }
            set { characters = value; }
        }

        public void chooseTarget()
        {
            int i, option = 0;
            do
            {
                i = 1;
                foreach(GameCharacter gc in characters)
                {
                    Console.WriteLine(i++ + ". " + gc.Name);
                }
                Console.Write("\nPlease choose a target: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out option) == true && (option >= 1 && option < i))
                {
                    option = int.Parse(input);
                }
                else
                    Console.WriteLine("\nInvalid input");
            }
            while(option >= 1 && option < i);

            i = 1;
            foreach (GameCharacter gc in characters)
            {
                if (i == option)
                    target = gc;
            }
        }
        public abstract void execute();
        //public abstract void undo();
    }
}