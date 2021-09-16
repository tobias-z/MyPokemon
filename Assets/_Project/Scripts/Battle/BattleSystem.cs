using System;
using _Project.Scripts.Battle.State;
using _Project.Scripts.Core;

namespace _Project.Scripts.Battle
{
    
    public class BattleSystem : BattleStateMachine
    {
        public IBattleUIManager UI { get; private set; }
        public IEventManager EventManager { get; private set; }

        private void Awake()
        {
            UI = GetComponent<IBattleUIManager>();
            EventManager = GetComponent<IEventManager>();
        }
        
        // Player turn state
        // Enemy turn state

        private void Start()
        {
            SetState(new BeginBattle(this));
        }

        private void Update()
        {
            StartCoroutine(State.Update());
        }

    }
}