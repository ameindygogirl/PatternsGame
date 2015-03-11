using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesignPatternsGame
{
    class ItemEvent : RoomEvent
    {
        Item loot;
       

        public ItemEvent()
        {
            
            this.loot = new HealthPotion(1);
        }

        void RoomEvent.execute(HeroParty hparty)
        {
            hparty.addItem(loot);

            string message = "Found a " + loot.Name + "!";
            string caption = "Loot!";

            MessageBox.Show(message, caption);

        }

    }
}
