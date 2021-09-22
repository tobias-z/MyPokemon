using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

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

            var ability = BattleSystem.Enemy.ActivePokemon.Abilities[Random.Range(0, 4)];
            BattleSystem.UI.SetBattleText($"{BattleSystem.Enemy.ActivePokemon.Name} uses {ability.Name}!");
            yield return new WaitForSeconds(1);
            BattleSystem.Enemy.Action.Attack(BattleSystem.Player, ability);
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