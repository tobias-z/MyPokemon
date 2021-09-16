using _Project.Scripts.Battle.State;

namespace _Project.Scripts.Battle
{
    public class BattleSystem : BattleStateMachine
    {
        public IBattleUIManager BattleUIManager { get; private set; }

        private void Awake()
        {
            BattleUIManager = GetComponent<IBattleUIManager>();
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