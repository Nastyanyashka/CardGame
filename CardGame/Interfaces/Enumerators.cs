using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Interfaces
{
    public enum MomentsOfEvents
    {
        BeforeMove = 0,
        InMove,
        AfterMove,
        ReceivingMessage,
        SendingMessage,
        EnterTheGame,
        ExitTheGame,
        EveryMoment
    }
}
