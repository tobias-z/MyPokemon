using System.Collections;
using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menus.StartMenu
{
    public class CharacterMenu : MenuState
    {
        private readonly Button _startGameButton;
        private readonly TMP_InputField _nameInput;
        
        public CharacterMenu(MenuSystem menuSystem) : base(menuSystem)
        {
            _nameInput = GameObject.FindGameObjectWithTag("InputField").GetComponent<TMP_InputField>();
            _startGameButton = MenuSystem.CharacterMenu.GetComponentInChildren<Button>();
        }

        public override IEnumerator CreateMenu()
        {
            _startGameButton.onClick.AddListener(OnStartClick);
            yield break;
        }

        private void OnStartClick()
        {
            if (string.IsNullOrEmpty(_nameInput.text)) return;
            CreatePlayer();
            ActiveBattleScreen();
        }

        private void CreatePlayer()
        {
            var pokemons = new List<IPokemon>()
            {
                new Pokemon("Pikachu", 1, 50),
                new Pokemon("Bob", 10, 200)
            };
            var player = MenuSystem.BattleScreen.AddComponent<Player>();
            player.Name = _nameInput.text;
            player.Pokemons = pokemons;
        }

        private void ActiveBattleScreen()
        {
            MenuSystem.BattleScreen.SetActive(true);
            MenuSystem.gameObject.SetActive(false);
        }
    }
}