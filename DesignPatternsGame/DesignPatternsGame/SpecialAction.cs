﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsGame
{
    public abstract class SpecialAction: Action
    {
        protected int dmg;
        protected int hpUp;

        public abstract override void execute();
        public abstract override String toString();
    }
}
