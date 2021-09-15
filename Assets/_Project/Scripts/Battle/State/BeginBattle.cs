using System.Collections;

namespace _Project.Scripts.Battle.State
{
    public class BeginBattle : BattleState
    {
        public BeginBattle(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            BattleSystem.BattleUIManager.SetBattleText("Starting battle");
            BattleSystem.BattleUIManager.AttackUI.Enable();
            yield break;
        }
    }
}