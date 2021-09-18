using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menus.StartMenu
{
    public class MainMenu : MenuState
    {
        private readonly Button[] _buttons;
        
        public MainMenu(MenuSystem menuSystem) : base(menuSystem)
        {
            _buttons = menuSystem.MainMenu.GetComponentsInChildren<Button>();
        }
        
        public override IEnumerator CreateMenu()
        {
            foreach (var button in _buttons)
            {
                button.onClick.AddListener(Listener(button));
            }

            yield break;
        }

        public override IEnumerator DeleteMenu()
        {
            foreach (var button in _buttons)
            {
                button.onClick.RemoveListener(Listener(button));
            }

            yield break;
        }

        private UnityAction Listener(Button button)
        {
            return () =>
            {
                switch (button.name)
                {
                    case "PlayButton":
                        SceneManager.LoadScene("GameScene");
                        break;
                    case "QuitButton":
                        Application.Quit();
                        break;
                    case "OptionsButton":
                        MenuSystem.SetState(new OptionsMenu(MenuSystem));
                        MenuSystem.OptionsMenu.SetActive(true);
                        MenuSystem.MainMenu.gameObject.SetActive(false);
                        break;
                }
            };
        }
    }
}