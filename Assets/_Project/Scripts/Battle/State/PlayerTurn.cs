using System.Collections;

namespace Battle.State
{
    public class PlayerTurn : BattleState
    {
        public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            BattleSystem.UI.AttackUI.Enable();
            BattleSystem.UI.SetBattleText($"What should {BattleSystem.Player.ActivePokemon.Name} do?");
            BattleSystem.UI.TextDots.Enable();
            yield break;
        }

        public override IEnumerator Cleanup()
        {
            BattleSystem.UI.TextDots.Disable();
            BattleSystem.UI.AttackUI.Disable();
            yield break;
        }
    }
}