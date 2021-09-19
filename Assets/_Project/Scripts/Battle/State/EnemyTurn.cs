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
            if (BattleSystem.Enemy.Action.IsDead())
                BattleSystem.Enemy.Action.Die();
            else
                yield return AttackPlayer();
        }

        private IEnumerator AttackPlayer()
        {
            BattleSystem.UI.SetBattleText($"'ENEMY_POKEMON' uses 'ABILITY_NAME'!");
            yield return new WaitForSeconds(1);
            BattleSystem.Enemy.Action.Attack(BattleSystem.Player);
            BattleSystem.StartCoroutine(SetPlayerTurnInOneSecond());
        }

        private IEnumerator SetPlayerTurnInOneSecond()
        {
            yield return new WaitForSeconds(1);
            BattleSystem.SetState(new PlayerTurn(BattleSystem));
        }
    }
}