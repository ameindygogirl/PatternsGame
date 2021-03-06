﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesignPatternsGame
{
    public class WiseOwl: Hero
    {
        public WiseOwl()
        {
            Name = "Wise Owl";
            TotalHP = 100;
            HP = TotalHP;
            Speed = 30;
            MaxDamage = 45;
            MinDamage = 20;
            HitChance = 90;
            Defense = 3;
            img = ImageFactory.findImage("owl");
            special = new FireBallSpecial();
        }
    }
}
