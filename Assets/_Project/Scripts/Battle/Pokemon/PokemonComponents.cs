using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.Pokemon
{
    [Serializable]
    public struct PokemonComponents
    {
        [SerializeField] private TextMeshProUGUI name;
        [SerializeField] private TextMeshProUGUI level;
        [SerializeField] private TextMeshProUGUI health;
        [SerializeField] private Slider slider;

        public TextMeshProUGUI Name => name;

        public TextMeshProUGUI Level => level;
        public TextMeshProUGUI Health => health;

        public Slider Slider => slider;
    }
}