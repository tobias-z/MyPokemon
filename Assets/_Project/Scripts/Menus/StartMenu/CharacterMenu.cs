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
        private readonly TextMeshProUGUI _nameInput;
        
        public CharacterMenu(MenuSystem menuSystem) : base(menuSystem)
        {
            _nameInput = GameObject.FindGameObjectWithTag("InputField").GetComponent<TextMeshProUGUI>();
            _startGameButton = MenuSystem.CharacterMenu.GetComponentInChildren<Button>();
        }

        public override IEnumerator CreateMenu()
        {
            _startGameButton.onClick.AddListener(OnStartClick);
            yield break;
        }

        private void OnStartClick()
        {
            if (_nameInput.text.Equals("")) return;
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