using Core.Pokemon;

namespace Battle.Pokemon
{
    public interface IPokemonAction
    {
        void Attack(IPokemonManager pokemonManager, Ability ability);
        void Run();

        void TakeDamage(float amount);

        void Die();
    }
}