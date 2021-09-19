using System.Collections.Generic;
using Battle.Pokemon;
using Battle.State;
using Core;

namespace Battle
{
    public class BattleSystem : BattleStateMachine
    {
        public IBattleUIManager UI { get; private set; }
        public IPokemonManager Player { get; private set; }
        public IPokemonManager Enemy { get; private set; }

        private void Awake()
        {
            UI = GetComponent<IBattleUIManager>();
            var managers = GetComponents<IPokemonManager>();
            Player = managers[0];
            Player.Init(this, GetComponent<Player>());
            Enemy = managers[1];
            Enemy.Init(this, GetEnemyPlayer());
        }

        private Player GetEnemyPlayer()
        {
            var enemyPlayer = gameObject.AddComponent<Player>();
            enemyPlayer.Name = "Bob";
            enemyPlayer.Pokemons = new List<IPokemon>()
            {
                new Core.Pokemon("Charmander", 15, 250)
            };
            return enemyPlayer;
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