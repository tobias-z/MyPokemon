using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Core
{
    public interface IPokemon
    {
        string Name { get; set; }
        int Level { get; set; }
        float Health { get; set; }
        public List<Ability> Abilities { get; set; }
        bool IsAlive();
    }

    public struct Pokemon : IPokemon
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public float Health { get; set; }
        public bool IsAlive() => Health > 0;
        public List<Ability> Abilities { get; set; }

        public Pokemon(string name, int level)
        {
            Name = name;
            Level = level;
            Health = PokemonHealth.GetHealth(level);
            Abilities = new List<Ability>();
        }
    }

    public static class PokemonHealth
    {
        public static float GetHealth(int level)
        {
            return level * 10;
        }
    }
}