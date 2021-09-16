using System;
using _Project.Scripts.Battle.State;
using UnityEngine;

namespace _Project.Scripts.Battle
{
    public class BattleSystem : BattleStateMachine
    {
        public BattleUIManager BattleUIManager { get; private set; }

        private void Awake()
        {
            BattleUIManager = GetComponent<BattleUIManager>();
        }

        // Player turn state
        // Enemy turn state

        private void Start()
        {
            SetState(new BeginBattle(this));
        }

        private void Update()
        {
            StartCoroutine(State.UpdateState());
        }
    }
}