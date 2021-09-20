using System;
using System.Linq;
using Core;
using UnityEngine;

namespace Battle.Pokemon
{

    public class PokemonManager : MonoBehaviour, IPokemonManager
    {
        // IPokemon[] with data... health, slider, name, level, abilities (IAbility)...
        [SerializeField] private PokemonComponents components;

        public IPokemonAction Action { get; private set; }
        public IPokemonUIManager UI { get; private set; }
        public Player Player { get; private set; }

        public IPokemon ActivePokemon { get; private set; }

        public PokemonManager()
        {
            UI = new PokemonUIManager(components);
        }

        public void Init(BattleSystem battleSystem, Player player)
        {
            UI = new PokemonUIManager(components);
            Player = player;
            ActivateNextPokemon();
            Action = new PokemonAction(components, battleSystem, this);
        }

        public void ActivateNextPokemon()
        {
            ActivePokemon = Player.Pokemons.Find(pokemon => pokemon.Health > 0);
            if (ActivePokemon == null)
            {
                Action.Die();
                return;
            }
            
            UI.SetName(ActivePokemon.Name);
            components.Slider.maxValue = ActivePokemon.Health;
            components.Slider.value = ActivePokemon.Health;
            components.Health.text = $"{ActivePokemon.Health}/{ActivePokemon.Health}";
            UI.SetLevel("" + ActivePokemon.Level);
        }

        private void Update()
        {
            if (Action.IsDead())
            {
                ActivateNextPokemon();
            }
        }
    }
}