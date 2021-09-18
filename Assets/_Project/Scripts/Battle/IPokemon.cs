namespace Battle
{
    public interface IPokemon
    {
        void Attack(IPokemon pokemon);
        void Run();

        void TakeDamage(float amount);

        void Die();
    }
}