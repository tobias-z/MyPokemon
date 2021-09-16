using UnityEngine;

namespace _Project.Scripts.Battle.State
{
    public class BattleStateMachine : MonoBehaviour
    {
        protected BattleState State { get; private set; }

        public void SetState(BattleState battleState)
        {
            if (State != null) 
                StartCoroutine(State.Cleanup());
            
            State = battleState;
            StartCoroutine(battleState.Start());
        }
    }
}