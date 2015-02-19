using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public abstract class Hero: GameCharacter
    {
        public override Action takeAction()
        {
            int option = 0;
            int limit = actions.Count;

            while (option >= 0 && option <= limit)
            {
                actions.printList();

                Console.WriteLine(Name);
                Console.Write("\nPlease choose a action: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out option) == true && (option >= 1 && option < limit))
                {
                    option = int.Parse(input);
                }
                else
                    Console.WriteLine("\nInvalid input");
            }
            Action selected = actions.getData(option);
            selected.Primary = this;
            return selected;
        }

        public override abstract void useSpecial(GameCharacter target);
    }
}
