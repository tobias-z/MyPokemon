namespace Battle.Pokemon
{
    public interface IPokemonAction
    {
        void Attack(IPokemonManager pokemonManager);
        void Run();

        void TakeDamage(float amount);

        void Die();

        bool IsDead();
    }
}