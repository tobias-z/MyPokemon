using System.Collections;
using System.Threading;
using UnityEngine;

namespace _Project.Scripts.Battle.State
{
    public class PlayerTurn : BattleState
    {
        public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            BattleSystem.UI.AttackUI.Enable();
            BattleSystem.UI.SetBattleText($"What should 'POKEMON_NAME' do?");
            BattleSystem.UI.TextDots.Enable();
            yield break;
        }

        public override IEnumerator Cleanup()
        {
            BattleSystem.UI.TextDots.Disable();
            yield break;
        }
    }
}