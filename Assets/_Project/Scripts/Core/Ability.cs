namespace Core
{
    public class Ability
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public float BaseDmg { get; set; }

        public Ability(string name, Type type, float baseDmg)
        {
            Name = name;
            Type = type;
            BaseDmg = baseDmg;
        }
    }

    public enum Type
    {
        Fire,
        Water,
        Grass,
        Thunder,
        Ground
    }
}