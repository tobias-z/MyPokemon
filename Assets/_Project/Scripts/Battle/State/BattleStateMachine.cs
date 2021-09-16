using UnityEngine;

namespace _Project.Scripts.Battle.State
{
    public class BattleStateMachine : MonoBehaviour
    {
        public BattleState State { get; private set; }

        public void SetState(BattleState battleState)
        {
            State = battleState;
            StartCoroutine(battleState.Start());
        }
    }
}