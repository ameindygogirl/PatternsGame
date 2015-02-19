using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        protected ActionList actions;

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
        public ActionList Actions
        {
            get { return actions; }
            set { actions = value; }
        }

        public abstract Action takeAction();
        public abstract void useSpecial(GameCharacter target);

        /*public bool defense(GameCharacter d)
        {
            if (defenseChance >= new Random().NextDouble())
            {
                Console.WriteLine("Defense was successful.");
                return true;
            }
            else
            {
                Console.WriteLine("The defense was not successful.");
                return false;
            }
        }*/
    }
}