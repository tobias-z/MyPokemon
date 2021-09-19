namespace Core
{
    public interface IPokemon
    {
        string Name { get; }
        int Level { get; }
        double Health { get; }
    }

    public struct Pokemon : IPokemon
    {
        public string Name { get; }
        public int Level { get; }
        public double Health { get; }

        public Pokemon(string name, int level, double health)
        {
            Name = name;
            Level = level;
            Health = health;
        }
    }
}