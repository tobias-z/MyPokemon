using Core;
using Core.Pokemon;

namespace Battle.Pokemon
{
    public interface IPokemonManager
    {
        void Init(BattleSystem battleSystem, Player player);
        
        IPokemonAction Action { get; }
        
        IPokemonUIManager UI { get; }
        Player Player { get; }
        IPokemon ActivePokemon { get; }
    }
}