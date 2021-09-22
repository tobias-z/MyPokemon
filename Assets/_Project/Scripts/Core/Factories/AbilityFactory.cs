using System.Collections.Generic;

namespace Core.Factories
{
    public static class AbilityFactory
    {
        private static readonly Dictionary<AvailableAbility, Ability> Abilities =
            new Dictionary<AvailableAbility, Ability>()
            {
                {AvailableAbility.Flamethrower, new Ability("Flamethrower", Type.Fire, 10)},
                {AvailableAbility.Tackle, new Ability("Tackle", Type.Ground, 8)},
                {AvailableAbility.LightningBolt, new Ability("LightningBolt", Type.Thunder, 10)},
                {AvailableAbility.QuickAttack, new Ability("QuickAttack", Type.Ground, 9)},
                {AvailableAbility.SomeAbility, new Ability("SomeAbility", Type.Water, 5)},
                {AvailableAbility.JumpAtHim, new Ability("JumpAtHim", Type.Grass, 15)},
            };

        public static Ability Create(AvailableAbility availableAbility)
        {
            return Abilities[availableAbility];
        }
    }
}