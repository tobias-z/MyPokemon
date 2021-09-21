using System.Collections;
using UnityEngine;

namespace Battle.State
{
    internal class EnemyTurn : BattleState
    {
        public EnemyTurn(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            if (BattleSystem.GameOver()) yield break;

            BattleSystem.UI.SetBattleText($"{BattleSystem.Enemy.ActivePokemon.Name} uses 'ABILITY_NAME'!");
            yield return new WaitForSeconds(1);
            BattleSystem.Enemy.Action.Attack(BattleSystem.Player);
            BattleSystem.StartCoroutine(SetPlayerTurnInOneSecond());
        }

        private IEnumerator SetPlayerTurnInOneSecond()
        {
            yield return new WaitForSeconds(1);

            if (BattleSystem.GameOver()) yield break;
            BattleSystem.SetState(new PlayerTurn(BattleSystem));
        }
    }
}