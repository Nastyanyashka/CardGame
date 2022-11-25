﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal interface IEffects
    {
        string Name { get; }
        string Description { get; }
        public int Duration { get; set; }
        public const int MaxDuration = 99;
    }
}
