using System.Collections;

namespace Battle.State
{
    public class WonBattle : BattleState
    {
        public WonBattle(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            BattleSystem.UI.SetBattleText("You won!");
            yield break;
        }
    }
}