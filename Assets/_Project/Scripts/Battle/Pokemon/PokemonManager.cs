using System;
using System.Linq;
using Core;
using UnityEngine;

namespace Battle.Pokemon
{
    public class PokemonManager : MonoBehaviour, IPokemonManager
    {
        [SerializeField] private PokemonComponents components;

        public IPokemonAction Action { get; private set; }
        public IPokemonUIManager UI { get; private set; }
        public Player Player { get; private set; }
        public IPokemon ActivePokemon { get; private set; }

        public void Init(BattleSystem battleSystem, Player player)
        {
            UI = new PokemonUIManager(components);
            Player = player;
            ActivateNextPokemon();
            TogglePokeballs();
            Action = new PokemonAction(components, battleSystem, this);
        }

        private void TogglePokeballs()
        {
            for (var i = 0; i < components.Pokeballs.Length; i++)
            {
                var hasPokemon = Player.Pokemons.Count > i;
                if (!hasPokemon) return;

                var isAlive = Player.Pokemons[i].IsAlive();
                var pokeball = components.Pokeballs[i];
                if (isAlive)
                    pokeball.Enable();
                else
                    pokeball.Disable();
            }
        }

        private void ActivateNextPokemon()
        {
            ActivePokemon = Player.Pokemons.Find(pokemon => pokemon.IsAlive());
            var noMorePokemons = ActivePokemon == null;
            if (noMorePokemons)
            {
                Action.Die();
                return;
            }

            UI.SetName(ActivePokemon.Name);
            components.Slider.maxValue = ActivePokemon.Health;
            components.Slider.value = ActivePokemon.Health;
            components.Health.text = $"{ActivePokemon.Health}/{ActivePokemon.Health}";
            UI.SetLevel(ActivePokemon.Level.ToString());
        }

        private void Update()
        {
            if (ActivePokemon == null) return;
            if (ActivePokemon.IsAlive()) return;
            ActivateNextPokemon();
            TogglePokeballs();
        }
    }
}