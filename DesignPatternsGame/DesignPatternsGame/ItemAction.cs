using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public class ItemAction: Action
    {
        private ItemList items;
        private Item item;

        public ItemList Items
        {
            get { return items; }
            set { items = value; }
        }

        public override void execute()
        {
            items.printList();

            int option = 0;
            int limit = items.Count;
            while (option <= 0 || option > limit)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out option) == true && (option >= 1 && option < limit))
                {
                    option = int.Parse(input);
                }
                else
                    Console.WriteLine("\nInvalid input");
            }
            item = items.getItem(option);
            this.chooseTarget();
            item.use();
            if (item.Amount <= 0)
            {
                Items.Remove(item);
            }
        }

        public override string ToString()
        {
            return Primary.Name + " uses " + item.Name + " on " + item.Target.Name;
        }
    }
}
