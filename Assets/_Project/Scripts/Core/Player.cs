using System.Collections.Generic;
using Core.Pokemon;
using UnityEngine;

namespace Core
{
    public class Player : MonoBehaviour
    {
        public string Name { get; set; }
        public List<IPokemon> Pokemons { get; set; }
    }
}