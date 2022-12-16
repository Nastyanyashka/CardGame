﻿using CardGame.InGameProperties;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CardGame.Interfaces.IAction;
using static CardGame.Interfaces.IEffects;

namespace CardGame.Cards
{
    public class Ogr:Card
    {
        public Ogr()
        {
            owner = null!;
            damage.Amount = 2;
            actions.Add(new Actions.Hit(damage.Amount));
            manaCost.Cost = 2;
            healthPoints.Amount = 5;
            name.Name = "Ogr";
        }
        public override object Clone()
        {
            return new Ogr();
        }
    }
}
