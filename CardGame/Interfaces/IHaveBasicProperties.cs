using CardGame.Cards;
using CardGame.InGameProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CardGame.Interfaces
{//Описание разных свойств карт например : тип урона, класс существа, имя, и прочее
    public interface IHaveBasicProperties
    {
          public string Name { get; }    
    }
}
