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
            Debug.Log("Died");
            BattleSystem.Player.ActivateNextPokemon();
            if (BattleSystem.Player.ActivePokemon == null)
                BattleSystem.UI.SetBattleText("You lost :(");
            else 
                BattleSystem.SetState(new PlayerTurn(BattleSystem));
            
            yield break;
        }
    }
}