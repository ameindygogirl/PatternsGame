using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace DesignPatternsGame
{
    public abstract class GameCharacter
    {
        protected string name;
        protected int totalHP;
        protected int hp;
        protected int speed;
        protected int maxDamage;
        protected int minDamage;
        protected double hitChance;
        protected double defense;
        protected Action action;
        protected BitmapImage img;
        protected SpecialAction special;
        protected GameCharacterList allies;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int TotalHP
        {
            get { return totalHP; }
            set { totalHP = value; }
        }

        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int MaxDamage
        {
            get { return maxDamage; }
            set { maxDamage = value; }
        }

        public int MinDamage
        {
            get { return minDamage; }
            set { minDamage = value; }
        }

        public double HitChance
        {
            get { return hitChance; }
            set { hitChance = value; }
        }

        public double Defense
        {
            get { return defense; }
            set { defense = value; }
        }
        
        public Action Action
        {
            get { return action; }
            set 
            { 
                action = value;
                action.Primary = this;
            }
        }

        public BitmapImage Img
        {
            get { return img; }
        }

        public SpecialAction Special
        {
            get { return special; }
            set { this.special = value; }
        }

        public GameCharacterList Allies
        {
            get { return allies; }
            set { allies = value; }
        }

        public void useSpecial(GameCharacter target)
        {
            this.special.execute();
        }

        /* returns true if this character defended on last turn, false otherwise */
        public bool subtractHP(int damage)
        {
            if (hp - damage < 0)
                hp = 0;
            else if (action is DefendAction)
            {
                hp = hp / 2;
                return true;
            }
            else
                hp = hp - damage;

            return false;
        }

        public void addHP(int heal)
        {
            if (hp + heal > totalHP)
                hp = totalHP;
            else
                hp = hp + heal;
        }

        public bool revive(int health)
        {
            if (hp != 0)
                return false;

            hp = health;
            return true;
        }
    }
}