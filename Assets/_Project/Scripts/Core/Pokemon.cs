namespace Core
{
    public interface IPokemon
    {
        string Name { get; set; }
        int Level { get; set; }
        float Health { get; set; }
    }

    public struct Pokemon : IPokemon
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public float Health { get; set; }

        public Pokemon(string name, int level, float health)
        {
            Name = name;
            Level = level;
            Health = health;
        }
    }
}