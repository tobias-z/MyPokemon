namespace Core
{
    public interface IPokemon
    {
        string Name { get; set; }
        int Level { get; set; }
        float Health { get; set; }
        bool IsAlive();
    }

    public struct Pokemon : IPokemon
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public float Health { get; set; }
        public bool IsAlive() => Health > 0;

        public Pokemon(string name, int level, float health)
        {
            Name = name;
            Level = level;
            Health = health;
        }
    }
}