using System.Collections;
using UnityEngine;

namespace _Project.Scripts.Battle.State
{
    public class BeginBattle : BattleState
    {
        public BeginBattle(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            BattleSystem.BattleUIManager.SetBattleText("Battle commences...");
            yield return new WaitForSeconds(2);
            BattleSystem.BattleUIManager.SetBattleText("Player turn state");
        }
    }
}