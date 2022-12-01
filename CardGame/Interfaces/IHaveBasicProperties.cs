using CardGame.InGameProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CardGame.Interfaces
{//Описание разных свойств карт например : тип урона, класс существа, имя, и прочее
    internal interface IHaveBasicProperties
    {
        public HealthPoints HealthPoints { get; set; }
        public AttackDamage Damage { get; set; }    
        public ManaCost ManaCost { get; set; }

        public string Name { get; }    
    }
}
