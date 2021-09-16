using System.Collections;

namespace _Project.Scripts.Battle.State
{
    public class PlayerTurn : BattleState
    {
        public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            BattleSystem.BattleUIManager.AttackUI.Enable();
            BattleSystem.BattleUIManager.SetBattleText("What should 'POKEMON_NAME' do?");
            yield break;
        }
    }
}