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

        public abstract void execute();
        //public abstract void undo();
    }
}