using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battle.State
{
    public class BeginBattle : BattleState
    {
        
        public BeginBattle(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            BattleSystem.UI.SetBattleText(".");
            BattleSystem.UI.TextDots.Enable();
            var messages = new[] {
                $"A wild {BattleSystem.Enemy.ActivePokemon.Name} appeared",
                "Battle commences",
            };
            BattleSystem.UI.MessageQueue.StartMessageQueue(messages, new PlayerTurn(BattleSystem));
            yield break;
        }

        public override IEnumerator Cleanup()
        {
            BattleSystem.UI.TextDots.Disable();
            yield break;
        }
    }
}