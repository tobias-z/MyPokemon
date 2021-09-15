using UnityEngine;

namespace _Project.Scripts.Battle.State
{
    public class BattleStateMachine : MonoBehaviour
    {
        protected BattleState BattleState;
        
        public void SetState(BattleState battleState)
        {
            BattleState = battleState;
            StartCoroutine(battleState.Start());
        }
    }
}