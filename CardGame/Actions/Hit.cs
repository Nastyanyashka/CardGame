using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Actions
{
    internal class Hit : IHaveProperties, IAction
    {
        List<IProperties> properties = new List<IProperties>();
        public List<IProperties> Properties { get { return properties; } }

        public Hit()
        {

        }



        public object Clone()
        {
            return new Hit();
        }

        public IAction.Action GetActionMethod(ITakeMessage recipient = null)
        {
            throw new NotImplementedException();
        }
    }
}
