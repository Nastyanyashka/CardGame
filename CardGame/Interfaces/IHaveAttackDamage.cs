using CardGame.InGameProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    public  interface IHaveAttackDamage
    {
        public int Damage { get; set; }
    }
}
