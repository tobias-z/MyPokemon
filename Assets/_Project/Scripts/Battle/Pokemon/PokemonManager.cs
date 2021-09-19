using Core;
using UnityEngine;

namespace Battle.Pokemon
{
    public class PokemonManager : MonoBehaviour, IPokemonManager
    {
        // IPokemon[] with data... health, slider, name, level, abilities (IAbility)...
        [SerializeField] private PokemonComponents components;
        public IPokemonAction Action { get; private set; }

        public Player Player { get; private set; }
        
        public void Init(BattleSystem battleSystem, Player player)
        {
            Action = new PokemonAction(components, battleSystem, this);
            Player = player;
        }
    }
}