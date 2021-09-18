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
            BattleSystem.UI.SetBattleText($"'ENEMY_POKEMON' uses 'ABILITY_NAME'!");
            yield return new WaitForSeconds(1);
            BattleSystem.Enemy.Attack(BattleSystem.Player);
            BattleSystem.StartCoroutine(SetPlayerTurnInOneSecond());
        }

        private IEnumerator SetPlayerTurnInOneSecond()
        {
            yield return new WaitForSeconds(1);
            BattleSystem.SetState(new PlayerTurn(BattleSystem));
        }
    }
}