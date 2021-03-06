﻿using System;
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

        public ItemEvent() : base()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 4);
            switch(num)
            {
                case 1:
                    this.loot = new HealthPotion(1);
                    break;
                case 2:
                    this.loot = new SnackPack(1);
                    break;
                case 3:
                    this.loot = new CollarOfPower(1);
                    break;
            }
        }

        public override void execute(HeroParty hparty)
        {
            if (triggered == true) return;
            hparty.addItem(loot);
            ItemAwarded ia = new ItemAwarded(loot.Name);
            ia.ShowDialog();
            triggered = true;
        }
    }
}
