using System.Collections.Generic;
using Core.Pokemon;

namespace Core.Factories
{
    public static class PokemonFactory
    {
        private static readonly Dictionary<AvailablePokemon, List<Ability>> PokemonAbilities =
            new Dictionary<AvailablePokemon, List<Ability>>
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
            IPokemon pokemon = new Pokemon.Pokemon(availablePokemon.ToString(), level);
            pokemon.Abilities = PokemonAbilities[availablePokemon];
            return pokemon;
        }
    }
}