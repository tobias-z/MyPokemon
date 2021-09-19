namespace Battle.Pokemon
{
    public interface IPokemonManager
    {
        void Init(BattleSystem battleSystem);
        
        IPokemonAction Action { get; } 
    }
}