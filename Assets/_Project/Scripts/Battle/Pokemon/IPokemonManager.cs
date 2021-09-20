using Core;

namespace Battle.Pokemon
{
    public interface IPokemonManager
    {
        void Init(BattleSystem battleSystem, Player player);
        
        IPokemonAction Action { get; }
        
        IPokemonUIManager UI { get; }
        IPokemon ActivePokemon { get; }

        void ActivateNextPokemon();
        
    }
}