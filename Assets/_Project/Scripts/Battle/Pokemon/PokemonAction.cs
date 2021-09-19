using Battle.State;
using UnityEngine;

namespace Battle.Pokemon
{
    public class PokemonAction : IPokemonAction
    {
        private readonly BattleSystem _battleSystem;
        private readonly IPokemonManager _pokemonManager;
        private readonly PokemonComponents _components;

        public PokemonAction(PokemonComponents components, BattleSystem battleSystem, IPokemonManager pokemonManager)
        {
            _components = components;
            _battleSystem = battleSystem;
            _pokemonManager = pokemonManager;
        }

        public void Attack(IPokemonManager pokemonManager)
        {
            pokemonManager.Action.TakeDamage(Random.Range(10, 30));
        }

        public void Run()
        {
            Application.Quit();
        }

        public void TakeDamage(float amount)
        {
            _components.Slider.value -= amount;
            SetHealthText(_components.Slider.value);
        }

        public void Die()
        {
            if (Equals(_battleSystem.Player.Action))
                _battleSystem.SetState(new LostBattle(_battleSystem));
            if (Equals(_battleSystem.Enemy.Action))
                _battleSystem.SetState(new WonBattle(_battleSystem));
        }

        public bool IsDead() => _components.Slider.value <= 0;

        private void SetHealthText(float amount)
        {
            _components.Health.text = $"{amount}/{_components.Health.text.Split('/')[1]}";
        }
    }
}