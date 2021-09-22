using System.Collections.Generic;
using Battle.Menu;
using Battle.Pokemon;
using Battle.State;
using Core;
using Core.Factories;

namespace Battle
{
    public class BattleSystem : BattleStateMachine
    {
        public IMenuUIManager UI { get; private set; }
        public IPokemonManager Player { get; private set; }
        public IPokemonManager Enemy { get; private set; }
        
        public bool GameOver() =>
            Player.ActivePokemon == null || Enemy.ActivePokemon == null;

        private void Awake()
        {
            UI = GetComponent<IMenuUIManager>();
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
                PokemonFactory.Create(AvailablePokemon.Bob, 1),
                PokemonFactory.Create(AvailablePokemon.Charmander, 15)
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