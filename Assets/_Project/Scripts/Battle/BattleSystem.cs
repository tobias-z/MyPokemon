using System;
using _Project.Scripts.Battle.State;
using UnityEngine;

namespace _Project.Scripts.Battle
{
    public class BattleSystem : BattleStateMachine
    {
        [SerializeField] private BattleUIManager battleUIManager;

        public BattleUIManager BattleUIManager => battleUIManager;

        // Player turn state
        // Enemy turn state

        private void Start()
        {
            SetState(new BeginBattle(this));
        }

        private void Update()
        {
            StartCoroutine(BattleState.UpdateState());
        }
    }
}