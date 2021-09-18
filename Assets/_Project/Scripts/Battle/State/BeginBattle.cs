using System.Collections;
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
            BattleSystem.UI.SetBattleText("Battle commences");
            BattleSystem.UI.TextDots.Enable();
            yield return new WaitForSeconds(2);
            BattleSystem.SetState(new PlayerTurn(BattleSystem));
        }

        public override IEnumerator Cleanup()
        {
            BattleSystem.UI.TextDots.Disable();
            yield break;
        }
    }
}