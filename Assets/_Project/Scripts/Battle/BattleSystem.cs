using Battle.State;

namespace Battle
{
    
    public class BattleSystem : BattleStateMachine
    {
        public IBattleUIManager UI { get; private set; }
        public IPokemon Player { get; private set; }
        public IPokemon Enemy { get; private set; }

        private void Awake()
        {
            UI = GetComponent<IBattleUIManager>();
            var pokemons = GetComponents<IPokemon>();
            Player = pokemons[0];
            Enemy = pokemons[1];
            Player.Attack(Enemy);
        }

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