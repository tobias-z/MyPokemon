namespace Battle.Pokemon
{
    public interface IPokemonUIManager
    {
        void SetHealth(float amount);
        void SetName(string name);
        void SetLevel(string level);
    }

    public class PokemonUIManager : IPokemonUIManager
    {
        private PokemonComponents _components;

        public PokemonUIManager(PokemonComponents components)
        {
            _components = components;
        }

        public void SetHealth(float amount)
        {
            amount = amount < 0 ? 0 : amount;
            _components.Health.text = $"{amount}/{_components.Health.text.Split('/')[1]}";
        }
        
        public void SetName(string name) => _components.Name.text = name;
        
        public void SetLevel(string level) => _components.Level.text = level;
    }
}