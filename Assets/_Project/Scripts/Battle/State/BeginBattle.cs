using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Battle.UI;
using UnityEngine;

namespace Battle.State
{
    public class BeginBattle : BattleState
    {
        private readonly string[] _messages = {
            "A wild 'POKEMON_NAME' appeared",
            "Battle commences",
        };
        
        public BeginBattle(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            BattleSystem.UI.SetBattleText("...");
            BattleSystem.UI.TextDots.Enable();
            BattleSystem.UI.MessageQueue.SetMessageQueue(_messages, new PlayerTurn(BattleSystem));
            yield break;
        }

        public override IEnumerator Cleanup()
        {
            BattleSystem.UI.TextDots.Disable();
            yield break;
        }
    }
}