using System.Collections;
using UnityEngine;

namespace Battle.State
{
    public class LostBattle : BattleState
    {
        public LostBattle(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            BattleSystem.UI.SetBattleText("You lost :(");
            yield break;
        }
    }
}