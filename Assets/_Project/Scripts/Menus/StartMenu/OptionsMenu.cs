using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Project.Scripts.Menus.StartMenu
{
    public class OptionsMenu : MenuState
    {
        private readonly Button[] _buttons;
        private readonly List<UnityAction> _actions;

        public OptionsMenu(MenuSystem menuSystem) : base(menuSystem)
        {
            _buttons = menuSystem.OptionsMenu.GetComponentsInChildren<Button>();
            _actions = new List<UnityAction>();
        }

        public override IEnumerator CreateMenu()
        {
            foreach (var button in _buttons)
            {
                var action = Listener(button);
                _actions.Add(action);
                button.onClick.AddListener(action);
            }

            yield break;
        }

        public override IEnumerator DeleteMenu()
        {
            foreach (var (action, i) in _actions.Select((action, i) => (action, i)))
            {
                _buttons[i].onClick.RemoveListener(action);
            }

            yield break;
        }

        private UnityAction Listener(Button button)
        {
            return () =>
            {
                if (button.name != "BackButton") return;

                MenuSystem.OptionsMenu.SetActive(false);
                MenuSystem.MainMenu.gameObject.SetActive(true);
                MenuSystem.SetState(new MainMenu(MenuSystem));
            };
        }
    }
}