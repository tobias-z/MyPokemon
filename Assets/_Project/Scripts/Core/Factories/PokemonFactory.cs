using System.Collections.Generic;

namespace Core.Factories
{
    public static class PokemonFactory
    {
        private static readonly Dictionary<AvailablePokemon, List<Ability>> Abilities =
            new Dictionary<AvailablePokemon, List<Ability>>()
            {
                {
                    AvailablePokemon.Charmander, new List<Ability>
                    {
                        AbilityFactory.Create(AvailableAbility.Flamethrower),
                        AbilityFactory.Create(AvailableAbility.Tackle),
                        AbilityFactory.Create(AvailableAbility.QuickAttack),
                        AbilityFactory.Create(AvailableAbility.JumpAtHim),
                    }
                },
                {
                    AvailablePokemon.Pikachu, new List<Ability>
                    {
                        AbilityFactory.Create(AvailableAbility.LightningBolt),
                        AbilityFactory.Create(AvailableAbility.Tackle),
                        AbilityFactory.Create(AvailableAbility.QuickAttack),
                        AbilityFactory.Create(AvailableAbility.SomeAbility),
                    }
                },
                {
                    AvailablePokemon.Bob, new List<Ability>
                    {
                        AbilityFactory.Create(AvailableAbility.Flamethrower),
                        AbilityFactory.Create(AvailableAbility.LightningBolt),
                        AbilityFactory.Create(AvailableAbility.SomeAbility),
                        AbilityFactory.Create(AvailableAbility.Tackle),
                    }
                }
            };

        public static IPokemon Create(AvailablePokemon availablePokemon, int level)
        {
            IPokemon pokemon = new Pokemon(availablePokemon.ToString(), level);
            pokemon.Abilities = Abilities[availablePokemon];
            return pokemon;
        }
    }
}